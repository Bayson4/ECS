namespace ECS;

public class Archetype
{
    public ArchetypeIdentifier Identifier { get; }
    public int Count { get; private set; }

    private readonly Dictionary<Type, ComponentBuffer> _componentStorage;

    public Archetype(int capacity, params Type[] componentTypes)
    {
        Identifier = new ArchetypeIdentifier(componentTypes);
        _componentStorage = new Dictionary<Type, ComponentBuffer>(componentTypes.Length);

        foreach (var type in componentTypes)
        {
            var componentBuffer = Activator.CreateInstance(typeof(ComponentBuffer).MakeGenericType(type), capacity) as ComponentBuffer;

            if (componentBuffer == null)
                throw new InvalidCastException($"Unable to create buffer for type {type}");
            
            _componentStorage.Add(type, componentBuffer);
        }
    }

    public void AddComponents(Type[] types, ValueType[] components)
    {
        for (var i = 0; i < types.Length; i++)
        {
            var componentArray = _componentStorage[types[i]];
            componentArray.Components[Count] = components[i];
        }
        Count++;
    }

    public T[] GetComponentsArray<T>() 
    {
        return (T[])_componentStorage[typeof(T)].Components;
    }
}