using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Oculus.Interaction.Context;

public class CombineManage : MonoBehaviour
{
    private List<CardCombineData> allCompounds = new List<CardCombineData>();

    public static CombineManage combineManage { get; private set; } // 싱글톤

    void Start()
    {
        if (combineManage == null)
            combineManage = this;
        else
            Destroy(gameObject);
        // 게임 시작 시, 모든 조합 데이터를 리스트에 추가합니다.
        InitializeCombinations();
    }

    private void InitializeCombinations()
    {
        // H2O
        allCompounds.Add(new CardCombineData("H2O", 
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "H", count = 2 },
                new CardCombineData.RequiredElement { symbol = "O", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("CH4",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "C", count = 1 },
                new CardCombineData.RequiredElement { symbol = "H", count = 4 }
            }
        ));

        allCompounds.Add(new CardCombineData("Cl2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Cl", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("AlCl3",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Al", count = 1 },
                new CardCombineData.RequiredElement { symbol = "Cl", count = 3 }
            }
        ));

        allCompounds.Add(new CardCombineData("CaF2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Ca", count = 1 },
                new CardCombineData.RequiredElement { symbol = "F", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("CO2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "C", count = 1 },
                new CardCombineData.RequiredElement { symbol = "O", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("F2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "F", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("H2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "H", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("HCl",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "H", count = 1 },
                new CardCombineData.RequiredElement { symbol = "Cl", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("LiCl",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Li", count = 1 },
                new CardCombineData.RequiredElement { symbol = "Cl", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("MgO",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Mg", count = 1 },
                new CardCombineData.RequiredElement { symbol = "O", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("N2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "N", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("NaCl",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Na", count = 1 },
                new CardCombineData.RequiredElement { symbol = "Cl", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("NaF",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Na", count = 1 },
                new CardCombineData.RequiredElement { symbol = "F", count = 1 }
            }
        ));

        allCompounds.Add(new CardCombineData("NH3",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "N", count = 1 },
                new CardCombineData.RequiredElement { symbol = "H", count = 3 }
            }
        ));

        allCompounds.Add(new CardCombineData("O2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "O", count = 2 }
            }
        ));

        allCompounds.Add(new CardCombineData("SiO2",
            new List<CardCombineData.RequiredElement>
            {
                new CardCombineData.RequiredElement { symbol = "Si", count = 1 },
                new CardCombineData.RequiredElement { symbol = "O", count = 2 }
            }
        ));
    } // 리스트에 모든 카드조합을 입력

    public bool CheckPossibleCombinations(List<GameObject> SettingCard) // 조합되는 세팅인가를 확인하는 함수
    {
        // 1. 플레이어 손패에 있는 카드의 심볼별 개수를 센다.
        Dictionary<string, int> playerCardSymbolCounts = new Dictionary<string, int>();
        foreach (GameObject card in SettingCard)
        {
            string symbol = card.GetComponent<GameCard>().GetSymbol();
            if (playerCardSymbolCounts.ContainsKey(symbol))
            {
                playerCardSymbolCounts[symbol]++;
            }
            else
            {
                playerCardSymbolCounts.Add(symbol, 1);
            }
        }

        // 2. 모든 가능한 조합 데이터를 순회하며 만들 수 있는지 확인한다.
        // combinationManager를 통해 모든 조합 데이터에 접근합니다.
        foreach (CardCombineData compoundData in allCompounds)
        {
            bool canFormCompound = true;
            foreach (CardCombineData.RequiredElement requiredElement in compoundData.requiredElements)
            {
                // 필요한 원소 심볼이 플레이어 손패에 없거나, 개수가 다르면
                if (!playerCardSymbolCounts.ContainsKey(requiredElement.symbol) ||
                    playerCardSymbolCounts[requiredElement.symbol] != requiredElement.count)
                {
                    canFormCompound = false;
                    break;
                }
            }

            if (canFormCompound) // 위의 if문에 들어가지 않았다는 말은 조합이 가능하다는 소리
            {
                return true; // 조합가능하다고 판별
            }
        }

        return false; // 모든조합에 부합하지 않다고 판별
    }

    
}
