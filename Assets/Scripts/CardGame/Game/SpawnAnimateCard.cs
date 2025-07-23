using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using static Oculus.Interaction.Context;

public class SpawnAnimateCard : MonoBehaviour
{
    public List<CardPrefab> cardPrefabs; // �ִϸ��̼� ī�� ���� ������
    private Queue<System.Action> functionQueue = new Queue<System.Action>(); // �׼��� ���� ť
    public static SpawnAnimateCard AnimateCard { get; private set; } // �̱���
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
        functionQueue.Enqueue(() => SpawnCard(symbol)); // SpawnCard�� ť�� �߰�
        if (!isProcessingQueue)
        {
            StartCoroutine(ProcessFunctionQueue());
        }
    }

    private void SpawnCard(string symbol) // ī�带 ��ȯ�ϴ� ����
    {
        GameObject foundPrefab = null;
        CardCount--;

        // cardPrefabs ����Ʈ�� ��ȸ�ϸ� symbol�� �´� �������� ã���ϴ�.
        foreach (CardPrefab cardData in cardPrefabs)
        {
            if (cardData.symbol == symbol)
            {
                foundPrefab = cardData.prefab;
                break; // ã������ �ݺ� �ߴ�
            }
        }

        if (foundPrefab != null)
        {
            Instantiate(foundPrefab);
        }
        else
        {
            // �ش��ϴ� �������� ���� ��� ���� �޽��� ���
            Debug.LogError($"����: '{symbol}' �ɺ��� �ش��ϴ� ī�� �������� ����Ʈ���� ã�� �� �����ϴ�.");
        }

        if (CardCount == 0) Destroy(DeckPivot);
        else DeckPivot.transform.localScale = new Vector3(1f,1f, (float)CardCount / 60);
    }

    private IEnumerator ProcessFunctionQueue() // 1.8�� ����ϴ� �ڷ�ƾ ����
    {
        isProcessingQueue = true;

        while (functionQueue.Count > 0)
        {
            System.Action nextAction = functionQueue.Dequeue();
            nextAction?.Invoke(); // ���ٽ� ���ο� ĸó�� symbol ���� ����Ͽ� SpawnCard�� ȣ��˴ϴ�.

            yield return new WaitForSeconds(1.8f); // 1.8�� ���
        }

        isProcessingQueue = false;
    }
}
