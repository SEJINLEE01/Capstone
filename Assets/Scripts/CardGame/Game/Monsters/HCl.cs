using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class HCl : GameMonster
{
    void Start()
    {
        MaxHp = 37;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 2; // 결합력(공격력)
        attack_turn = 2; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
}
