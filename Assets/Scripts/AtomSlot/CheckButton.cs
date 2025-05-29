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
    //Reaction.cs라는 스크립트 있음
    public Reaction reaction;


    public StarManager starManager;
    public AtomManager atomManager;
    public int currentProblemIndex;
    public int index;


    // 버튼 눌렀을 때 호출
    public void RunReactionCheck()
    {
        Debug.Log("CheckButton이 눌렸습니다.");

        if (leftSlot == null || rightSlot == null)
        {
            Debug.LogError("LeftSlot 또는 RightSlot이 할당되지 않았습니다!");
            return;
        }

        var leftAtoms = leftSlot.GetAtomCount();
        var rightAtoms = rightSlot.GetAtomCount();

        Debug.Log("왼쪽 슬롯 원자 구성: " + DictionaryToString(leftAtoms));
        Debug.Log("오른쪽 슬롯 원자 구성: " + DictionaryToString(rightAtoms));

        
        Debug.Log("현재 반응식 검사: " + ReactionToString(reaction));

        if (Match(leftAtoms, reaction.atomInput) && Match(rightAtoms, reaction.atomOutput))
        {
            Debug.Log("정답! 왼쪽 슬롯과 오른쪽 슬롯 모두 일치합니다.");
            leftSlot.SetCorrectColor();
            rightSlot.SetCorrectColor();
            SetActiveUIElements(LeftUI, true);
            SetActiveUIElements(RightUI, true);
            SetActiveUIElements(CorrectUI, true);

            // 여기에 별 보이게 하기
            starManager.ShowStarByIndex(currentProblemIndex); // 문제 인덱스 기반 별 표시
            atomManager.ShowAtom(index);
            if (index < 2)
            {
                index++;
                Debug.Log("인덱스 값 " + index);
            }
            else
            {
                index += 2;
                Debug.Log("인덱스 값 " + index);
            }
            return;
        }
        else if (Match(leftAtoms, reaction.atomInput))
        {
            Debug.Log("부분 정답: 왼쪽 슬롯은 반응물과 일치합니다.");
            SetActiveUIElements(LeftUI, true);
            SetActiveUIElements(RightUI, false);
            SetActiveUIElements(CorrectUI, false);
            leftSlot.SetCorrectColor();
            rightSlot.SetWrongColor();
            return;
        }
        else if (Match(rightAtoms, reaction.atomOutput))
        {
            Debug.Log("부분 정답: 오른쪽 슬롯은 생성물과 일치합니다.");
            leftSlot.SetWrongColor();
            rightSlot.SetCorrectColor();
            SetActiveUIElements(LeftUI, false);
            SetActiveUIElements(RightUI, true);
            SetActiveUIElements(CorrectUI, false);
            return;
        }
        

        Debug.Log("오답: 일치하는 반응식이 없습니다.");
        leftSlot.SetWrongColor();
        rightSlot.SetWrongColor();
        SetActiveUIElements(LeftUI, false);
        SetActiveUIElements(RightUI, false);
        SetActiveUIElements(CorrectUI, false);
    }


    // 실제 검사대 위에 올린 원자 수 (actual)와 정답 반응식 요구량 (expected)이 일치하는지 검사
    private bool Match(Dictionary<string, int> actual, Dictionary<string, int> expected)
    {
        if (actual.Count != expected.Count)
        {
            Debug.Log("원자 종류의 수가 다릅니다. 실제: " + actual.Count + ", 예상: " + expected.Count);
            return false;
        }

        foreach (var kv in expected)
        {
            if (!actual.ContainsKey(kv.Key) || actual[kv.Key] != kv.Value)
            {
                Debug.Log("원자 '" + kv.Key + "'의 개수가 다릅니다. 실제: " + (actual.ContainsKey(kv.Key) ? actual[kv.Key].ToString() : "0") + ", 예상: " + kv.Value);
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
