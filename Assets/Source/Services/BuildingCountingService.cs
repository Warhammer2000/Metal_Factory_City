using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCountingService : MonoBehaviour
{
    [field : SerializeField] public  int index { get; set; }

    private void FixedUpdate()
    {
        if(index >= 20)
        {
            Debug.Log("You can open new map");
        }
    }

}
