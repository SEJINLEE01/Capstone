using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NaCl : GameMonster
{
    void Start()
    {
        MaxHp = 59;
        molecular_mass = MaxHp; // ���ڷ�(ü��)
        cohesion = 3; // ���շ�(���ݷ�)
        attack_turn = 2; // ���ݱ��� ���� ��ٸ��°� 
        turn = 0;
    }
}
