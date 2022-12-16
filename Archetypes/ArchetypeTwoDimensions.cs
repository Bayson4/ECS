namespace ECS.Archetypes;

public class ArchetypeTwoDimensions<T1, T2> : ArchetypeBase 
    where T1 : IComponent 
    where T2 : IComponent
{
    private readonly T1[] _componentData1;
    private readonly T2[] _componentData2;
    
    public ArchetypeTwoDimensions(int capacity) : base(capacity)
    {       
        _componentData1 = new T1[capacity];
        _componentData2 = new T2[capacity];
        
        Components.Add(typeof(T1), _componentData1);
        Components.Add(typeof(T2), _componentData2);
        
        InitializeIdentifier();
    }

    public void AddComponents(T1 component1, T2 component2)
    {
        _componentData1[Count] = component1;
        _componentData2[Count] = component2;
        Count++;
    }
}