namespace ECS;

public interface ISystem
{
     ArchetypeIdentifier ApplicableTypes { get; }
     void ProcessAction(IEnumerable<Archetype> applicableTypes);
}