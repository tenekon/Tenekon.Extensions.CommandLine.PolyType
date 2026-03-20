namespace Tenekon.Extensions.CommandLine.PolyType.Runtime.Binding;

internal readonly record struct BinderKey(Type CommandType, Type TargetType);