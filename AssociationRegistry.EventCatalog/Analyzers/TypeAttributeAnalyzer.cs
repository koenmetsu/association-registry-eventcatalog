using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssociationRegistry.EventCatalog.Analyzers;

public class TypeAttributeAnalyzer
{
    public TypeInfo ExtractTypeInfo(string typeAsString, SyntaxNode root)
    {
        var name = typeAsString;
        var description = "";
        var displayName = "";

        Console.WriteLine("Looking for " + typeAsString);

        var typeDeclaration =
            root.DescendantNodes().OfType<RecordDeclarationSyntax>()
                    .FirstOrDefault(r => r.Identifier.Text == name) as
                MemberDeclarationSyntax ??
            root.DescendantNodes().OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(r => r.Identifier.Text == name);

        if (typeDeclaration != null)
        {
            Console.WriteLine("Found it!");
            description = GetAttributeDescription(typeDeclaration,
                description, ref displayName);
        }

        return new TypeInfo(name, description, displayName);
    }

    private static string GetAttributeDescription(
        MemberDeclarationSyntax typeDeclaration, string description,
        ref string displayName)
    {
        foreach (var attributeList in typeDeclaration.AttributeLists)
        foreach (var attribute in attributeList.Attributes)
        {
            Console.WriteLine("Found attribute " + attribute);

            if (attribute.Name.ToString() == "Description")
                description = attribute.ArgumentList.Arguments.First()
                    .ToString().Trim('\"');

            if (attribute.Name.ToString() == "DisplayName")
                displayName = attribute.ArgumentList.Arguments.First()
                    .ToString();
        }

        return description;
    }
}
