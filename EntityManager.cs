namespace ECS;

public class EntityManager
{
    private const int ARCHETYPE_CAPACITY = 15;

    public IReadOnlyList<Archetype> ExistingArchetypes => _archetypes;

    private readonly List<Archetype> _archetypes;

    public EntityManager()
    {
        _archetypes = new List<Archetype>();
    }

    public void CreateEntity(ValueType[] components)
    {
        var types = components.Select(c => c.GetType()).ToArray();
        var identifier = new ArchetypeIdentifier(types);
        var archetype = GetArchetype(identifier, types);
        archetype.AddComponents(types, components);
    }

    private Archetype GetArchetype(ArchetypeIdentifier identifier, Type[] types)
    {
        foreach (var archetype in _archetypes)
        {
            if (identifier.IsSame(archetype.Identifier) && archetype.Count < ARCHETYPE_CAPACITY)
                return archetype;
        }

        return CreateArchetype(types);
    }

    private Archetype CreateArchetype(Type[] types)
    {
        var archetype = new Archetype(ARCHETYPE_CAPACITY, types);
        _archetypes.Add(archetype);
        return archetype;
    }
}