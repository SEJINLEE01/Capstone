using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCombineData : MonoBehaviour
{
    private string MolculeName; // 분자 이름 H2O, CH4 ...

    public List<RequiredElement> requiredElements; // 필요한 원자와 개수

    public class RequiredElement
    {
        public string symbol; // 필요한 원소의 symbol (예: "H", "O", "C")
        public int count; // 필요한 개수
    }

    // 생성자 추가 (편의를 위해)
    public CardCombineData(string name, List<RequiredElement> elements)
    {
        MolculeName = name;
        requiredElements = elements;
    }

}
