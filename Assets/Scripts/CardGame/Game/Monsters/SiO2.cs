using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SiO2 : GameMonster
{
    void Start()
    {
        MaxHp = 60;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 2; // ���շ�(���ݷ�)
        attack_turn = 3; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
}
