using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildTime : MonoBehaviour
{

    [Inject] private PowerService powerService;


    [SerializeField] private BuildingCountingService buildingService;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private  Image timer;
    [SerializeField] private float HouseTime = 10f;
    [SerializeField] private GameObject BuildingObject;
    [SerializeField] private Build build;
    private bool isActive = false;

  
    private void OnValidate()
    {
        if(HouseTime <= 0) HouseTime = 0;
    }
    private void Awake()
    {
        buildingService = GameObject.Find("BuildingCountService").GetComponent<BuildingCountingService>();
        timer = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();

        Canvas = transform.GetChild(0).GetChild(0).gameObject;
        Button = transform.GetChild(0).GetChild(1).gameObject;
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
    private void OnMouseDown()
    {
        isActive = !isActive;
        Button.SetActive(isActive);
    }
    public void DestroyBuilding()
    {
        build.isBuilded = false;
        powerService.NubmerOfHouseMinus();
        buildingService.DecreaseIndex();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Platform")
        {
            build = other.gameObject.GetComponent<Build>();
        }
    }
}