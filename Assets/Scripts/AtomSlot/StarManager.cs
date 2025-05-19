using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // ������ �� �ؽ�Ʈ ������Ʈ���� �����ϴ� �迭
    public GameObject[] starObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // �ε����� �´� ���� setActive
    public void ShowStarByIndex(int index)
    {
        // �ε����� ��ȿ�� �����̰� �ش� ������Ʈ�� ������ ���� ����
        if (index >= 0 && index < starObjects.Length && starObjects[index] != null)
        {
            starObjects[index].SetActive(true);
            Debug.Log("* ���� {index} ���� �� ǥ�õ�");
        }
    }
}
