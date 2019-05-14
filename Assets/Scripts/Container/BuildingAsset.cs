using System;
using System.Reflection;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingAsset : ScriptableObject
{
    //ScriptableObject which include data container for all the buildings
    
    [Rename("Name of Building")]
    public string displayname = "EMPTY";
    
    [ContextMenuItem("Reset", "ResetDescription")]
    [Multiline(8)]
    public string description = "";
    void ResetDescription()
    {
        description = "";
    }
    
    //[Rename("Resources")]
    public ResourceComponent cost;
    
    public GameObject prefab;
    public Texture2D icon;

    //Not the fastest spawning
    public void Spawn()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = name + "(GameObject)";
    }
    
}
