using System.CommandLine;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

internal readonly record struct RuntimeValueAccessor(string DisplayName, Func<object?, ParseResult, object?> Getter);