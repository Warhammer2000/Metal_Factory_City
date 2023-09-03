using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    public static GameObject selectedTowerToBuy;
    public static BuildingPlacement instance;
    private BuildingBrain _brain;
    public bool pushed;
  
    private void Start()
    {
        instance = this;
        _brain = GetComponent<BuildingBrain>();
    }
    public void PCBUILDING(int index)
    {
         if (_brain.CanBuildBuilding(_brain.buildingPrices))
         {
             switch(index)
            {
                case 0: selectedTowerToBuy = _brain.buildingPrices.data[0].prefab; break;
            }
         }
         else
         {
            Debug.LogWarning("Ты не можешь купить здание");          
         } 
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            selectedTowerToBuy = null;
        }
    }
}
