using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{

    private Inventory inventory;
    [SerializeField] private ResourceFactory ironFactory;
    [SerializeField] private ResourceFactory CopperFactory;
    [SerializeField] private ResourceFactory DuralFactory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    public void OnPickUpHandler()
    {

         for (int y = 0; y < ironFactory.resources.Count; y++)
         {
                inventory.AddResource(ironFactory.resources[y]);
         }
         ironFactory.resources.Clear();

        for (int y = 0; y < CopperFactory.resources.Count; y++)
        {
            inventory.AddResource(CopperFactory.resources[y]);
        }
        CopperFactory.resources.Clear();

        for (int y = 0; y < DuralFactory.resources.Count; y++)
        {
            inventory.AddResource(DuralFactory.resources[y]);
        }
        DuralFactory.resources.Clear();
    }
}
