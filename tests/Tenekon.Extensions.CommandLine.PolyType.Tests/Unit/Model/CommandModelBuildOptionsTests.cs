using Shouldly;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Model;

public class CommandModelBuildOptionsTests
{
    [Fact]
    public void Default_UsesThrowForRootParentHandling()
    {
        CommandModelBuildOptions.Default.RootParentHandling.ShouldBe(RootParentHandling.Throw);
    }

    [Fact]
    public void With_OverridesRootParentHandling()
    {
        var options = CommandModelBuildOptions.Default with { RootParentHandling = RootParentHandling.Ignore };

        options.RootParentHandling.ShouldBe(RootParentHandling.Ignore);
    }
}