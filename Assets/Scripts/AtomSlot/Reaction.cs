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
    }
}
