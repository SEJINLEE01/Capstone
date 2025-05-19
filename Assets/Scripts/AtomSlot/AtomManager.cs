using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomManager : MonoBehaviour
{
    public GameObject[] atomsObjects;

    public void ShowAtom(int startIndex)
    {
        Debug.Log($"ShowAtom 호출됨: startIndex = {startIndex}, atomsObjects.Length = {atomsObjects.Length}");



        // 2) startIndex가 0 또는 1이면 한 개만
        if (startIndex < 2)
        {
            Debug.Log("단일 모드: 한 개만 활성화합니다.");
            if (startIndex >= 0 && startIndex < atomsObjects.Length)
            {
                Debug.Log($" -> 활성화: atomsObjects[{startIndex}]");
                atomsObjects[startIndex].SetActive(true);
            }
            else
            {
                Debug.LogWarning($"인덱스 {startIndex}가 범위를 벗어났습니다. 활성화하지 않습니다.");
            }
        }
        // 3) 그 이후부터는 두 개씩
        else
        {
            Debug.Log("다중 모드: 두 개를 활성화합니다.");
            for (int offset = 0; offset < 2; offset++)
            {
                int idx = startIndex + offset;
                if (idx >= 0 && idx < atomsObjects.Length)
                {
                    Debug.Log($" -> 활성화: atomsObjects[{idx}]");
                    atomsObjects[idx].SetActive(true);
                }
                else
                {
                    Debug.LogWarning($"인덱스 {idx}가 범위를 벗어났습니다. 스킵합니다.");
                }
            }
        }
    }
}
