using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingBrain : MonoBehaviour
{
    public BuildingsPrice buildingPrices;
    private Inventory _inventory;
    [Inject]
    private void Contruct(Inventory inventory)
    {
        _inventory = inventory;
    }
    public bool CanBuildBuilding(BuildingsPrice price)
    {
        foreach (BuildingCost cost in price.data)
        {
            for(int i = 0; i < cost.resourceType.Length; i++)
            {
                if (!CheckResourceAvailability(cost.resourceType[i], cost.amount, cost.buildingType))
                {
                    return false;
                }
            }
           
        }
        Debug.Log("Finnaly Uspex");
        return true;
    }
    private bool CheckResourceAvailability(ResourceType resourceType, int requiredAmount, BuildingType type)
    {
        if (type == BuildingType.House)
        {
            int resourcesToRemove = 0; 
           
            for (int i = 0; i < _inventory.resources.Count; i++)
            {
                if (isIron() && isBrick())
                {
                    resourcesToRemove++;
                    if (resourcesToRemove >= requiredAmount)
                    {
                        break; 
                    }
                }
            }
            if (resourcesToRemove >= requiredAmount)
            {
                _inventory.resources.RemoveRange(0, requiredAmount);
                return true;
            }
        }
        return false;
    }
    private bool isBrick()
    {
        for (int i = 0; i < _inventory.resources.Count; i++)
        {
            if (_inventory.resources[i].Type == ResourceType.Brick)
            {
                return true;
            }
        }
        return false;
    }
    private bool isIron()
    {
        for (int i = 0; i < _inventory.resources.Count; i++)
        {
            if (_inventory.resources[i].Type == ResourceType.Iron)
            {
                return true;
            }
        }
        return false;
    }
    private bool isCuprum()
    {
        for (int i = 0; i < _inventory.resources.Count; i++)
        {
            if (_inventory.resources[i].Type == ResourceType.Copper)
            {
                return true;
            }
        }
        return false;
    }
    private bool isDural()
    {
        for (int i = 0; i < _inventory.resources.Count; i++)
        {
            if (_inventory.resources[i].Type == ResourceType.Dural)
            {
                return true;
            }
        }
        return false;
    }
}
