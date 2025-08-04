using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Update : MonoBehaviour
{
    public GameObject Heart_Canvas; // ĵ����
    public GameObject Player;
    Image[] Heart; // ���� HP �̹���

    public static HP_Update Instance { get; private set; } // �̱���
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Player = GameObject.Find("CenterEyeAnchor");
        Heart = new Image[Heart_Canvas.transform.childCount];

        for (int i = 0; i < Heart_Canvas.transform.childCount; i++)
        {
            Heart[i]= Heart_Canvas.transform.GetChild(i).gameObject.GetComponent<Image>();
        }
    }

    public void Update()
    {
        Heart_Canvas.transform.position = Player.transform.position + (Player.transform.forward * 1.0f) + (Player.transform.right*0.4f) + (Player.transform.up*0.2f);
        Heart_Canvas.transform.rotation = Player.transform.rotation;
    }

    public void UpdateHeartUI(int currentHealth)
    {
        for (int i = 0; i < Heart.Length; i++)
        {
            if (Heart[i] != null)
            {
                // ���� ü�º��� �ε����� ũ�ų� ������ �����ϰ� ����ϴ� (����� ��Ʈ)
                // ���� ���, currentHealth�� 3�̸� �ε��� 3 (4��° ��Ʈ), �ε��� 4 (5��° ��Ʈ)�� ���������ϴ�.
                // ��Ʈ �ε����� 0���� �����ϰ�, ü���� 1���� �����Ѵٰ� ������ ��,
                // currentHealth = 5 �̸� i < 5 (0,1,2,3,4) ��� ������
                // currentHealth = 3 �̸� i < 3 (0,1,2) ������, i >= 3 (3,4) ����
                if (i < (Heart.Length - currentHealth))
                {
                    // ��Ȱ��ȭ ���� (����)
                    Color newColor = Heart[i].color;
                    newColor.a = 0f; // ���� ���� 0 (���� ����)���� ����
                    Heart[i].color = newColor;
                }
                else
                {
                    // Ȱ��ȭ ���� (������)
                    Color newColor = Heart[i].color;
                    newColor.a = 1f; // ���� ���� 1 (������)�� ����
                    Heart[i].color = newColor;
                }
            }
        }
    }
}
