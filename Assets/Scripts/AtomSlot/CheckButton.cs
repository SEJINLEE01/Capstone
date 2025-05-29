using System;
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
    //Reaction.cs��� ��ũ��Ʈ ����
    public Reaction reaction;


    public StarManager starManager;
    public AtomManager atomManager;
    public int currentProblemIndex;
    public int index;


    // ��ư ������ �� ȣ��
    public void RunReactionCheck()
    {
        Debug.Log("CheckButton�� ���Ƚ��ϴ�.");

        if (leftSlot == null || rightSlot == null)
        {
            Debug.LogError("LeftSlot �Ǵ� RightSlot�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }

        var leftAtoms = leftSlot.GetAtomCount();
        var rightAtoms = rightSlot.GetAtomCount();

        Debug.Log("���� ���� ���� ����: " + DictionaryToString(leftAtoms));
        Debug.Log("������ ���� ���� ����: " + DictionaryToString(rightAtoms));

        
        Debug.Log("���� ������ �˻�: " + ReactionToString(reaction));

        if (Match(leftAtoms, reaction.atomInput) && Match(rightAtoms, reaction.atomOutput))
        {
            Debug.Log("����! ���� ���԰� ������ ���� ��� ��ġ�մϴ�.");
            leftSlot.SetCorrectColor();
            rightSlot.SetCorrectColor();
            SetActiveUIElements(LeftUI, true);
            SetActiveUIElements(RightUI, true);
            SetActiveUIElements(CorrectUI, true);

            // ���⿡ �� ���̰� �ϱ�
            starManager.ShowStarByIndex(currentProblemIndex); // ���� �ε��� ��� �� ǥ��
            atomManager.ShowAtom(index);
            if (index < 2)
            {
                index++;
                Debug.Log("�ε��� �� " + index);
            }
            else
            {
                index += 2;
                Debug.Log("�ε��� �� " + index);
            }
            return;
        }
        else if (Match(leftAtoms, reaction.atomInput))
        {
            Debug.Log("�κ� ����: ���� ������ �������� ��ġ�մϴ�.");
            SetActiveUIElements(LeftUI, true);
            SetActiveUIElements(RightUI, false);
            SetActiveUIElements(CorrectUI, false);
            leftSlot.SetCorrectColor();
            rightSlot.SetWrongColor();
            return;
        }
        else if (Match(rightAtoms, reaction.atomOutput))
        {
            Debug.Log("�κ� ����: ������ ������ �������� ��ġ�մϴ�.");
            leftSlot.SetWrongColor();
            rightSlot.SetCorrectColor();
            SetActiveUIElements(LeftUI, false);
            SetActiveUIElements(RightUI, true);
            SetActiveUIElements(CorrectUI, false);
            return;
        }
        

        Debug.Log("����: ��ġ�ϴ� �������� �����ϴ�.");
        leftSlot.SetWrongColor();
        rightSlot.SetWrongColor();
        SetActiveUIElements(LeftUI, false);
        SetActiveUIElements(RightUI, false);
        SetActiveUIElements(CorrectUI, false);
    }


    // ���� �˻�� ���� �ø� ���� �� (actual)�� ���� ������ �䱸�� (expected)�� ��ġ�ϴ��� �˻�
    private bool Match(Dictionary<string, int> actual, Dictionary<string, int> expected)
    {
        if (actual.Count != expected.Count)
        {
            Debug.Log("���� ������ ���� �ٸ��ϴ�. ����: " + actual.Count + ", ����: " + expected.Count);
            return false;
        }

        foreach (var kv in expected)
        {
            if (!actual.ContainsKey(kv.Key) || actual[kv.Key] != kv.Value)
            {
                Debug.Log("���� '" + kv.Key + "'�� ������ �ٸ��ϴ�. ����: " + (actual.ContainsKey(kv.Key) ? actual[kv.Key].ToString() : "0") + ", ����: " + kv.Value);
                return false;
            }
        }

        return true;
    }

    private void SetActiveUIElements(GameObject[] uiElements, bool active)
    {
        if (uiElements != null)
        {
            foreach (GameObject ui in uiElements)
            {
                if (ui != null)
                {
                    ui.SetActive(active);
                }
            }
        }
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

    private string ReactionToString(Reaction reaction)
    {
        return DictionaryToString(reaction.atomInput) + " -> " + DictionaryToString(reaction.atomOutput);
    }
}
