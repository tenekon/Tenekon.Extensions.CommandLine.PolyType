namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Graph;

internal readonly record struct RuntimeParentAccessor(Type ParentType, Action<object, object> Setter);