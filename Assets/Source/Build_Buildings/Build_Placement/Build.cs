using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Build : MonoBehaviour
{
    public Material matCanBuilded;
    public Material matCantBuilded;
    public Material matBuilded;
    public Material matNotBuilded;

    public Renderer render;
    public BuildingBrain brain;
    private bool isSelected;
    public bool isBuilded;

    [Inject] private BuildingCountingService countingService;

    private void Awake()
    {
        Debug.Log("Check" + countingService);
        render = GetComponent<Renderer>();  
        GetMaterial();
    }
    private void GetMaterial()
    {
        matCanBuilded = Resources.Load<Material>("MaterailToLoad/MatCanBuilded");
        matCantBuilded = Resources.Load<Material>("MaterailToLoad/MatCantBuilded");
        matBuilded = Resources.Load<Material>("MaterailToLoad/MatBuilded");
        matNotBuilded = Resources.Load<Material>("MaterailToLoad/MatNotBuilded 1");
    }
    private void Update()
    {
        if (!isBuilded) Cheker();
    }
    private void OnMouseDown()
    {
        if (BuildingPlacement.selectedTowerToBuy && !isBuilded && isSelected)
        {
            Vector3 thistransform = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Instantiate(BuildingPlacement.selectedTowerToBuy, thistransform, Quaternion.identity);
            render.material = matBuilded;
            countingService.index++;
            isBuilded = true;
        }
        else render.material = matCantBuilded;
    }
    private void OnMouseEnter()
    {
        isSelected = true;
    }
    private void OnMouseExit()
    {
        isSelected = false;
    }
    private void Cheker()
    {
        if (BuildingPlacement.selectedTowerToBuy)
        {
            if (isSelected) render.material = matCanBuilded;
            else render.material = matNotBuilded;
        }
        else render.material = matCantBuilded;

        if (isBuilded) render.material = matBuilded;
    }
}
