using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class O2 : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    public TextMeshProUGUI turnTxt;
    void Start()
    {
        MaxHp = 32;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 1; // ���շ�(���ݷ�)
        attack_turn = 1; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
        turnUI = attack_turn;
    }
    private void Update()
    {
        cohesionTxt.text = "���ݷ�: " + cohesion;
        turnTxt.text = turnUI + " �� �� ����";
    }
}
