using System.Collections;

namespace ECS;

public abstract class ComponentBuffer
{
    public abstract IList Components { get; }
}

public sealed class ComponentBuffer<T> : ComponentBuffer where T : struct
{
    public override IList Components => _buffer;
    private readonly T[] _buffer;

    public ComponentBuffer(int capacity)
    {
        _buffer = new T[capacity];
    }
}