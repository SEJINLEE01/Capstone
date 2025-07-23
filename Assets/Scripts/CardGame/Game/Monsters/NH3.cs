using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NH3 : GameMonster
{
    void Start()
    {
        MaxHp = 17;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 3; // 결합력(공격력)
        attack_turn = 1; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
}
