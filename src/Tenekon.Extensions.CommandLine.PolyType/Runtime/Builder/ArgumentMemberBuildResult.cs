using System.CommandLine;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Builder;

internal sealed record ArgumentMemberBuildResult(Symbol Symbol, Action<object, ParseResult> Binder);