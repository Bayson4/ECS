namespace ECS;

public class Archetype
{
    public ArchetypeIdentifier Identifier { get; }
    public int Count { get; private set; }

    private readonly Dictionary<Type, Array> _components;

    public Archetype(int capacity, params Type[] componentTypes)
    {
        Identifier = new ArchetypeIdentifier(componentTypes);
        _components = new Dictionary<Type, Array>(componentTypes.Length);

        foreach (var type in componentTypes)
        {
            var components = Array.CreateInstance(type, capacity);
            _components.Add(type, components);
        }
    }

    public void AddComponents(Type[] types, IComponent[] components)
    {
        for (var i = 0; i < types.Length; i++)
        {
            var componentArray = _components[types[i]];
            componentArray.SetValue(components[i], Count);
        }
        Count++;
    }

    public T[] GetComponentsArray<T>() 
    {
        return (T[])_components[typeof(T)];
    }
}