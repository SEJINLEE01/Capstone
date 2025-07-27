using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Oculus.Interaction.Context;

public class CombineManage : MonoBehaviour
{
    private List<CardCombineData> allCompounds = new List<CardCombineData>();

    public static CombineManage combineManage { get; private set; } // �̱���

    void Start()
    {
        if (combineManage == null)
            combineManage = this;
        else
            Destroy(gameObject);
        // ���� ���� ��, ��� ���� �����͸� ����Ʈ�� �߰��մϴ�.
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
    } // ����Ʈ�� ��� ī�������� �Է�

    public bool CheckPossibleCombinations(List<GameObject> SettingCard) // ���յǴ� �����ΰ��� Ȯ���ϴ� �Լ�
    {
        // 1. �÷��̾� ���п� �ִ� ī���� �ɺ��� ������ ����.
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

        // 2. ��� ������ ���� �����͸� ��ȸ�ϸ� ���� �� �ִ��� Ȯ���Ѵ�.
        // combinationManager�� ���� ��� ���� �����Ϳ� �����մϴ�.
        foreach (CardCombineData compoundData in allCompounds)
        {
            bool canFormCompound = true;
            foreach (CardCombineData.RequiredElement requiredElement in compoundData.requiredElements)
            {
                // �ʿ��� ���� �ɺ��� �÷��̾� ���п� ���ų�, ������ �ٸ���
                if (!playerCardSymbolCounts.ContainsKey(requiredElement.symbol) ||
                    playerCardSymbolCounts[requiredElement.symbol] != requiredElement.count)
                {
                    canFormCompound = false;
                    break;
                }
            }

            if (canFormCompound) // ���� if���� ���� �ʾҴٴ� ���� ������ �����ϴٴ� �Ҹ�
            {
                return true; // ���հ����ϴٰ� �Ǻ�
            }
        }

        return false; // ������տ� �������� �ʴٰ� �Ǻ�
    }

    
}
