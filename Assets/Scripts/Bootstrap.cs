using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

public class Bootstrap
{
    //Automatic Startup before Scene Load
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeBefore()
    {
        
    }
    
    //Automatic Startup after Scene Load
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeWithScene()
    {
        
    }
}
