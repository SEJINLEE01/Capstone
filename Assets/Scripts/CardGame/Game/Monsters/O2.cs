using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class O2 : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    void Start()
    {
        MaxHp = 32;
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
