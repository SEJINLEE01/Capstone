using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomManager : MonoBehaviour
{
    public GameObject[] atomsObjects;

    public void ShowAtom(int startIndex)
    {
        Debug.Log($"ShowAtom ȣ���: startIndex = {startIndex}, atomsObjects.Length = {atomsObjects.Length}");



        // 2) startIndex�� 0 �Ǵ� 1�̸� �� ����
        if (startIndex < 2)
        {
            Debug.Log("���� ���: �� ���� Ȱ��ȭ�մϴ�.");
            if (startIndex >= 0 && startIndex < atomsObjects.Length)
            {
                Debug.Log($" -> Ȱ��ȭ: atomsObjects[{startIndex}]");
                atomsObjects[startIndex].SetActive(true);
            }
            else
            {
                Debug.LogWarning($"�ε��� {startIndex}�� ������ ������ϴ�. Ȱ��ȭ���� �ʽ��ϴ�.");
            }
        }
        // 3) �� ���ĺ��ʹ� �� ����
        else
        {
            Debug.Log("���� ���: �� ���� Ȱ��ȭ�մϴ�.");
            for (int offset = 0; offset < 2; offset++)
            {
                int idx = startIndex + offset;
                if (idx >= 0 && idx < atomsObjects.Length)
                {
                    Debug.Log($" -> Ȱ��ȭ: atomsObjects[{idx}]");
                    atomsObjects[idx].SetActive(true);
                }
                else
                {
                    Debug.LogWarning($"�ε��� {idx}�� ������ ������ϴ�. ��ŵ�մϴ�.");
                }
            }
        }
    }
}
