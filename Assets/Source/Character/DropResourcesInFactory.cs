using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class DropResourcesInFactory : MonoBehaviour
{
    [SerializeField] private Factory[] currentFactory;
    private Inventory inventory;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    public void DropResources()
    {
        if (currentFactory != null)
        {
            for(int i = 0; i < currentFactory.Length; i++)
            {
                if (currentFactory[i].isCopperFactory == true && ChekingResourcesType())
                {
                    foreach (var resource in inventory.Resources)
                    {
                        if (resource.Type == ResourceType.Iron)
                        {
                            if (IsIronResource(resource))
                            {
                                currentFactory[i].Inventory.AddResource(resource);
                                Debug.Log("Copper" + resource.name);
                            }
                            
                        }
                    }
                }
                if (currentFactory[i].isDuralFactory)
                {
                    foreach (var resource in inventory.Resources)
                    {
                        if(resource.Type != ResourceType.Dural)
                        {
                            if (IsIronResource(resource))
                            {
                                currentFactory[i].Inventory.AddResource(resource);
                                Debug.Log("Dural" + resource.name);
                            }
                        }
                    }     
                }
            }
            inventory.resources.RemoveAll(IsIronResource);
        }
    }
    bool IsIronResource(ResourceData resource)
    {
        return resource.Type == ResourceType.Iron;
    }
    private bool ChekingResourcesType()
    {
        for(int i = 0; i < inventory.resources.Count; i++)
        {
            if (inventory.resources[i].Type == ResourceType.Iron)
            return true;
        }
        return false;
    }
}
