using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class ProductionSysJob : JobComponentSystem
{
    //Runs on the MainThread
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new ProduceJob
        {
            timestep = 10,
            deltaTime = Time.deltaTime
        };
        return job.Schedule(this, inputDependencies);
    }
    

    [BurstCompile]
    struct ProduceJob : IJobForEach<ProduceComponent>
    {
        public float deltaTime;
        public float timestep;
        
        public void Execute(ref ProduceComponent product)
        {
            product.time += deltaTime;

            if (product.time / timestep > 1)
            {
                product.time = product.time % timestep;
                
                product.Storage.gold += product.Production.gold;
                product.Storage.wood += product.Production.wood;
                product.Storage.steel += product.Production.steel;
            }
            
            
        }
    }
}