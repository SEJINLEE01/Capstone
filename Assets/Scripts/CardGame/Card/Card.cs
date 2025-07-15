using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card Info")]
    public string symbol;//원소 이름
    public int atomicMass;//원자량
    public bool isNobleGas; //비활성 기체
    public int attackPower; //공격력

    // 원소 단일 카드 공격력 계산
    public void CalculateAttackPower(bool asSingle)
    {
        if (asSingle)
            attackPower = isNobleGas ? atomicMass : Mathf.RoundToInt(atomicMass / 2f);
    }

    [System.Serializable]
    public class CardData
    {
        public string symbol;
        public int atomicMass;
        public bool isNobleGas;
        public int maxCount;

        public CardData(string symbol, int atomicMass, bool isNobleGas, int maxCount)
        {
            this.symbol = symbol;
            this.atomicMass = atomicMass;
            this.isNobleGas = isNobleGas;
            this.maxCount = maxCount;
        }
    }

    public static readonly List<CardData> AllCardList = new List<CardData>()
    {
        new CardData("H", 1, false, 6),
        new CardData("He", 4, true, 3),
        new CardData("Li", 7, false, 3),
        new CardData("Be", 9, false, 3),
        new CardData("B", 11, false, 3),
        new CardData("C", 12, false, 3),
        new CardData("N", 14, false, 3),
        new CardData("O", 16, false, 3),
        new CardData("F", 19, false, 3),
        new CardData("Ne", 20, true, 3),
        new CardData("Na", 23, false, 3),
        new CardData("Mg", 24, false, 3),
        new CardData("Al", 27, false, 3),
        new CardData("Si", 28, false, 3),
        new CardData("P", 31, false, 2),
        new CardData("S", 32, false, 2),
        new CardData("Cl", 36, false, 2),
        new CardData("Ar", 40, true, 2),
        new CardData("K", 39, false, 2),
        new CardData("Ca", 40, false, 2),
    };
}
