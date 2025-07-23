using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class H2 : GameMonster
{
    void Start()
    {
        MaxHp = 2;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 1; // 결합력(공격력)
        attack_turn = 1; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
}
