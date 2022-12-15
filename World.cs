namespace ECS;

public class World
{
    private readonly EntityManager _entityManager;
    private readonly SystemManager _systemManager;

    public World()
    {
        _entityManager = new EntityManager();
        _systemManager = new SystemManager();
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