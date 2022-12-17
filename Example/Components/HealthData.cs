namespace ECS.Example.Components;

public struct HealthData
{
    public int Max;
    public int Current;

    public HealthData(int current, int max)
    {
        Current = current;
        Max = max;
    }
}