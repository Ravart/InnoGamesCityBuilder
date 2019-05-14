using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class Testing : MonoBehaviour
{
    private EntityManager entityManager;
    private EntityArchetype archetype;

    public BuildingAsset[] buildings;

    //[SerializeField] private Mesh mesh;
    //[SerializeField] private Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        entityManager = World.Active.EntityManager;
        
        CreatePlayerEntity();
        
        //Instantiate ScriptableObject
        buildings[0].Spawn();
        //buildings[1].Spawn();
        //buildings[1].Spawn();
        
        /*entityManager = World.Active.EntityManager;
        
        //Create the Player Entity
        Entity  player = entityManager.CreateEntity(typeof(PlayerComponent), typeof(ResourceComponent));
        entityManager.SetComponentData(player, new PlayerComponent());
        
#if UNITY_EDITOR
        entityManager.SetName(player, string.Format("Player", player.Index));
#endif
        
        //Create an Archetype for Buildings to reuse components
        archetype = entityManager.CreateArchetype(
            typeof(ConstructComponent),
            typeof(ProduceComponent),
            typeof(Translation),
            typeof(RenderMesh), //Required for visual rendering
            typeof(LocalToWorld) //Required for visual rendering
        );

        NativeArray<Entity> array = new NativeArray<Entity>(20, Allocator.Temp);
        entityManager.CreateEntity(archetype, array);

        for (int i = 0; i < array.Length; i++)
        {
            Entity entity = array[i];
            entityManager.SetComponentData(entity, new ProduceComponent{Value = 50});
            entityManager.SetComponentData(entity, new ConstructComponent {Progress = 0, BuildTime = 10});
            entityManager.SetComponentData(entity, new Translation{ Value = new float3(Random.Range(-5,5), 0, Random.Range(-5,5))});
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
            
#if UNITY_EDITOR
            entityManager.SetName(entity, string.Format("Building #" + i + ":" + name, entity.Index));
#endif
        }
        
        //Clear Memory
        array.Dispose();
            
        //CreateEntity("Building 1");
        //CreateEntity("Building 2");*/
    }
    
    //Create the Player Entity
    void CreatePlayerEntity()
    {
        Entity  player = entityManager.CreateEntity(typeof(PlayerComponent), typeof(ResourceComponent));
        entityManager.SetComponentData(player, new PlayerComponent());
        entityManager.SetComponentData(player, new ResourceComponent{gold = 300, wood = 0, steel = 0});
        
#if UNITY_EDITOR
        entityManager.SetName(player, string.Format("Player", player.Index));
#endif
    }

    void CreateEntity(string displayname)
    {
        /*Entity entity = entityManager.CreateEntity(archetype);
        
        entityManager.SetComponentData(entity, new ProduceComponent{value = 50});
        entityManager.SetComponentData(entity, new ConstructComponent{value = 0});
        
#if UNITY_EDITOR
        entityManager.SetName(entity, string.Format(displayname + ":" + name, entity.Index));
#endif*/
    }
}
