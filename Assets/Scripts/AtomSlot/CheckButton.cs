using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckButton : MonoBehaviour
{
    public AtomSlot leftSlot;
    public AtomSlot rightSlot;

   //Reaction.cs라는 스크립트 있음
    public List<Reaction> reactions = new List<Reaction>()
    {
        // 2H2 + O2 → 2H2O
        new Reaction(new Dictionary<string, int> { { "H", 4 }, { "O", 2 } }, new Dictionary<string, int> { { "H", 4 }, { "O", 2 } }),

        // C + O2 → CO2
        new Reaction(new Dictionary<string, int> { { "C", 1 }, { "O", 2 } }, new Dictionary<string, int> { { "C", 1 }, { "O", 2 } }),

        // 2Na + Cl2 → 2NaCl
        new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "Cl", 2 } }, new Dictionary<string, int> { { "Na", 2 }, { "Cl", 2 } }),

        // 2Mg + O2 → 2MgO
        new Reaction(new Dictionary<string, int> { { "Mg", 2 }, { "O", 2 } }, new Dictionary<string, int> { { "Mg", 2 }, { "O", 2 } }),

        // Si + O2 → SiO2
        new Reaction(new Dictionary<string, int> { { "Si", 1 }, { "O", 2 } }, new Dictionary<string, int> { { "Si", 1 }, { "O", 2 } }),

        // CH4 + 2O2 → CO2 + 2H2O
        new Reaction(new Dictionary<string, int> { { "C", 1 }, { "H", 4 }, { "O", 4 } }, new Dictionary<string, int> { { "C", 1 }, { "H", 4 }, { "O", 4 } }),

        // 2Al + 3Cl2 → 2AlCl3
        new Reaction(new Dictionary<string, int> { { "Al", 2 }, { "Cl", 6 } }, new Dictionary<string, int> { { "Al", 2 }, { "Cl", 6 } }),

        // H2 + Cl2 → 2HCl
        new Reaction(new Dictionary<string, int> { { "H", 2 }, { "Cl", 2 } }, new Dictionary<string, int> { { "H", 2 }, { "Cl", 2 } }),

        // 2Li + Cl2 → 2LiCl
        new Reaction(new Dictionary<string, int> { { "Li", 2 }, { "Cl", 2 } }, new Dictionary<string, int> { { "Li", 2 }, { "Cl", 2 } }),

        // 2Na + F2 → 2NaF
        new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "F", 2 } }, new Dictionary<string, int> { { "Na", 2 }, { "F", 2 } }),

        // Ca + F2 → CaF2
        new Reaction(new Dictionary<string, int> { { "Ca", 1 }, { "F", 2 } }, new Dictionary<string, int> { { "Ca", 1 }, { "F", 2 } }),
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
                Debug.Log("정답");
                leftSlot.SetCorrectColor();
                rightSlot.SetCorrectColor();
                return;
            }
        }

        Debug.Log("오답");
        leftSlot.SetWrongColor();
        rightSlot.SetWrongColor();
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

