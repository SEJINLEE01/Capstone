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
    }
}
