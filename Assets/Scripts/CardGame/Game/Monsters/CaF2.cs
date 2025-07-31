using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class CaF2 : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    public TextMeshProUGUI turnTxt;
    void Start()
    {
        MaxHp = 78;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 2; // ���շ�(���ݷ�)
        attack_turn = 2; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
        turnUI = attack_turn;
    }
    private void Update()
    {
        cohesionTxt.text = "���ݷ�: " + cohesion;
        turnTxt.text = turnUI + " �� �� ����";
    }
}
