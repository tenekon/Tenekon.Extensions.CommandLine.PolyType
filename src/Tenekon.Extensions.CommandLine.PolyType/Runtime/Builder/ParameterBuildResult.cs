using System.CommandLine;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Builder;

internal readonly record struct ParameterBuildResult(object Symbol, RuntimeValueAccessor Accessor);

internal readonly record struct DirectiveParameterBuildResult(Directive Directive, RuntimeValueAccessor Accessor);