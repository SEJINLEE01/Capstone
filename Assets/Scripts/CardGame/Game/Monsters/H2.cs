using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class H2 : GameMonster
{
    void Start()
    {
        MaxHp = 2;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 1; // ���շ�(���ݷ�)
        attack_turn = 1; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
}
