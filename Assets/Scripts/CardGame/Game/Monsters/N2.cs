using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class N2 : GameMonster
{
    void Start()
    {
        MaxHp = 28;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 3; // 결합력(공격력)
        attack_turn = 2; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
}
