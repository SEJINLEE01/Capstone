using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCheckAtom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject canvasPrefab; // 인스펙터에서 할당할 Canvas 프리팹
    private GameObject spawnedCanvas; // 생성된 캔버스를 추적하기 위한 변수

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            InstantiateCanvas(); // 캔버스 생성
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            DestroyCanvas(); // 캔버스 삭제
        }
    }

    void InstantiateCanvas()
    {
        if (canvasPrefab != null)
        {
            spawnedCanvas = Instantiate(canvasPrefab); // 프리팹을 생성
            Debug.Log("Canvas 프리팹 생성 완료!");
        }
        else
        {
            Debug.LogWarning("canvasPrefab이 할당되지 않았습니다!");
        }
    }

    void DestroyCanvas()
    {
        if (spawnedCanvas != null)
        {
            Destroy(spawnedCanvas); // 생성된 캔버스를 삭제
            spawnedCanvas = null; // 변수 초기화
            Debug.Log("Canvas 제거 완료!");
        }
    }

}
