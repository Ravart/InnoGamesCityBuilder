using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(ProductionSysJob))]
public class PayoutSysJob : JobComponentSystem
{
    private EntityQuery group;
    private NativeArray<ProduceComponent> array;
 
    // Here we define the group 
    protected override void OnCreate()
    {
        //ReadOnly is not possible since we need to change the component
        group = GetEntityQuery(typeof(ProduceComponent));
        
        //EntityQuery group = GetEntityQuery(typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>());
        //group = GetEntityQuery(ComponentType.ReadOnly<ProduceComponent>());
    }
    
    protected override void OnDestroy() {
        //array.Dispose();
    }
    
    
    //Runs on the MainThread
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        EntityManager entityManager = World.Active.EntityManager;
        NativeArray<Entity> entities = group.ToEntityArray(Allocator.TempJob);

        float gold = 0;
        float wood = 0;
        float steel = 0;
        
        foreach (Entity entity in entities)
        {
            ProduceComponent production = entityManager.GetComponentData<ProduceComponent>(entity);
            gold += production.Storage.gold;
            wood += production.Storage.wood;
            steel += production.Storage.steel;
            
            
            entityManager.SetComponentData(entity, new ProduceComponent
            {
                time = production.time,
                Production = production.Production,
                Storage = new ResourceComponent // What has been produced
                {
                    gold = 0,
                    wood = 0,
                    steel = 0
                }
            });
        }
        
        entities.Dispose();
        
        //array = new NativeArray<ProduceComponent>();
        
        var job = new PayoutJob
        {
            gold = gold,
            wood = wood,
            steel = steel
            //array = array,
            //production = GetComponentDataFromEntity<ProduceComponent>(true),
        };
        
        //
        return job.Schedule(this, inputDependencies);
    }
    

    [BurstCompile]
    struct PayoutJob : IJobForEach<PlayerComponent, ResourceComponent>
    {
        public float gold, wood, steel;
        
        //[ReadOnly] public ComponentDataFromEntity<ProduceComponent> production;
    
        public void Execute(ref PlayerComponent player, ref ResourceComponent resource)
        {
            /*foreach (Entity entity in array)
            {
                ResourceComponent resources = GetComponentData<ResourceComponent>(entity);
                gold = resources.gold;
                resources.gold = 0;
                wood = resources.wood;
                resources.wood = 0;
                steel = resources.steel;
                resources.steel  = 0;
            }*/
            
            resource.gold += gold;
            resource.wood += wood;
            resource.steel += steel;
        }
    }
}