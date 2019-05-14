using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ConstructSysJob : JobComponentSystem
{
    //Runs on the MainThread
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new ConstructJob()
        {
            DeltaTime = Time.deltaTime
        };
        return job.Schedule(this, inputDependencies);
    }
    
    [BurstCompile] //IJobParallelForTransform
    struct ConstructJob : IJobForEach<Translation, ConstructComponent>
    {
        public float DeltaTime;
    
        public void Execute(ref Translation position, ref ConstructComponent construction)
        {
            construction.Progress += DeltaTime;
            construction.Progress = construction.Progress >= construction.BuildTime ? construction.BuildTime : construction.Progress;

            
            position.Value = new float3(position.Value.x, 2 * construction.Progress /construction.BuildTime -2, position.Value.z);
        }
    }
}