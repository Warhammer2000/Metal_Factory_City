using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Text NeedIron;
    [SerializeField] private Text NeedCoprum;
    [SerializeField] private Text NeedDural;
    [SerializeField] private Text NeedBrick;
    
  
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        IntializeText();
    }
    private void IntializeText()
    {
       NeedIron.text = "������ : ";
       NeedCoprum.text = "���� : ";
       NeedDural.text = "�������� : ";
       NeedBrick.text = "������� : ";
    }

    private void Update()
    {
        GetResource();
    }
  
    private void GetResource()
    {
        int ironCount = 0;
        int CopperCount = 0;
        int DuralCount = 0;
        int BrickCount = 0;

        for (int i = 0; i < inventory.resources.Count; i++)
        {
            if (inventory.resources[i].Type == ResourceType.Iron)
            {
                ironCount += inventory.resources[i].Amount;
            }
            if (inventory.resources[i].Type == ResourceType.Brick)
            {
                BrickCount += inventory.resources[i].Amount;
            }
            if (inventory.resources[i].Type == ResourceType.Copper)
            {
                CopperCount += inventory.resources[i].Amount;
            }
        }
        for(int i = 0; i < inventory.resourceDural.Count; i++)
        {
            if (inventory.resourceDural[i].Type == ResourceType.Dural)
            {
                DuralCount += inventory.resourceDural[i].Amount;
            }
        }

        NeedIron.text = $"������ : {ironCount} / {ironCount}";
        NeedCoprum.text = $"���� :{CopperCount} / {CopperCount}";
        NeedDural.text = $"�������� :{DuralCount} / {DuralCount}";
        NeedBrick.text = $"������� :{BrickCount} / {BrickCount}";
      
    }
}
