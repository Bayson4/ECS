using ECS.Example.Components;

namespace ECS.Example.Systems;

public class HealthRegenerationSystem : ISystem
{
    public ArchetypeIdentifier ApplicableTypes => new(new[]
    {
        typeof(HealthData), 
        typeof(RegenerationData)
    });

    private long _regenerationTimer;
    
    public void ProcessAction(IEnumerable<Archetype> applicableTypes)
    {
        foreach (var archetype in applicableTypes)
        {
            var healthData = archetype.GetComponentsArray<HealthData>();
            var regenerationData = archetype.GetComponentsArray<RegenerationData>();

            for (var i = 0; i < healthData.Length; i++)
            {
                if(_regenerationTimer % regenerationData[i].TickTime != 0)
                    continue;
                
                if(healthData[i].Current == healthData[i].Max)
                    continue;

                var newHealthData = healthData[i];
                newHealthData.Current = Math.Max(newHealthData.Current + regenerationData[i].HealthValue, newHealthData.Max);
                healthData[i] = newHealthData;
            }
        }
        _regenerationTimer++;
    }
}