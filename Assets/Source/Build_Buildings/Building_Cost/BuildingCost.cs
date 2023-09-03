using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingType
{
     House = 0
}

[System.Serializable]
public class BuildingCost 
{
    public BuildingType buildingType;
    public ResourceType[] resourceType;
    public int amount;
}
