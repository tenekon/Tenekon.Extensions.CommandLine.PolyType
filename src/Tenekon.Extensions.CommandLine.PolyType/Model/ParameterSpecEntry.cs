using PolyType.Abstractions;

namespace Tenekon.Extensions.CommandLine.PolyType.Model;

internal readonly record struct ParameterSpecEntry(
    IParameterShape Parameter,
    OptionSpecModel? Option,
    ArgumentSpecModel? Argument,
    DirectiveSpecModel? Directive);