using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class NaF : GameMonster
{
    public TextMeshProUGUI turnTxt;
    public TextMeshProUGUI cohesionTxt;
    void Start()
    {
        MaxHp = 42;
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
