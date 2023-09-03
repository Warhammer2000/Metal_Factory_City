using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    public static BuildingPlacement instance;
    private BuildingBrain _brain;
    public bool pushed;
  
    private void Start()
    {
        instance = this;
        _brain = GetComponent<BuildingBrain>();
    }
    public void PCBUILDING()
    {
         if (_brain.CanBuildBuilding(_brain.buildingPrices))
         {
            Build.Instance.render.material = Build.Instance.matCanBuilded;
            pushed = true;
         }
         else
         {
            Debug.LogWarning("Ты не можешь купить здание");          
         } 
    }
}
