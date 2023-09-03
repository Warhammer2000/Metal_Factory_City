using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public static Build Instance;

    public Material matCanBuilded;
    public Material matCantBuilded;
    public Material matBuilded;

    public Renderer render;
    public BuildingBrain brain; 
    private void Awake()
    {
        Instance = this;
        render = GetComponent<Renderer>();  
        GetMaterial();
         
    }
    private void GetMaterial()
    {
        matCanBuilded = Resources.Load<Material>("MaterailToLoad/MatCanBuilded");
        matCantBuilded = Resources.Load<Material>("MaterailToLoad/MatCantBuilded");
        matBuilded = Resources.Load<Material>("MaterailToLoad/MatBuilded");
    }
    private void OnMouseDown()
    {
        if (BuildingPlacement.instance.pushed)
        {
            Vector3 thistransform = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Instantiate(brain.buildingPrices.data[0].prefab, thistransform, Quaternion.identity);
            render.material = matBuilded;
        }
        else render.material = matCantBuilded;
        
    }
}
