using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Update : MonoBehaviour
{
    public GameObject Heart_Canvas; // 캔버스
    public GameObject Player;
    Image[] Heart; // 실제 HP 이미지

    public static HP_Update Instance { get; private set; } // 싱글톤
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
                // 현재 체력보다 인덱스가 크거나 같으면 투명하게 만듭니다 (사라진 하트)
                // 예를 들어, currentHealth가 3이면 인덱스 3 (4번째 하트), 인덱스 4 (5번째 하트)가 투명해집니다.
                // 하트 인덱스가 0부터 시작하고, 체력은 1부터 시작한다고 가정할 때,
                // currentHealth = 5 이면 i < 5 (0,1,2,3,4) 모두 불투명
                // currentHealth = 3 이면 i < 3 (0,1,2) 불투명, i >= 3 (3,4) 투명
                if (i < (Heart.Length - currentHealth))
                {
                    // 비활성화 상태 (투명)
                    Color newColor = Heart[i].color;
                    newColor.a = 0f; // 알파 값을 0 (완전 투명)으로 설정
                    Heart[i].color = newColor;
                }
                else
                {
                    // 활성화 상태 (불투명)
                    Color newColor = Heart[i].color;
                    newColor.a = 1f; // 알파 값을 1 (불투명)로 설정
                    Heart[i].color = newColor;
                }
            }
        }
    }
}
