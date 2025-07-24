using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class H2O : GameMonster
{
    public TextMeshProUGUI cohesionTxt;
    void Start()
    {
        MaxHp = 18;
        molecular_mass = MaxHp; // 분자량(체력)
        cohesion = 1; // 결합력(공격력)
        attack_turn = 2; // 공격까지 몇턴 기다리는가 
        turn = 0;
    }
    private void Update()
    {
        cohesionTxt.text = "공격력: " + cohesion;
    }

    // + 애만가지는 고유한 무언가 
}