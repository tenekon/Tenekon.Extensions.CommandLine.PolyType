using PolyType.Abstractions;
using Shouldly;
using Tenekon.Extensions.CommandLine.PolyType.Model.Builder;
using Tenekon.Extensions.CommandLine.PolyType.Tests.TestModels;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Model;

public class CommandHandlerConventionModelTests
{
    [Fact]
    public void ToBuilder_DefaultConvention_IsExplicit()
    {
        var shape = (IObjectTypeShape)TypeShapeResolver.Resolve<RunCommand>();
        var model = CommandModelFactory.BuildFromObject(shape, shape.Provider);
        var builder = model.ToBuilder();
        var root = (CommandObjectModelBuilderNode)builder.Root!;

        root.HandlerConvention.MethodNames.ShouldBe(["RunAsync", "Run"]);
        root.HandlerConvention.PreferAsync.ShouldBeTrue();
        root.HandlerConvention.Disabled.ShouldBeFalse();
    }
}