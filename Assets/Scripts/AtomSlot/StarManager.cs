using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // 문제별 별 텍스트 오브젝트들을 저장하는 배열
    public GameObject[] starObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // 인덱스에 맞는 별을 setActive
    public void ShowStarByIndex(int index)
    {
        // 인덱스가 유효한 범위이고 해당 오브젝트가 존재할 때만 실행
        if (index >= 0 && index < starObjects.Length && starObjects[index] != null)
        {
            starObjects[index].SetActive(true);
            Debug.Log("* 문제 {index} 정답 별 표시됨");
        }
    }
}
