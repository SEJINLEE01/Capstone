using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyDraw : MonoBehaviour
{
    private List<string> Deck = new List<string>();
    private int TotalCardCount;

    // Draw된 개수 추적용 딕셔너리
    private Dictionary<string, int> drawCounts = new Dictionary<string, int>();

    // 기호와 UI 텍스트를 연결하기 위한 구조체
    [System.Serializable]
    public class CardUI
    {
        public string symbol;
        public TextMeshProUGUI textUI;
    }

    // 인스펙터에서 설정할 UI 리스트
    public List<CardUI> cardUIs;

    // 런타임에 연결되는 사전
    private Dictionary<string, TextMeshProUGUI> cardTextDict = new Dictionary<string, TextMeshProUGUI>();

    void Start()
    {
        // 인스펙터에서 설정한 symbol → Text 연결
        foreach (var item in cardUIs)
        {
            cardTextDict[item.symbol] = item.textUI;
        }

        InitializeDeck();

        for (int i = 0; i < 10; i++)/// 테스트용
        {//////// 테스트
            Draw(); /////// 태ㅅ  스트용
        }///// 테스트용
    }

    public void InitializeDeck()
    {
        Deck.Clear();
        drawCounts.Clear();
        TotalCardCount = 0;

        AddCardsToDeck("H", 6);
        AddCardsToDeck("He", 3);
        AddCardsToDeck("Li", 3);
        AddCardsToDeck("Be", 3);
        AddCardsToDeck("B", 3);
        AddCardsToDeck("C", 4);
        AddCardsToDeck("N", 4);
        AddCardsToDeck("O", 4);
        AddCardsToDeck("F", 3);
        AddCardsToDeck("Ne", 3);
        AddCardsToDeck("Na", 3);
        AddCardsToDeck("Mg", 3);
        AddCardsToDeck("Al", 3);
        AddCardsToDeck("Si", 3);
        AddCardsToDeck("P", 2);
        AddCardsToDeck("S", 2);
        AddCardsToDeck("Cl", 2);
        AddCardsToDeck("Ar", 2);
        AddCardsToDeck("K", 2);
        AddCardsToDeck("Ca", 2);
        TotalCardCount = Deck.Count;

        // 모든 원소에 대해 draw 카운트 0으로 설정 & UI 초기화
        foreach (string symbol in cardTextDict.Keys)
        {
            drawCounts[symbol] = 0;
            UpdateCardText(symbol);
        }
    }

    private void AddCardsToDeck(string symbol, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Deck.Add(symbol);
        }
    }

    public string Draw()
    {
        if (Deck.Count == 0)
        {
            Debug.Log("덱에 더 이상 카드가 없습니다.");
            return null;
        }

        int randomIndex = Random.Range(0, Deck.Count);
        string drawnCard = Deck[randomIndex];
        Deck.RemoveAt(randomIndex);
        TotalCardCount--;

        // Draw된 개수 +1 하고 텍스트 갱신
        if (drawCounts.ContainsKey(drawnCard))
        {
            drawCounts[drawnCard]++;
            UpdateCardText(drawnCard);
        }

        Debug.Log($"드로우된 카드: {drawnCard} 남은 카드: {Deck.Count}장.");
        return drawnCard;
    }

    // UI 갱신 함수 (1개)
    private void UpdateCardText(string symbol)
    {
        if (cardTextDict.ContainsKey(symbol))
        {
            cardTextDict[symbol].text = drawCounts[symbol].ToString();
        }
    }

    public void PrintRemainingDeck()
    {
        if (Deck.Count == 0)
        {
            Debug.Log("덱이 비어 있습니다.");
            return;
        }

        Debug.Log($"현재 덱에 남아있는 카드 ({Deck.Count}장):");
        foreach (string card in Deck)
        {
            Debug.Log($"- {card}");
        }
    }
}
