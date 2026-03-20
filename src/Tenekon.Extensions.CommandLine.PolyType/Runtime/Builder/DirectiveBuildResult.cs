using System.CommandLine;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Builder;

internal sealed record DirectiveBuildResult(Directive Directive, Action<object, ParseResult> Binder);