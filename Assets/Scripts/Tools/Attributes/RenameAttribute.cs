using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class RenameAttribute : PropertyAttribute
{
    public string NewName { get ; private set; }    
    public RenameAttribute( string name )
    {
        NewName = name ;
    }
}