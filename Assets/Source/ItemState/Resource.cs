using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Brick, Iron, Copper, Dural 
}




public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceData data;
   
    [field : SerializeField] public bool isIron { get; set; }
    public ResourceData Data => data;

}


