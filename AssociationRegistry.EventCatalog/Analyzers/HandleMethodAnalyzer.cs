using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssociationRegistry.EventCatalog.Analyzers;

public class HandleMethodAnalyzer
{
    private readonly TypeAttributeAnalyzer _attributeAnalyzer;
    private readonly SyntaxNode _root;

    public HandleMethodAnalyzer(TypeAttributeAnalyzer attributeAnalyzer,
        SyntaxNode root)
    {
        _attributeAnalyzer = attributeAnalyzer;
        _root = root;
    }

    public (TypeInfo, TypeInfo) Analyze(MethodDeclarationSyntax method)
    {
        var parameterType = method.ParameterList.Parameters.First().Type;
        var handledTypeInfo = _attributeAnalyzer.ExtractTypeInfo(
            parameterType.ToString(),
            _root);

        var declaringType = method.Parent as ClassDeclarationSyntax;
        var declaringTypeName = declaringType?.Identifier.Text;

        var handlerTypeInfo =
            _attributeAnalyzer.ExtractTypeInfo(declaringTypeName, _root);
        return (handledTypeInfo, handlerTypeInfo);
    }
}
