using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerService : MonoBehaviour
{
    public float initialPowerProduction = 100f; // ��������� ������������ ��������������
    public float powerConsumptionPerHouse = 10f; // ����������� ������� �� ���� ���

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
        numberOfHouses = 0; // ��������� ���������� �����
    }

    private  void Update()
    {
        // ������: ����������� ������������ ������� � �������� ������� (������ �������� ������)
        currentPowerProduction += Time.deltaTime * 10f;
       
        // ������: ���������, ���������� �� ������� ��� �����
        if (currentPowerProduction >= powerConsumptionPerHouse * numberOfHouses)
        {
            // ��� ���� ����� ���������� �������
        }
        else
        {
            // ������������ �������, ��������, ����� ������ ������ ��� �����������
        }
    }

}


