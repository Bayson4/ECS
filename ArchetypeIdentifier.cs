namespace ECS;

public class ArchetypeIdentifier
{
    public IReadOnlySet<Type> Types => _types;

    private readonly SortedSet<Type> _types;

    public ArchetypeIdentifier(IEnumerable<Type> types)
    {
        _types = new SortedSet<Type>(types);
    }

    public bool IsSame(ArchetypeIdentifier identifier)
    {
        return _types.SetEquals(identifier.Types);
    }

    public bool IncludesTypes(ArchetypeIdentifier identifier)
    {
        return identifier.Types.All(type => _types.Contains(type));
    }
}