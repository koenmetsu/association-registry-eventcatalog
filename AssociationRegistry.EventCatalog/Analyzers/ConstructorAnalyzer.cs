using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssociationRegistry.EventCatalog.Analyzers;

public class ConstructorAnalyzer
{
    private readonly TypeAttributeAnalyzer _attributeAnalyzer;
    private readonly SyntaxNode _root;

    public ConstructorAnalyzer(TypeAttributeAnalyzer attributeAnalyzer,
        SyntaxNode root)
    {
        _attributeAnalyzer = attributeAnalyzer;
        _root = root;
    }

    public (TypeInfo attributeKey, TypeInfo handlerInfo) Analyze(
        ConstructorDeclarationSyntax constructor)
    {
        var invocation = constructor.DescendantNodes()
            .OfType<InvocationExpressionSyntax>()
            .FirstOrDefault(inv =>
                inv.Expression is GenericNameSyntax genericMethod &&
                (genericMethod.Identifier.Text == "CreateEvent" ||
                 genericMethod.Identifier.Text == "ProjectEvent" ||
                 genericMethod.Identifier.Text == "ProjectAsyncEvent" ||
                 genericMethod.Identifier.Text == "ProjectAsync"));

        if (invocation != null)
        {
            var genericMethod = (GenericNameSyntax)invocation.Expression;
            var typeArgument =
                genericMethod.TypeArgumentList.Arguments.First();
            var attributeKey =
                _attributeAnalyzer.ExtractTypeInfo(typeArgument.ToString(),
                    _root);

            var declaringType =
                constructor.Parent as ClassDeclarationSyntax;
            var declaringTypeName = declaringType?.Identifier.Text;
            var handlerInfo =
                _attributeAnalyzer.ExtractTypeInfo(declaringTypeName,
                    _root);

            return (attributeKey, handlerInfo);
        }

        return (null, null);
    }
}
