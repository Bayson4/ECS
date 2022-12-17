namespace ECS.Example.Components;

public struct RegenerationData
{
    public int TickTime;
    public int HealthValue;

    public RegenerationData(int tickTime, int healthValue)
    {
        TickTime = tickTime;
        HealthValue = healthValue;
    }
}