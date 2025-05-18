//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class Reaction
//{
//    public Dictionary<string, int> atomInput;   // 왼쪽 검사대
//    public Dictionary<string, int> atomOutput;  // 오른쪽 검사대

//    public Reaction(Dictionary<string, int> input, Dictionary<string, int> output)
//    {
//        atomInput = input;
//        atomOutput = output;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reaction
{
    public Dictionary<string, int> atomInput;   // 왼쪽 검사대
    public Dictionary<string, int> atomOutput;  // 오른쪽 검사대

    public Reaction(Dictionary<string, int> input, Dictionary<string, int> output)
    {
        atomInput = input;
        atomOutput = output;
        Debug.Log("새로운 Reaction 생성됨: " + DictionaryToString(input) + " -> " + DictionaryToString(output));
    }

    private string DictionaryToString(Dictionary<string, int> dict)
    {
        string s = "{";
        foreach (KeyValuePair<string, int> kvp in dict)
        {
            s += kvp.Key + "=" + kvp.Value + ", ";
        }
        s = s.TrimEnd(',', ' ') + "}";
        return s;
    }
}