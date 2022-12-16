namespace ECS.Archetypes;

public abstract class ArchetypeBase
{
    public ArchetypeIdentifier Identifier { get; private set; }
    public int Count { get; protected set; }
    
    protected readonly Dictionary<Type, Array> Components;

    protected ArchetypeBase(int capacity)
    {
        Components = new Dictionary<Type, Array>();
    }
    
    public T[] GetComponentsArray<T>() 
    {
        return (T[])Components[typeof(T)];
    }

    protected void InitializeIdentifier()
    {
        Identifier = new ArchetypeIdentifier(Components.Keys);
    }
}