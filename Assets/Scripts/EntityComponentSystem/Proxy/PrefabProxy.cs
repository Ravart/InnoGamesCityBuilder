using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class PrefabProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    //Used for prefab entities without production function
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

#if UNITY_EDITOR
        dstManager.SetName(entity, string.Format("Prefab #" + entity.Index + ":" + name, entity.Index));
#endif
    }
}