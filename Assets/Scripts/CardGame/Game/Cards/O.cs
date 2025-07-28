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

    public override int CalculateCombinedAttackPower() // ���յ������
    {
        Heal();
        return atomic_mass; // ���յȰ�쿡�� ��� ī�尡 �״���� ���ڷ����� ����
    }

    public void Heal() // ��� ���� ���� ȿ��
    {   
        int FullHp = GameManager.Instance.PHp;
        int CurrentHp = GameManager.Instance.Hp;
        Debug.Log($"  - <color=red>����� ����ȿ���� �ߵ��Ǿ����ϴ�.</color>)");
        if (CurrentHp != FullHp) {
            GameManager.Instance.Hp++;
            HP_Update.Instance.UpdateHeartUI(GameManager.Instance.Hp);
        }
    }
}
