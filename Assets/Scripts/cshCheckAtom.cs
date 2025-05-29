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
        public GameObject periodPrefab;
        
    }
    public Transform canvasPos;
    public Transform periodPos;

    public List<ElementData> elements = new List<ElementData>(); // 37개 저장할 리스트

    private Dictionary<string, GameObject> spawnedCanvasDict = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawnedPeriodDict = new Dictionary<string, GameObject>();

    private string currentActiveTag = null;
    private Queue<string> tagQueue = new Queue<string>();

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("충돌된 오브젝트 이름: " + coll.gameObject.name);

        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName))
            {
                // 중복된 태그가 큐에 이미 있으면 무시
                if (tagQueue.Contains(element.tagName))
                {
                    Debug.Log($"{element.tagName} 이미 큐에 있음");
                    return;
                }

                // 큐에 등록
                tagQueue.Enqueue(element.tagName);
                Debug.Log($"{element.tagName} 큐에 등록됨");

                // 현재 UI가 없으면 바로 이 태그를 활성화
                if (currentActiveTag == null)
                {
                    InstantiateCanvas(element);
                    InstantiatePeriod(element);
                    currentActiveTag = element.tagName;
                }
            }
        }
    }

    void OnCollisionExit(Collision coll)
    {
        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName))
            {
                if (currentActiveTag == element.tagName)
                {
                    DestroyCanvas(element.tagName);
                    DestroyPeriod(element.tagName);

                    currentActiveTag = null;
                    tagQueue.Dequeue(); // 현재 빠진 태그 제거

                    // 대기 중인 다음 태그가 있으면 띄움
                    if (tagQueue.Count > 0)
                    {
                        string nextTag = tagQueue.Peek(); // 다음 태그 확인

                        // elements에서 다시 찾아야 함
                        ElementData nextElement = elements.Find(e => e.tagName == nextTag);
                        if (nextElement != null)
                        {
                            InstantiateCanvas(nextElement);
                            InstantiatePeriod(nextElement);
                            currentActiveTag = nextTag;
                            Debug.Log("새로운 활성 원소는: " + currentActiveTag);
                        }
                    }
                    else
                    {
                        Debug.Log("대기 중인 태그 없음");
                    }
                }
                else
                {
                    // 나갔지만 UI를 띄운 태그는 아니면 큐에서 그냥 제거
                    Queue<string> tempQueue = new Queue<string>();
                    while (tagQueue.Count > 0)
                    {
                        string tag = tagQueue.Dequeue();
                        if (tag != element.tagName)
                            tempQueue.Enqueue(tag);
                    }
                    tagQueue = tempQueue;
                    Debug.Log($"{element.tagName} 큐에서 제거됨 (비활성 상태였음)");
                }
            }
        }
    }


    void InstantiateCanvas(ElementData element)
    {
        if (element.canvasPrefab != null && canvasPos != null)
        {
            GameObject canvas = Instantiate(element.canvasPrefab, canvasPos.position, canvasPos.rotation);
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
        if (element.periodPrefab != null && periodPos != null)
        {
            GameObject period = Instantiate(element.periodPrefab, periodPos.position, periodPos.rotation);
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
