using System;
using Unity.Entities;

[Serializable]
public struct ResourceComponent : IComponentData
{
    public float gold;
    public float wood;
    public float steel;
}
