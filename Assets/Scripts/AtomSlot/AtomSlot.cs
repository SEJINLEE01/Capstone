using System.Collections.Generic;
using UnityEngine;

public class AtomSlot : MonoBehaviour
{
    // 현재 검사대 위에 올라온 원자들의 태그 목록
    private List<string> atomTags = new List<string>();

    // 검사대의 색상을 변경할 Renderer (MeshRenderer 또는 SkinnedMeshRenderer 등)
    public Renderer slotRenderer;

    // 색상 상태 정의
    public Color correctColor = Color.blue;    // 정답일 때
    public Color wrongColor = Color.red;       // 오답일 때
    public Color defaultColor = Color.white;   // 초기 상태

    // 시작 시 색 초기화
    private void Start()
    {
        ResetColor();
    }

    // 검사대에 원자가 들어왔을 때 태그 등록
    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(other.tag))
        {
            atomTags.Add(other.tag);
        }
    }

    // 검사대에서 원자가 빠져나갔을 때 태그 제거
    private void OnTriggerExit(Collider other)
    {
        atomTags.Remove(other.tag);
    }

    // 현재 검사대 위의 원자들을 태그 기준으로 세어서 Dictionary<string, int>로 반환
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

    // 정답일 때 검사대 색상을 correctColor로 변경
    public void SetCorrectColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = correctColor;
    }

    // 오답일 때 검사대 색상을 wrongColor로 변경
    public void SetWrongColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = wrongColor;
    }

    // 초기화: 검사대 색상을 defaultColor로 변경
    public void ResetColor()
    {
        if (slotRenderer != null)
            slotRenderer.material.color = defaultColor;
    }
}
