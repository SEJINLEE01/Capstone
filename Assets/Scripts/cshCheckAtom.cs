using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCheckAtom : MonoBehaviour
{
    [System.Serializable]
    public class ElementData
    {
        public string tagName; // ���� �±� �̸�
        public GameObject canvasPrefab;
        
        public GameObject periodPrefab;
        
    }
    public Transform canvasPos;
    public Transform periodPos;

    public List<ElementData> elements = new List<ElementData>(); // 20�� ������ ����Ʈ

    private Dictionary<string, GameObject> spawnedCanvasDict = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawnedPeriodDict = new Dictionary<string, GameObject>();
    bool isCheck = false;

    void OnCollisionEnter(Collision coll)
    {
        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName) && !isCheck)
            {
                InstantiateCanvas(element);
                InstantiatePeriod(element);
                isCheck = true;
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
        isCheck = false;
    }

    void InstantiateCanvas(ElementData element)
    {
        if (element.canvasPrefab != null && canvasPos != null)
        {
            GameObject canvas = Instantiate(element.canvasPrefab, canvasPos.position, canvasPos.rotation);
            spawnedCanvasDict[element.tagName] = canvas;
            Debug.Log(element.tagName + " Canvas ���� �Ϸ�!");
        }
        else
        {
            Debug.LogWarning(element.tagName + " : canvasPrefab �Ǵ� canvasPos�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    void DestroyCanvas(string tagName)
    {
        if (spawnedCanvasDict.ContainsKey(tagName) && spawnedCanvasDict[tagName] != null)
        {
            Destroy(spawnedCanvasDict[tagName]);
            spawnedCanvasDict[tagName] = null;
            Debug.Log(tagName + " Canvas ���� �Ϸ�!");
        }
    }

    void InstantiatePeriod(ElementData element)
    {
        if (element.periodPrefab != null && periodPos != null)
        {
            GameObject period = Instantiate(element.periodPrefab, periodPos.position, periodPos.rotation);
            spawnedPeriodDict[element.tagName] = period;
            Debug.Log(element.tagName + " PeriodPrefab ���� �Ϸ�!");
        }
        else
        {
            Debug.LogWarning(element.tagName + " : periodPrefab �Ǵ� periodPos�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    void DestroyPeriod(string tagName)
    {
        if (spawnedPeriodDict.ContainsKey(tagName) && spawnedPeriodDict[tagName] != null)
        {
            Destroy(spawnedPeriodDict[tagName]);
            spawnedPeriodDict[tagName] = null;
            Debug.Log(tagName + " PeriodPrefab ���� �Ϸ�!");
        }
    }
}
