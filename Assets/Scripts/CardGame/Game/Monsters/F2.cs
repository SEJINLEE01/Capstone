using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class F2 : GameMonster
{
    void Start()
    {
        MaxHp = 38;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 1; // ���շ�(���ݷ�)
        attack_turn = 1; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
}
