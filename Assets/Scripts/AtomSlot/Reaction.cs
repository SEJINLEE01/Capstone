//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class Reaction
//{
//    public Dictionary<string, int> atomInput;   // ���� �˻��
//    public Dictionary<string, int> atomOutput;  // ������ �˻��

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
    public Dictionary<string, int> atomInput;   // ���� �˻��
    public Dictionary<string, int> atomOutput;  // ������ �˻��

    public Reaction(Dictionary<string, int> input, Dictionary<string, int> output)
    {
        atomInput = input;
        atomOutput = output;
        Debug.Log("���ο� Reaction ������: " + DictionaryToString(input) + " -> " + DictionaryToString(output));
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