using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H : GameCard
{
    void Start()
    {
        // 수소(H)의 속성들을 설정합니다.
        atomic_mass = 1;
        symbol = "H";
        isNobleGas = false; // 수소는 비활성 기체가 아님
    }
        // + 추가될 함수 변수
}
