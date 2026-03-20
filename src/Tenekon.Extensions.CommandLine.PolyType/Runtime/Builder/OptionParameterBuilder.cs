using PolyType.Abstractions;
using Tenekon.Extensions.CommandLine.PolyType.Model;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.FileSystem;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Builder;

internal sealed class OptionParameterBuilder(
    IParameterShape parameterShape,
    OptionSpecModel spec,
    CommandNamingPolicy namer,
    IFileSystem fileSystem)
{
    public ParameterBuildResult? Build()
    {
        return (ParameterBuildResult?)parameterShape.Accept(new BuilderVisitor(spec, namer, fileSystem));
    }

    private sealed class BuilderVisitor(
        OptionSpecModel spec,
        CommandNamingPolicy namer,
        IFileSystem fileSystem)
        : TypeShapeVisitor
    {
        public override object? VisitParameter<TArgumentState, TParameterType>(
            IParameterShape<TArgumentState, TParameterType> parameterShape,
            object? state = null)
        {
            var name = namer.GetOptionName(parameterShape.Name, spec.Name);
            var required = RequiredHelper.IsRequired(parameterShape, spec);
            var option = SymbolBuildHelper.CreateOption<TParameterType>(name, spec, namer, required, fileSystem);

            var accessor = new RuntimeValueAccessor(
                parameterShape.Name,
                (_, parseResult) => parseResult.GetValue(option));

            return new ParameterBuildResult(option, accessor);
        }
    }
}
