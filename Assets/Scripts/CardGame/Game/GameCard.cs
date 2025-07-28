using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCard : MonoBehaviour
{
    protected int atomic_mass; // 원자량
    protected string symbol; // 원자이름
    protected bool isNobleGas; // 비활성기체인가?

    public string GetSymbol()
    {
        return symbol;
    }

    public int CalculateAttackPower() //단일로 냈을경우
    {
        if (atomic_mass == 1) return 1; //수소는 그냥 1
        return isNobleGas ? atomic_mass : Mathf.RoundToInt(atomic_mass / 2f); // 비활성기체면 그대로 아니면 절반
    }

    public virtual int CalculateCombinedAttackPower() // 조합됐을경우
    {
        return atomic_mass; // 조합된경우에는 모든 카드가 그대로의 원자량으로 공격
    }
}
