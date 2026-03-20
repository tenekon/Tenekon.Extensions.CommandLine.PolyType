using Shouldly;
using Tenekon.Extensions.CommandLine.PolyType.Tests.Infrastructure;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Packaging;

public sealed class PackageLayoutTests(PackageLayoutFixture fixture) : IClassFixture<PackageLayoutFixture>
{
    [Theory]
    [InlineData("build/Tenekon.Extensions.CommandLine.PolyType.props")]
    [InlineData("buildTransitive/Tenekon.Extensions.CommandLine.PolyType.props")]
    [InlineData("Tenekon.Extensions.CommandLine.PolyType.Common.props")]
    [InlineData("lib/net10.0/Tenekon.Extensions.CommandLine.PolyType.dll")]
    [InlineData("lib/netstandard2.0/Tenekon.Extensions.CommandLine.PolyType.dll")]
    [InlineData("analyzers/dotnet/cs/Tenekon.Extensions.CommandLine.PolyType.SourceGenerator.dll")]
    public void Package_Contains_Expected_Entries(string entry)
    {
        fixture.Entries.ShouldContain(entry);
    }

    [Fact]
    public void Package_LibEntries_AreUnderTargetFrameworks()
    {
        var libEntries = fixture.Entries.Where(e => e.StartsWith("lib/", StringComparison.OrdinalIgnoreCase)).ToArray();
        var allowedPrefixes = new[]
        {
            "lib/net10.0/",
            "lib/netstandard2.0/"
        };

        libEntries.All(entry => allowedPrefixes.Any(prefix => entry.StartsWith(
                prefix,
                StringComparison.OrdinalIgnoreCase)))
            .ShouldBeTrue();
    }
}