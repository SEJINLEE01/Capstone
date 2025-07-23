using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class AlCl3 : GameMonster
{
    void Start()
    {
        MaxHp = 135;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 2; // 결합력(공격력)
        attack_turn = 3; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
    // + 애만가지는 고유한 무언가 
}