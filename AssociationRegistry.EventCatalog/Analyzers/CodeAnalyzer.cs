using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssociationRegistry.EventCatalog.Analyzers;

public class CodeAnalyzer
{
    private readonly ConstructorAnalyzer _constructorAnalyzer;
    private readonly HandleMethodAnalyzer _handleMethodAnalyzer;
    private readonly SyntaxNode _root;

    public CodeAnalyzer(string code)
    {
        var tree = CSharpSyntaxTree.ParseText(code);
        _root = tree.GetRoot();

        var typeAttributeAnalyzer = new TypeAttributeAnalyzer();
        _handleMethodAnalyzer =
            new HandleMethodAnalyzer(typeAttributeAnalyzer, _root);
        _constructorAnalyzer =
            new ConstructorAnalyzer(typeAttributeAnalyzer, _root);
    }

    public Dictionary<TypeInfo, List<TypeInfo>> AnalyzeCode()
    {
        var results = new Dictionary<TypeInfo, List<TypeInfo>>();

        // Analyze handle methods
        var handleMethods = _root.DescendantNodes()
            .OfType<MethodDeclarationSyntax>()
            .Where(m => m.Identifier.Text == "Handle" ||
                        m.Identifier.Text == "Project" ||
                        m.Identifier.Text == "HandleAsync" ||
                        m.Identifier.Text == "ProjectAsync");

        foreach (var method in handleMethods)
        {
            var (handledType, handlerType) =
                _handleMethodAnalyzer.Analyze(method);

            handledType = Prettify(handledType);


            if (handledType != null && !handledType.Name.StartsWith("Command"))
            {
                if (!results.ContainsKey(handledType))
                    results[handledType] = new List<TypeInfo>();

                results[handledType].Add(handlerType);
            }
        }

        // Analyze constructors
        var constructors = _root.DescendantNodes()
            .OfType<ConstructorDeclarationSyntax>();

        foreach (var constructor in constructors)
        {
            var (keyInfo, declaringType) =
                _constructorAnalyzer.Analyze(constructor);

            if (keyInfo != null)
            {
                if (!results.ContainsKey(keyInfo))
                    results[keyInfo] = new List<TypeInfo>();

                results[keyInfo].Add(declaringType);
            }
        }

        return results;
    }


    static TypeInfo Prettify(TypeInfo extractTypeInfo) =>
        extractTypeInfo with
        {
            Name = ExtractGenericType(extractTypeInfo.Name)
        };

    static string ExtractGenericType(string input)
    {
        var match = Regex.Match(input, @"<([^>]+)>");
        return match.Success
            ? match.Groups[1].Value
            : input; // Return empty string if no match found.
    }

}
