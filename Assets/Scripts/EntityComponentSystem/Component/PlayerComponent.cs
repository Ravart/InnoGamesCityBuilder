using System;
using Unity.Entities;

[Serializable]
public struct PlayerComponent : IComponentData {
    //Important player specific data, yet we have none in this example and use it only as tag

    //!!!This is a momentarily bugfix since empty IComponentData are Tags, which seem to work differently
    public float Value;
}
