using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class DropResourcesInFactory : MonoBehaviour
{
    [SerializeField] private Factory cuprumFactory;
    [SerializeField] private Factory duralFactory;
    private Inventory inventory;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    public void DropResources()
    {
        if (cuprumFactory != null && duralFactory != null)
        {
           
            
                if (cuprumFactory.isCopperFactory == true && ChekingResourcesType())
                {
                    foreach (var resource in inventory.Resources)
                    {
                        if (resource.Type == ResourceType.Iron)
                        {
                            if (IsIronResource(resource))
                            {
                               cuprumFactory.Inventory.AddResource(resource);
                                Debug.Log("Copper" + resource.name);
                            }
                            
                        }
                    }
                   
                }
                if (duralFactory.isDuralFactory)
                {
                    foreach (var resource in inventory.Resources)
                    {
                        if(resource.Type != ResourceType.Dural)
                        {
                            if (IsIronResource(resource) || IsCuprumResource(resource))
                            {
                                duralFactory.Inventory.AddResource(resource);
                                Debug.Log("Dural" + resource.name);
                            }
                        }
                    }
                    inventory.resources.RemoveAll(IsCuprumResource);
                }
        }
            inventory.resources.RemoveAll(IsIronResource);
    }
    private bool IsIronResource(ResourceData resource)
    {
        return resource.Type == ResourceType.Iron;
    }
    private bool IsCuprumResource(ResourceData resource)
    {
        return resource.Type == ResourceType.Copper;
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
