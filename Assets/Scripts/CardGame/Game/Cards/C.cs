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

    public override int CalculateCombinedAttackPower() // ���յ������
    {
        MoreDraw();
        return atomic_mass; // ���յȰ�쿡�� ��� ī�尡 �״���� ���ڷ����� ����
    }

    public void MoreDraw()
    {
        MyDraw.Instance.Draw(); // �߰� 1��ο�
    }
}
