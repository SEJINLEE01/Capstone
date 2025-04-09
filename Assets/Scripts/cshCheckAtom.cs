using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCheckAtom : MonoBehaviour
{
    [System.Serializable]
    public class ElementData
    {
        public string tagName; // 원소 태그 이름
        public GameObject canvasPrefab;
        public Transform canvasPos;
        public GameObject periodPrefab;
        public Transform periodPos;
    }

    public List<ElementData> elements = new List<ElementData>(); // 20개 저장할 리스트

    private Dictionary<string, GameObject> spawnedCanvasDict = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawnedPeriodDict = new Dictionary<string, GameObject>();

    void OnCollisionEnter(Collision coll)
    {
        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName))
            {
                InstantiateCanvas(element);
                InstantiatePeriod(element);
            }
        }
    }

    void OnCollisionExit(Collision coll)
    {
        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName))
            {
                DestroyCanvas(element.tagName);
                DestroyPeriod(element.tagName);
            }
        }
    }

    void InstantiateCanvas(ElementData element)
    {
        if (element.canvasPrefab != null && element.canvasPos != null)
        {
            GameObject canvas = Instantiate(element.canvasPrefab, element.canvasPos.position, element.canvasPos.rotation);
            spawnedCanvasDict[element.tagName] = canvas;
            Debug.Log(element.tagName + " Canvas 생성 완료!");
        }
        else
        {
            Debug.LogWarning(element.tagName + " : canvasPrefab 또는 canvasPos가 할당되지 않았습니다!");
        }
    }

    void DestroyCanvas(string tagName)
    {
        if (spawnedCanvasDict.ContainsKey(tagName) && spawnedCanvasDict[tagName] != null)
        {
            Destroy(spawnedCanvasDict[tagName]);
            spawnedCanvasDict[tagName] = null;
            Debug.Log(tagName + " Canvas 제거 완료!");
        }
    }

    void InstantiatePeriod(ElementData element)
    {
        if (element.periodPrefab != null && element.periodPos != null)
        {
            GameObject period = Instantiate(element.periodPrefab, element.periodPos.position, element.periodPos.rotation);
            spawnedPeriodDict[element.tagName] = period;
            Debug.Log(element.tagName + " PeriodPrefab 생성 완료!");
        }
        else
        {
            Debug.LogWarning(element.tagName + " : periodPrefab 또는 periodPos가 할당되지 않았습니다!");
        }
    }

    void DestroyPeriod(string tagName)
    {
        if (spawnedPeriodDict.ContainsKey(tagName) && spawnedPeriodDict[tagName] != null)
        {
            Destroy(spawnedPeriodDict[tagName]);
            spawnedPeriodDict[tagName] = null;
            Debug.Log(tagName + " PeriodPrefab 제거 완료!");
        }
    }
}
