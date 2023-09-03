using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour
{
    [SerializeField] private ResourceFactory ironFactory;
    [SerializeField] private ResourceFactory BrickFactory;
    [Space(20)]
    [SerializeField] private Text ironCount;
    [SerializeField] private Text brickCount;

    public bool isIronFactory, isBrickFactory;
    private void Awake()
    {
        if (isIronFactory)
        {
            ironFactory = GetComponentInParent<ResourceFactory>();
            ironCount = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        }
        else
        {
            BrickFactory = GetComponentInParent<ResourceFactory>();
            brickCount = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        }
        
    }
    private void FixedUpdate()
    {
        if (ironCount != null)
        {
            ironCount.text = $" Железа : {ironFactory.resources.Count} / {ironFactory.resources.Count}";
        }
        if(brickCount != null)
        {
            brickCount.text = $" Кирпичей : {BrickFactory.resources.Count} / {BrickFactory.resources.Count}";
        }
    }
}
