using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerService : MonoBehaviour
{
    public float initialPowerProduction = 100f; // Начальное производство электроэнергии
    public float powerConsumptionPerHouse = 10f; // Потребление энергии на один дом

    private float currentPowerProduction;
    [SerializeField] private int numberOfHouses;

    public int NubmerOfHousePlus()
    {
        return numberOfHouses++;
    }
    public int NubmerOfHouseMinus()
    {
        return numberOfHouses--;
    }
    private void Start()
    {
        currentPowerProduction = initialPowerProduction;
        numberOfHouses = 0; // Начальное количество домов
    }

    private  void Update()
    {
        // Пример: увеличиваем производство энергии с течением времени (можете изменить логику)
        currentPowerProduction += Time.deltaTime * 10f;
       
        // Пример: проверяем, достаточно ли энергии для домов
        if (currentPowerProduction >= powerConsumptionPerHouse * numberOfHouses)
        {
            // Все дома имеют достаточно энергии
        }
        else
        {
            // Недостаточно энергии, возможно, нужно ввести штрафы или ограничения
        }
    }

}


