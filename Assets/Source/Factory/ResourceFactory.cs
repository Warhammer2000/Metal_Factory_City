using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class ResourceFactory : MonoBehaviour
{
    public float generationInterval = 5f; 
    private int maxResourcesOnPlatform = 10000;
    public List<ResourceData> resources = new List<ResourceData>();
    [SerializeField] private ResourceData data;
    private float timer = 0f;
    private FactoryInventory inventory;
    public int currentResourcesOnPlatform = 0;
    public bool isStarterFactory;
    private void Awake()
    {
        inventory = GetComponent<FactoryInventory>();   
    }
    

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= generationInterval)
        {
            GenerateResources(); 
            timer = 0f; 
        }
        if(resources.Count >= 25)
        {
            resources.RemoveAt(10);
        }
    }
    public void GenereteAnotherOne(List<ResourceData> _resources)
    {
        if (!isStarterFactory)
        {
            int maxResourcesToAdd = Mathf.Min(inventory.resources.Count, _resources.Count);
            Debug.Log(maxResourcesToAdd);
            for (int i = 0; i < maxResourcesToAdd; i++)
            {
                resources.Add(data);
            }

            if (maxResourcesToAdd < resources.Count)
            {
                Debug.Log("превышен предел ресурсов в инвентаре завода");
            }
        }

    }
    public void GenerateResources()
    {
        if(isStarterFactory)
        {
            if (currentResourcesOnPlatform >= maxResourcesOnPlatform) return;
            resources.Add(data);
        }
       
        currentResourcesOnPlatform++;
    }
}
