using Shouldly;
using Tenekon.Extensions.CommandLine.PolyType.Tests.Infrastructure;
using Tenekon.Extensions.CommandLine.PolyType.Tests.TestModels;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Runtime;

public class CommandLineRunnerTests
{
    [Fact]
    public void Create_WithSettings_RunsSuccessfully()
    {
        var settings = new CommandRuntimeSettings();

        var cliApp = CommandRuntime.Factory.Object.Create<BasicRootCommand>(settings);
        cliApp.ShouldNotBeNull();

        var optionName = TestNamingPolicy.CreateDefault().GetOptionName(nameof(BasicRootCommand.Option1));

        var exitCode = cliApp.Run([optionName, "value", "argument"]);
        exitCode.ShouldBe(expected: 0);
    }
}