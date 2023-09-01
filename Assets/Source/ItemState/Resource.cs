using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Copper, Iron, Dural
}




public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceData data;
   
    [field : SerializeField] public bool isIron { get; set; }
    public ResourceData Data => data;

}


