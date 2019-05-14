using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct ConstructComponent : IComponentData
{
    public float BuildTime;
    public float Progress;
}
