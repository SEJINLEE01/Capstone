using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class NaF : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    void Start()
    {
        MaxHp = 42;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 2; // ���շ�(���ݷ�)
        attack_turn = 3; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
    private void Update()
    {
        cohesionTxt.text = "���ݷ�: " + cohesion;
    }
}
