using System.Collections.Generic;
using UnityEngine;

public class AtomSlot : MonoBehaviour
{
    // ���� �˻�� ���� �ö�� ���ڵ��� �±� ���
    private List<string> atomTags = new List<string>();

    // �˻���� ������ ������ Renderer (MeshRenderer �Ǵ� SkinnedMeshRenderer ��)
    public Renderer slotRenderer;

    // ���� ���� ����
    public Color correctColor = Color.blue;    // ������ ��
    public Color wrongColor = Color.red;       // ������ ��
    public Color defaultColor = Color.white;   // �ʱ� ����

    // ���� �� �� �ʱ�ȭ
    private void Start()
    {
        ResetColor();
    }

    // �˻�뿡 ���ڰ� ������ �� �±� ���
    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(other.tag))
        {
            atomTags.Add(other.tag);
        }
    }

    // �˻�뿡�� ���ڰ� ���������� �� �±� ����
    private void OnTriggerExit(Collider other)
    {
        atomTags.Remove(other.tag);
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
        return count;
    }

    // ������ �� �˻�� ������ correctColor�� ����
    public void SetCorrectColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = correctColor;
    }

    // ������ �� �˻�� ������ wrongColor�� ����
    public void SetWrongColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = wrongColor;
    }

    // �ʱ�ȭ: �˻�� ������ defaultColor�� ����
    public void ResetColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = defaultColor;
    }
}
