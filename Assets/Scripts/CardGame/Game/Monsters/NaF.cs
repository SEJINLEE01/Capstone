using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class NaF : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    void Start()
    {
        MaxHp = 42;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 2; // 결합력(공격력)
        attack_turn = 3; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
    private void Update()
    {
        cohesionTxt.text = "공격력: " + cohesion;
    }
}
