using System.CommandLine;

namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

internal readonly record struct RuntimeGraph(RootCommand RootCommand, RuntimeNode RootNode);