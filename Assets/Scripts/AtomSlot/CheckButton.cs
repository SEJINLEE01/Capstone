using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckButton : MonoBehaviour
{
    public AtomSlot leftSlot;
    public AtomSlot rightSlot;
    public GameObject[] LeftUI;
    public GameObject[] RightUI;
    public GameObject[] CorrectUI;
    //Reaction.cs라는 스크립트 있음
    public List<Reaction> reactions = new List<Reaction>()
    {
        // 2H2 + O2 → 2H2O
        new Reaction(new Dictionary<string, int> { { "H2", 2 }, { "O2", 1 } }, new Dictionary<string, int> { { "H2O", 2 } }),

        // C + O2 → CO2
        new Reaction(new Dictionary<string, int> { { "C", 1 }, { "O2", 1 } }, new Dictionary<string, int> { { "CO2", 1 } }),

        // 2Na + Cl2 → 2NaCl
        new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "Cl2", 1 } }, new Dictionary<string, int> { { "NaCl", 2 } }),

        // 2Mg + O2 → 2MgO
        new Reaction(new Dictionary<string, int> { { "Mg", 2 }, { "O2", 1 } }, new Dictionary<string, int> { { "MgO", 2 } }),

        // Si + O2 → SiO2
        new Reaction(new Dictionary<string, int> { { "Si", 1 }, { "O2", 1 } }, new Dictionary<string, int> {  { "SiO2", 1 } }),

        // CH4 + 2O2 → CO2 + 2H2O
        new Reaction(new Dictionary<string, int> { { "CH4", 1 },{"O2",2 } }, new Dictionary<string, int> { { "CO2", 1 },  { "H2O", 2 } }),

        // 2Al + 3Cl2 → 2AlCl3
        new Reaction(new Dictionary<string, int> { { "Al", 2 }, { "Cl2", 3 } }, new Dictionary<string, int> { { "AlCl3", 2 }}),

        // H2 + Cl2 → 2HCl
        new Reaction(new Dictionary<string, int> { { "H2", 1 }, { "Cl2", 1 } }, new Dictionary<string, int> { { "HCl", 2 } }),

        // 2Li + Cl2 → 2LiCl
        new Reaction(new Dictionary<string, int> { { "Li", 2 }, { "Cl2", 1} }, new Dictionary<string, int> { { "LiCl", 2 } }),

        // 2Na + F2 → 2NaF
        new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "F2", 1 } }, new Dictionary<string, int> { { "NaF", 2 } }),

        // Ca + F2 → CaF2
        new Reaction(new Dictionary<string, int> { { "Ca", 1 }, { "F2", 1} }, new Dictionary<string, int> { { "CaF2", 1 }}),
    };


    // 버튼 눌렀을 때 호출
    public void RunReactionCheck()
    {
        var leftAtoms = leftSlot.GetAtomCount();
        var rightAtoms = rightSlot.GetAtomCount();

        foreach (var reaction in reactions)
        {
            if (Match(leftAtoms, reaction.atomInput) && Match(rightAtoms, reaction.atomOutput))
            {
                leftSlot.SetCorrectColor();
                rightSlot.SetCorrectColor();
                foreach (GameObject UI in LeftUI)
                {
                    UI.SetActive(true);
                }
                foreach (GameObject UI in RightUI)
                {
                    UI.SetActive(true);
                }
                foreach (GameObject UI in CorrectUI)
                {
                    UI.SetActive(true);
                }
                return;
            }
            else if (Match(leftAtoms, reaction.atomInput))
            {
                foreach (GameObject UI in LeftUI)
                {
                    UI.SetActive(true);
                }
                foreach (GameObject UI in RightUI)
                {
                    UI.SetActive(false);
                }
                foreach (GameObject UI in CorrectUI)
                {
                    UI.SetActive(false);
                }
                leftSlot.SetCorrectColor();
                rightSlot.SetWrongColor();

                return;
            }
            else if (Match(rightAtoms, reaction.atomOutput))
            {
                leftSlot.SetWrongColor();
                rightSlot.SetCorrectColor();
                foreach (GameObject UI in LeftUI)
                {
                    UI.SetActive(false);
                }
                foreach (GameObject UI in RightUI)
                {
                    UI.SetActive(true);
                }
                foreach (GameObject UI in CorrectUI)
                {
                    UI.SetActive(false);
                }
                return;
            }

        }


        leftSlot.SetWrongColor();
        rightSlot.SetWrongColor();
        foreach (GameObject UI in LeftUI)
        {
            UI.SetActive(false);
        }
        foreach (GameObject UI in RightUI)
        {
            UI.SetActive(false);
        }
        foreach (GameObject UI in CorrectUI)
        {
            UI.SetActive(false);
        }
    }


    // 실제 검사대 위에 올린 원자 수 (actual)와 정답 반응식 요구량 (expected)이 일치하는지 검사
    private bool Match(Dictionary<string, int> actual, Dictionary<string, int> expected)
    {
        if (actual.Count != expected.Count) return false;

        foreach (var kv in expected)
        {
            if (!actual.ContainsKey(kv.Key) || actual[kv.Key] != kv.Value)
                return false;
        }

        return true;
    }
}

