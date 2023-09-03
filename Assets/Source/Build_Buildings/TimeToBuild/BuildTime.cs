using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class BuildTime : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private  Image timer;
    [SerializeField] private float HouseTime = 10f;
    [SerializeField] private GameObject BuildingObject;
    private void OnValidate()
    {
        if(HouseTime <= 0) HouseTime = 0;
    }
    private void Awake()
    {
        timer = transform.GetChild(0).GetChild(1).GetComponent<Image>();

        Canvas = transform.GetChild(0).gameObject;
        BuildingObject = transform.GetChild(1).gameObject;

        BuildingObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if(HouseTime >= 0.01f)
        {
            HouseTime -= Time.fixedDeltaTime;
            timer.fillAmount = HouseTime / 10f;
        }
        else
        {
            HouseTime = 0;
        }
        if(HouseTime <= 0f)
        {
            BuildingObject.SetActive(true) ;
            Canvas.SetActive(false);
        }
    }
}