using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCombineData : MonoBehaviour
{
    private string MolculeName; // ���� �̸� H2O, CH4 ...

    public List<RequiredElement> requiredElements; // �ʿ��� ���ڿ� ����

    public class RequiredElement
    {
        public string symbol; // �ʿ��� ������ symbol (��: "H", "O", "C")
        public int count; // �ʿ��� ����
    }

    // ������ �߰� (���Ǹ� ����)
    public CardCombineData(string name, List<RequiredElement> elements)
    {
        MolculeName = name;
        requiredElements = elements;
    }

}
