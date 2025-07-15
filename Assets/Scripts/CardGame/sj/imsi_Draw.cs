using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imsi_Draw : MonoBehaviour
{
    private List<string> Deck = new List<string>();
    private int TotalCardCount;

    void Start(){
        InitializeDeck();
    }
    public void InitializeDeck(){
        Deck.Clear();
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
    }

    private void AddCardsToDeck(string symbol, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Deck.Add(symbol);
        }
    }

    public string Draw(){
        if (Deck.Count == 0)
        {
            Debug.Log("덱에 더 이상 카드가 없습니다.");
            return null;
        }
        int randomIndex = Random.Range(0, Deck.Count); 
        string drawnCard = Deck[randomIndex]; 
        Deck.RemoveAt(randomIndex); 
        TotalCardCount--;
        Debug.Log($"'{drawnCard}' 카드를 드로우했습니다. 남은 카드: {Deck.Count}장.");
        return drawnCard;
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
