using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O : GameCard
{
    void Start()
    {
        atomic_mass = 16;
        symbol = "O";
        isNobleGas = false;
    }

    public override int CalculateCombinedAttackPower() // 조합됐을경우
    {
        Heal();
        return atomic_mass; // 조합된경우에는 모든 카드가 그대로의 원자량으로 공격
    }

    public void Heal() // 산소 고유 조합 효과
    {   
        int FullHp = GameManager.Instance.PHp;
        int CurrentHp = GameManager.Instance.Hp;
        Debug.Log($"  - <color=red>산소의 조합효과가 발동되었습니다.</color>)");
        if (CurrentHp != FullHp) {
            GameManager.Instance.Hp++;
            HP_Update.Instance.UpdateHeartUI(GameManager.Instance.Hp);
        }
    }
}
