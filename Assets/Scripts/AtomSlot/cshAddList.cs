using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAddList : MonoBehaviour
{
    public CheckButton checkButton;
    public List<Reaction> reactions = new List<Reaction>()
    {
        // 2H2 + O2 ¡æ 2H2O
        new Reaction(new Dictionary<string, int> { { "H2", 2 }, { "O2", 1 } }, new Dictionary<string, int> { { "H2O", 4 } }),

            // C + O2 ¡æ CO2
            new Reaction(new Dictionary<string, int> { { "C", 1 }, { "O2", 1 } }, new Dictionary<string, int> { { "CO2", 1 } }),

            // 2Na + Cl2 ¡æ 2NaCl
            new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "Cl2", 1 } }, new Dictionary<string, int> { { "NaCl", 2 } }),

            // 2Mg + O2 ¡æ 2MgO
            new Reaction(new Dictionary<string, int> { { "Mg", 2 }, { "O2", 1 } }, new Dictionary<string, int> { { "MgO", 2 } }),

            // Si + O2 ¡æ SiO2
            new Reaction(new Dictionary<string, int> { { "Si", 1 }, { "O2", 1 } }, new Dictionary<string, int> {  { "SiO2", 1 } }),
            
            // CH4 + 2O2 ¡æ CO2 + 2H2O
            new Reaction(new Dictionary<string, int> { { "CH4", 4 },{"O2",2 } }, new Dictionary<string, int> { { "CO2", 1 },  { "H2O", 2 } }),

            // 2Al + 3Cl2 ¡æ 2AlCl3
            new Reaction(new Dictionary<string, int> { { "Al", 2 }, { "Cl2", 3 } }, new Dictionary<string, int> { { "AlCl3", 2 }}),

            // H2 + Cl2 ¡æ 2HCl
            new Reaction(new Dictionary<string, int> { { "H2", 1 }, { "Cl2", 1 } }, new Dictionary<string, int> { { "HCl", 2 } }),

            // 2Li + Cl2 ¡æ 2LiCl
            new Reaction(new Dictionary<string, int> { { "Li", 2 }, { "Cl2", 1} }, new Dictionary<string, int> { { "LiCl", 2 } }),

            // 2Na + F2 ¡æ 2NaF
            new Reaction(new Dictionary<string, int> { { "Na", 2 }, { "F2", 1 } }, new Dictionary<string, int> { { "NaF", 2 } }),

            // Ca + F2 ¡æ CaF2
            new Reaction(new Dictionary<string, int> { { "Ca", 1 }, { "F2", 1} }, new Dictionary<string, int> { { "CaF2", 1 }}),
        };

    public void GetList(int i)
    {
        checkButton.reaction = reactions[i];
    }
}
