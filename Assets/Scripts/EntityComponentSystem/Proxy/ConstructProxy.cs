using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class ConstructProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    public float buildtime = 10;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {   
        var construct = new ConstructComponent
        {
            BuildTime = buildtime,
            Progress = 0
        };
        dstManager.AddComponentData(entity, construct);
    }
}