using ECS.Example.Components;

namespace ECS;

public class World
{
    private readonly EntityManager _entityManager;
    private readonly SystemManager _systemManager;

    public World()
    {
        _entityManager = new EntityManager();
        _systemManager = new SystemManager();
        
        _entityManager.CreateEntity(new HealthData(50, 100), new RegenerationData(10, 1));
    }
    
    public void Initialize()
    {
        _systemManager.RegisterSystems();
    }

    private void OnTick()
    {
        _systemManager.ProcessActions(_entityManager.ExistingArchetypes);
    }
}