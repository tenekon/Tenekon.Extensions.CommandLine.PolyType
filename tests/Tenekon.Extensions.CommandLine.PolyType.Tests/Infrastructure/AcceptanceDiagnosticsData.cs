using System.Collections;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Infrastructure;

public sealed class AcceptanceDiagnosticsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (var caseResult in AcceptanceFixtureCache.Instance.DiagnosticCases)
            yield return [caseResult];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}