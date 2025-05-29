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

    public List<ElementData> elements = new List<ElementData>(); // 37�� ������ ����Ʈ

    private Dictionary<string, GameObject> spawnedCanvasDict = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawnedPeriodDict = new Dictionary<string, GameObject>();

    private string currentActiveTag = null;
    private Queue<string> tagQueue = new Queue<string>();

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("�浹�� ������Ʈ �̸�: " + coll.gameObject.name);

        foreach (var element in elements)
        {
            if (coll.gameObject.CompareTag(element.tagName))
            {
                // �ߺ��� �±װ� ť�� �̹� ������ ����
                if (tagQueue.Contains(element.tagName))
                {
                    Debug.Log($"{element.tagName} �̹� ť�� ����");
                    return;
                }

                // ť�� ���
                tagQueue.Enqueue(element.tagName);
                Debug.Log($"{element.tagName} ť�� ��ϵ�");

                // ���� UI�� ������ �ٷ� �� �±׸� Ȱ��ȭ
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
                    tagQueue.Dequeue(); // ���� ���� �±� ����

                    // ��� ���� ���� �±װ� ������ ���
                    if (tagQueue.Count > 0)
                    {
                        string nextTag = tagQueue.Peek(); // ���� �±� Ȯ��

                        // elements���� �ٽ� ã�ƾ� ��
                        ElementData nextElement = elements.Find(e => e.tagName == nextTag);
                        if (nextElement != null)
                        {
                            InstantiateCanvas(nextElement);
                            InstantiatePeriod(nextElement);
                            currentActiveTag = nextTag;
                            Debug.Log("���ο� Ȱ�� ���Ҵ�: " + currentActiveTag);
                        }
                    }
                    else
                    {
                        Debug.Log("��� ���� �±� ����");
                    }
                }
                else
                {
                    // �������� UI�� ��� �±״� �ƴϸ� ť���� �׳� ����
                    Queue<string> tempQueue = new Queue<string>();
                    while (tagQueue.Count > 0)
                    {
                        string tag = tagQueue.Dequeue();
                        if (tag != element.tagName)
                            tempQueue.Enqueue(tag);
                    }
                    tagQueue = tempQueue;
                    Debug.Log($"{element.tagName} ť���� ���ŵ� (��Ȱ�� ���¿���)");
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
