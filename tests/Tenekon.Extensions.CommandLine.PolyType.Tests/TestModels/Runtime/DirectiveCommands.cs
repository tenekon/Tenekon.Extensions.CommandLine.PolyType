using PolyType;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.TestModels;

[CommandSpec]
[GenerateShape(IncludeMethods = MethodShapeFlags.PublicInstance)]
public partial class DirectiveCommand
{
    [DirectiveSpec]
    public bool Debug { get; set; }

    [DirectiveSpec(Name = "trace")]
    public string? Trace { get; set; }

    [DirectiveSpec]
    public string[] Tags { get; set; } = [];

    public void Run() { }
}