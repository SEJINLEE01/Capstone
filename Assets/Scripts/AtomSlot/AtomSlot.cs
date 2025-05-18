//using System.Collections.Generic;
//using UnityEngine;

//public class AtomSlot : MonoBehaviour
//{
//    // ���� �˻�� ���� �ö�� ���ڵ��� �±� ���
//    private List<string> atomTags = new List<string>();

//    // �˻���� ������ ������ Renderer (MeshRenderer �Ǵ� SkinnedMeshRenderer ��)
//    public Renderer slotRenderer;

//    // ���� ���� ����
//    public Color correctColor = Color.blue;    // ������ ��
//    public Color wrongColor = Color.red;       // ������ ��
//    public Color defaultColor = Color.white;   // �ʱ� ����

//    // ���� �� �� �ʱ�ȭ
//    private void Start()
//    {
//        ResetColor();
//    }

//    // �˻�뿡 ���ڰ� ������ �� �±� ���
//    private void OnCollisionEnter(Collision other)
//    {
//        if (!string.IsNullOrEmpty(other.gameObject.tag))
//        {
//            atomTags.Add(other.gameObject.tag);
//        }
//    }

//    // �˻�뿡�� ���ڰ� ���������� �� �±� ����
//    private void OnCollisionExit(Collision other)
//    {
//        atomTags.Remove(other.gameObject.tag);
//    }

//    // ���� �˻�� ���� ���ڵ��� �±� �������� ��� Dictionary<string, int>�� ��ȯ
//    public Dictionary<string, int> GetAtomCount()
//    {
//        Dictionary<string, int> count = new Dictionary<string, int>();
//        foreach (var tag in atomTags)
//        {
//            if (!count.ContainsKey(tag)) count[tag] = 0;
//            count[tag]++;
//        }
//        return count;
//    }

//    // ������ �� �˻�� ������ correctColor�� ����
//    public void SetCorrectColor()
//    {
//        if (slotRenderer != null)
//            slotRenderer.material.color = correctColor;
//    }

//    // ������ �� �˻�� ������ wrongColor�� ����
//    public void SetWrongColor()
//    {
//        if (slotRenderer != null)
//            slotRenderer.material.color = wrongColor;
//    }

//    // �ʱ�ȭ: �˻�� ������ defaultColor�� ����
//    public void ResetColor()
//    {
//        if (slotRenderer != null)
//            slotRenderer.material.color = defaultColor;
//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class AtomSlot : MonoBehaviour
{
    // ���� �˻�� ���� �ö�� ���ڵ��� �±� ���
    private List<string> atomTags = new List<string>();

    // �˻���� ������ ������ Renderer (MeshRenderer �Ǵ� SkinnedMeshRenderer ��)
    public Renderer slotRenderer;

    // ���� ���� ����
    public Color correctColor = Color.blue;     // ������ ��
    public Color wrongColor = Color.red;       // ������ ��
    public Color defaultColor = Color.white;   // �ʱ� ����

    // ���� �� �� �ʱ�ȭ
    private void Start()
    {
        ResetColor();
        Debug.Log(gameObject.name + " ���۵�. �ʱ� ����: " + defaultColor);
    }

    // �˻�뿡 ���ڰ� ������ �� �±� ���
    private void OnCollisionEnter(Collision other)
    {
        if (!string.IsNullOrEmpty(other.gameObject.tag))
        {
            atomTags.Add(other.gameObject.tag);
            Debug.Log(gameObject.name + "�� '" + other.gameObject.tag + "' �±׸� ���� ������Ʈ �浹. ���� �±� ���: " + string.Join(", ", atomTags));
        }
    }

    // �˻�뿡�� ���ڰ� ���������� �� �±� ����
    private void OnCollisionExit(Collision other)
    {
        if (!string.IsNullOrEmpty(other.gameObject.tag) && atomTags.Contains(other.gameObject.tag))
        {
            atomTags.Remove(other.gameObject.tag);
            Debug.Log(gameObject.name + "���� '" + other.gameObject.tag + "' �±׸� ���� ������Ʈ ����. ���� �±� ���: " + string.Join(", ", atomTags));
        }
    }

    // ���� �˻�� ���� ���ڵ��� �±� �������� ��� Dictionary<string, int>�� ��ȯ
    public Dictionary<string, int> GetAtomCount()
    {
        Dictionary<string, int> count = new Dictionary<string, int>();
        foreach (var tag in atomTags)
        {
            if (!count.ContainsKey(tag)) count[tag] = 0;
            count[tag]++;
        }
        Debug.Log(gameObject.name + "�� ���� ���� ����: " + DictionaryToString(count));
        return count;
    }

    // ������ �� �˻�� ������ correctColor�� ����
    public void SetCorrectColor()
    {
        if (slotRenderer != null)
        {
            slotRenderer.material.color = correctColor;
            Debug.Log(gameObject.name + " ���� ����: " + correctColor);
        }
        else
        {
            Debug.LogError(gameObject.name + "�� slotRenderer�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    // ������ �� �˻�� ������ wrongColor�� ����
    public void SetWrongColor()
    {
        if (slotRenderer != null)
        {
            slotRenderer.material.color = wrongColor;
            Debug.Log(gameObject.name + " ���� ����: " + wrongColor);
        }
        else
        {
            Debug.LogError(gameObject.name + "�� slotRenderer�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    // �ʱ�ȭ: �˻�� ������ defaultColor�� ����
    public void ResetColor()
    {
        if (slotRenderer != null)
        {
            slotRenderer.material.color = defaultColor;
            Debug.Log(gameObject.name + " ���� �ʱ�ȭ: " + defaultColor);
        }
        else
        {
            Debug.LogError(gameObject.name + "�� slotRenderer�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    private string DictionaryToString(Dictionary<string, int> dict)
    {
        string s = "{";
        foreach (KeyValuePair<string, int> kvp in dict)
        {
            s += kvp.Key + "=" + kvp.Value + ", ";
        }
        s = s.TrimEnd(',', ' ') + "}";
        return s;
    }
}