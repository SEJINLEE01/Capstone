using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : GameCard
{
    void Start()
    {
        atomic_mass = 12;
        symbol = "C";
        isNobleGas = false;
    }

    public override int CalculateCombinedAttackPower() // 조합됐을경우
    {
        MoreDraw();
        return atomic_mass; // 조합된경우에는 모든 카드가 그대로의 원자량으로 공격
    }

    public void MoreDraw()
    {
        MyDraw.Instance.Draw(); // 추가 1드로우
    }
}
