using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryInventory : MonoBehaviour
{
    public List<ResourceData> resources;
    private ResourceFactory _resfactory;
    private Factory _factory; 
    private IReadOnlyList<ResourceData> Resources => resources.AsReadOnly();

    
    private void Awake()
    {
        _factory = GetComponent<Factory>();
        resources = new List<ResourceData>(32);
        _resfactory = GetComponent<ResourceFactory>();
    }
   
    public void CheckItems()
    {
        _resfactory.GenereteAnotherOne(resources);
    }
    private void ProduceDural(Factory factory)
    {
        int ironCount = 0;
        int copperCount = 0;

        foreach (var resource in resources)
        {
            if (resource.Type == ResourceType.Iron)
            {
                ironCount++;
            }
            else if (resource.Type == ResourceType.Copper)
            {
                copperCount++;
            }
        }

        if (ironCount >= 10 && copperCount >= 10)
        {
            // Производство Dural
            int duralToProduce = Math.Min(ironCount, copperCount); // Выбираем минимальное количество из ironCount и copperCount
            _resfactory.GenereteAnotherOne(resources);
            StartCoroutine(WaitProduce());
        }
    }
    private IEnumerator WaitProduce()
    {
        yield return new WaitForSeconds(1f);
        Clear();
    }
    public void AddResource(ResourceData data) => resources.Add(data);      
    public void RemoveResource(ResourceData data) => resources.Remove(data);
    public void Clear() => resources.Clear();
}
