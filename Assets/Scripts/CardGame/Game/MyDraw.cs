using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyDraw : MonoBehaviour
{
    private List<string> Deck = new List<string>();
    private int TotalCardCount;

    private Dictionary<string, int> drawCounts = new Dictionary<string, int>();// Draw된 개수 추적용 딕셔너리
    private Dictionary<string, TextMeshProUGUI> cardTextDict = new Dictionary<string, TextMeshProUGUI>(); // 런타임에 연결되는 사전
    public List<CardPrefab> cardPrefabs;
    public List<CardUI> cardUIs; // 인스펙터에서 설정할 UI 리스트
    // 기호와 UI 텍스트를 연결하기 위한 구조체
    [System.Serializable]
    public class CardUI
    {
        public string symbol;
        public TextMeshProUGUI textUI;
    }
    [System.Serializable]
    public class CardPrefab
    {
        public string symbol;
        public GameObject prefab;
    }
    public Transform cardSpawnParent;        // 생성 위치 부모
    public Vector3 spawnOffset = Vector3.zero; // 위치 오프셋

    private float lastDrawButtonClickTime = 0f; // 마지막 클릭 시간 저장
    private const float debounceTime = 0.2f; // 0.2초 내의 중복 클릭 무시

    public static MyDraw Instance { get; private set; } // 싱글톤

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // 인스펙터에서 설정한 symbol → Text 연결
        foreach (var item in cardUIs)
        {
            cardTextDict[item.symbol] = item.textUI;
        }

        InitializeDeck();
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

    public void Pick(string symbol)
    {
        if (Time.time - lastDrawButtonClickTime < debounceTime) //무슨 버그인지 모르겠지만 얘만 두번씩 실행되서 임의로 막음
        {
            //Debug.Log("DrawButton: 디바운스 처리됨 (중복 클릭 무시)"); 
            return;
        }

        lastDrawButtonClickTime = Time.time; // 현재 시간으로 마지막 클릭 시간 업데이트

        if (drawCounts.ContainsKey(symbol) && drawCounts[symbol] > 0)
        {
            drawCounts[symbol]--;      // 수량 감소
            UpdateCardText(symbol);    // UI 업데이트

            // 프리팹 리스트에서 해당 심볼을 찾기
            GameObject prefabToSpawn = null;
            foreach (var card in cardPrefabs)
            {
                if (card.symbol == symbol)
                {
                    prefabToSpawn = card.prefab;
                    break;
                }
            }

            if (prefabToSpawn != null)
            {
                Vector3 spawnPos = cardSpawnParent.position + spawnOffset;
                Instantiate(prefabToSpawn, spawnPos, prefabToSpawn.transform.rotation);
                Debug.Log($"{symbol} 카드 복제됨.");
            }
            else
            {
                Debug.LogWarning($"{symbol} 프리팹을 못 찾았어요!");
            }
        }
        else
        {
            Debug.LogWarning($"{symbol} 카드가 없거나 잘못된 기호예요!");
        }
    }

}
