using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PaydaySystem : ComponentSystem
{
    //This ComponentSystem runs on the main thread
    
    private float time = -1;

    protected override void OnCreate()
    {
        time = Time.realtimeSinceStartup;
    }

    // Runs on main thread
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerComponent player, ref ResourceComponent resource) =>
        {
            if (time + 2 < Time.realtimeSinceStartup)
            {
                //Daily Income
                //resource.gold += 100;
                time = Time.realtimeSinceStartup;
            }
        });
    }
}
