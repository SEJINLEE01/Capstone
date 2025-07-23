using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using static Oculus.Interaction.Context;

public class SpawnAnimateCard : MonoBehaviour
{
    public List<CardPrefab> cardPrefabs; // 애니메이션 카드 담을 프리팹
    private Queue<System.Action> functionQueue = new Queue<System.Action>(); // 액션을 담을 큐
    public static SpawnAnimateCard AnimateCard { get; private set; } // 싱글톤
    private bool isProcessingQueue = false;

    int CardCount = 60;
    public GameObject DeckPivot;

    [System.Serializable]
    public class CardPrefab
    {
        public string symbol;
        public GameObject prefab;
    }

    void Start()
    {
        if (AnimateCard == null)
            AnimateCard = this;
        else
            Destroy(gameObject);
    }

    public void Request(string symbol)
    {
        functionQueue.Enqueue(() => SpawnCard(symbol)); // SpawnCard를 큐에 추가
        if (!isProcessingQueue)
        {
            StartCoroutine(ProcessFunctionQueue());
        }
    }

    private void SpawnCard(string symbol) // 카드를 소환하는 로직
    {
        GameObject foundPrefab = null;
        CardCount--;

        // cardPrefabs 리스트를 순회하며 symbol에 맞는 프리팹을 찾습니다.
        foreach (CardPrefab cardData in cardPrefabs)
        {
            if (cardData.symbol == symbol)
            {
                foundPrefab = cardData.prefab;
                break; // 찾았으면 반복 중단
            }
        }

        if (foundPrefab != null)
        {
            Instantiate(foundPrefab);
        }
        else
        {
            // 해당하는 프리팹이 없는 경우 오류 메시지 출력
            Debug.LogError($"오류: '{symbol}' 심볼에 해당하는 카드 프리팹을 리스트에서 찾을 수 없습니다.");
        }

        if (CardCount == 0) Destroy(DeckPivot);
        else DeckPivot.transform.localScale = new Vector3(1f,1f, (float)CardCount / 60);
    }

    private IEnumerator ProcessFunctionQueue() // 1.8초 대기하는 코루틴 로직
    {
        isProcessingQueue = true;

        while (functionQueue.Count > 0)
        {
            System.Action nextAction = functionQueue.Dequeue();
            nextAction?.Invoke(); // 람다식 내부에 캡처된 symbol 값을 사용하여 SpawnCard가 호출됩니다.

            yield return new WaitForSeconds(1.8f); // 1.8초 대기
        }

        isProcessingQueue = false;
    }
}
