using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Cl2 : GameMonster
{
    void Start()
    {
        MaxHp = 72;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 2; // ���շ�(���ݷ�)
        attack_turn = 2; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
}
