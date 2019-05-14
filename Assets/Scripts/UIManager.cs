using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float gold, wood, steel;
    public Text tx_gold, tx_wood, tx_steel; 

    // Update is called once per frame
    void Update()
    {

        EntityManager entityManager = World.Active.EntityManager;

        //Little hacky, since we expect element of index 0 to be our player entity
        NativeArray<Entity> entities = entityManager.GetAllEntities();
        if (entities.Length == 0)
            return;
        
        Entity entity = entities[0];

        if (!entityManager.HasComponent<ResourceComponent>(entity))
            return;
        
        ResourceComponent resources = entityManager.GetComponentData<ResourceComponent>(entity);
        
        tx_gold.text = "" + resources.gold;
        tx_wood.text = "" + resources.wood;
        tx_steel.text = "" + resources.steel;
    }
}
