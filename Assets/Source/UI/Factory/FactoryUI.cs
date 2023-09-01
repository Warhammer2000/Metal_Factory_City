using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour
{
    [SerializeField] private ResourceFactory ironFactory;
    [SerializeField] private Text ironCount;
    private void Awake()
    {
        ironFactory = GetComponentInParent<ResourceFactory>();    
        ironCount = transform.GetChild(0).GetChild(1).GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        if (ironCount != null)
        {
            ironCount.text = $" Железа : {ironFactory.resources.Count} / {ironFactory.resources.Count}";
        }
    }
}
