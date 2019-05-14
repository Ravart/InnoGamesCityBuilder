using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct ProduceComponent : IComponentData
{
    public float time;
    
    public ResourceComponent Production;
    public ResourceComponent Storage;
}
