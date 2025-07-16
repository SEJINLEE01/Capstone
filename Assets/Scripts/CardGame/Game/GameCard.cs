using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCard : MonoBehaviour
{
    protected int atomic_mass; // 원자량
    protected string symbol; // 원자이름
    protected bool isNobleGas; // 비활성기체인가?

    protected int CalculateAttackPower()
    {
        if (atomic_mass == 1) return 1;
        return isNobleGas ? atomic_mass : Mathf.RoundToInt(atomic_mass / 2f);
    }
}
