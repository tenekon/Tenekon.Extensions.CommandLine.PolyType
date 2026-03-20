using Shouldly;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Runtime;

public class CommandRuntimeSettingsTests
{
    [Fact]
    public void CommandRuntimeSettings_DefaultValues_AreInitialized()
    {
        var settings = new CommandRuntimeSettings();

        settings.ShowHelpOnEmptyCommand.ShouldBeFalse();
        settings.EnableSuggestDirective.ShouldBeTrue();
        settings.EnablePosixBundling.ShouldBeTrue();
        settings.Output.ShouldNotBeNull();
        settings.Error.ShouldNotBeNull();
        settings.FileSystem.ShouldNotBeNull();
    }
}