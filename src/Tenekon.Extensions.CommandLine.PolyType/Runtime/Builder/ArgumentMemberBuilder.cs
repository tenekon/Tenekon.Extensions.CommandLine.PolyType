using System.CommandLine;
using PolyType.Abstractions;
using Tenekon.Extensions.CommandLine.PolyType.Model;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.FileSystem;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Builder;

internal sealed class ArgumentMemberBuilder(
    IPropertyShape specProperty,
    IPropertyShape targetProperty,
    ArgumentSpecModel spec,
    CommandNamingPolicy namer,
    IFileSystem fileSystem)
{
    public ArgumentMemberBuildResult? Build()
    {
        return (ArgumentMemberBuildResult?)specProperty.Accept(
            new BuilderVisitor(spec, namer, targetProperty, fileSystem));
    }

    private sealed class BuilderVisitor(
        ArgumentSpecModel spec,
        CommandNamingPolicy namer,
        IPropertyShape targetProperty,
        IFileSystem fileSystem) : TypeShapeVisitor
    {
        public override object? VisitProperty<TDeclaringType, TPropertyType>(
            IPropertyShape<TDeclaringType, TPropertyType> propertyShape,
            object? state = null)
        {
            var name = namer.GetArgumentName(propertyShape.Name, spec.Name);
            var required = RequiredHelper.IsRequired(targetProperty, spec);
            var argument = SymbolBuildHelper.CreateArgument<TPropertyType>(
                name,
                spec,
                namer,
                required,
                propertyShape.PropertyType,
                fileSystem);

            var setter = propertyShape.GetSetter();
            Action<object, ParseResult> binder = (instance, parseResult) =>
            {
                var typedInstance = (TDeclaringType)instance;
                var value = parseResult.GetValue(argument);
                if (value is null && !typeof(TPropertyType).IsValueType) return;
                setter(ref typedInstance, value!);
            };

            return new ArgumentMemberBuildResult(argument, binder);
        }
    }
}
