using ECS.Example.Systems;

namespace ECS;

public class SystemManager
{
    private readonly List<ISystem> _systems;

    public SystemManager()
    {
        _systems = new List<ISystem>();
    }

    public void RegisterSystems()
    {
        _systems.Add(new HealthRegenerationSystem());
    }

    public void ProcessActions(IReadOnlyList<Archetype> existingArchetypes)
    {
        foreach (var system in _systems)
        {
            var applicableArchetypes = GetApplicableArchetypes(existingArchetypes, system.ApplicableTypes);
            if (applicableArchetypes.Any())
                system.ProcessAction(applicableArchetypes);
        }
    }

    private IEnumerable<Archetype> GetApplicableArchetypes(IReadOnlyList<Archetype> existingArchetypes, ArchetypeIdentifier identifier)
    {
        return existingArchetypes.Where(a => a.Identifier.IncludesTypes(identifier));
    }
}