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
    public Transform CanvasPos;//canvas 생성 위치

    public GameObject PeriodPrefab; // 인스펙터에서 할당할 Period 프리팹
    private GameObject spawnedPeriod; // 생성된 Period를 추적하기 위한 변수
    public Transform PeriodPos; // Period 생성 위치

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            InstantiateCanvas(); // 캔버스 생성
            InstantiatePeriod(); // PeriodPrefab 생성
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            DestroyCanvas(); // 캔버스 삭제
            DestroyPeriod(); // PeriodPrefab 삭제
        }
    }

    void InstantiateCanvas()
    {
        if (canvasPrefab != null)
        {
            spawnedCanvas = Instantiate(canvasPrefab,CanvasPos.position, CanvasPos.rotation); // 프리팹을 생성
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

    void InstantiatePeriod()
    {
        if (PeriodPrefab != null && PeriodPos != null)
        {
            spawnedPeriod = Instantiate(PeriodPrefab, PeriodPos.position, PeriodPos.rotation);
            Debug.Log("PeriodPrefab 생성 완료!");
        }
        else
        {
            Debug.LogWarning("PeriodPrefab 또는 PeriodPos가 할당되지 않았습니다!");
        }
    }

    void DestroyPeriod()
    {
        if (spawnedPeriod != null)
        {
            Destroy(spawnedPeriod);
            spawnedPeriod = null;
            Debug.Log("PeriodPrefab 제거 완료!");
        }
    }

}
