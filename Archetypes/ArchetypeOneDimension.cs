namespace ECS.Archetypes;

public class ArchetypeOneDimension<T1> : ArchetypeBase 
    where T1 : IComponent
{
    private readonly T1[] _componentData1;

    public ArchetypeOneDimension(int capacity) : base(capacity)
    {
        _componentData1 = new T1[capacity];
        
        Components.Add(typeof(T1), _componentData1);
        
        InitializeIdentifier();
    }

    public void AddComponents(T1 component)
    {
        _componentData1[Count] = component;
        Count++;
    }
}