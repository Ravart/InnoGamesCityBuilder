using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class ProduceProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    //Used for prefab entities with production function
    
    public float gold = 0;
    public float wood = 0;
    public float steel = 0;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {   
        var produce = new ProduceComponent
        {
            time = Time.realtimeSinceStartup,
            Production = new ResourceComponent // What the building is going to produce
            {
                
                gold = gold,
                wood = wood,
                steel = steel
            },
            Storage = new ResourceComponent // What has been produced
            {
                
                gold = 0,
                wood = 0,
                steel = 0
            }
        };
        dstManager.AddComponentData(entity, produce);
        
#if UNITY_EDITOR
        dstManager.SetName(entity, string.Format("Prefab #" + entity.Index + ":" + name, entity.Index));
#endif
    }
}