using System.CommandLine;
using Shouldly;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Runtime.Graph;

public class RuntimeNodeTests
{
    [Fact]
    public void GetRoot_ReturnsRootNode()
    {
        var root = RuntimeNode.CreateType(typeof(string), new Command("root"), [], []);
        var child = RuntimeNode.CreateType(typeof(int), new Command("child"), [], []);
        root.Children.Add(child);
        child.Parent = root;

        child.GetRoot().ShouldBe(root);
    }

    [Fact]
    public void Find_ReturnsMatchingDescendant()
    {
        var root = RuntimeNode.CreateType(typeof(string), new Command("root"), [], []);
        var child = RuntimeNode.CreateType(typeof(int), new Command("child"), [], []);
        root.Children.Add(child);
        child.Parent = root;

        root.Find(typeof(int)).ShouldBe(child);
    }
}