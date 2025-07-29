using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   // ���� ���� ���� ��������
    public List<Renderer> atomRenderers;

   // ���� ����
    public Color normalColor = Color.cyan;
    public Color attackFlashColor = Color.red;
    public Color hitFlashColor = Color.white;

    // �ð� ����
    public float flashDuration = 0.2f;
    public float fadeOutSpeed = 0.05f;

    // ���� ����: �߽� ���� �Ӱ� ������
    public void ShowAttackEffect()
    {
        if (atomRenderers.Count > 0)
            StartCoroutine(FlashSingleAtom(atomRenderers[0], attackFlashColor));
    }

    // �ǰ� ����: ��ü ���� ������� ������
    public void ShowHitEffect()
    {
        StartCoroutine(FlashAllAtoms(hitFlashColor));
    }

    // ��� ����: ��ü ���� �ϳ��� ���������� �����
    public void ShowDeathEffect()
    {
        StartCoroutine(FadeOutAllAtoms());
    }

    // ���� ���� ������
    IEnumerator FlashSingleAtom(Renderer targetAtom, Color flashColor)
    {
        targetAtom.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        targetAtom.material.color = normalColor;
    }

    // ��ü ���� ������
    IEnumerator FlashAllAtoms(Color flashColor)
    {
        foreach (var atom in atomRenderers)
            atom.material.color = flashColor;

        yield return new WaitForSeconds(flashDuration);

        foreach (var atom in atomRenderers)
            atom.material.color = normalColor;
    }

    // ��ü ���� �ϳ��� �����ϰ� �������
    IEnumerator FadeOutAllAtoms()
    {
        foreach (var atom in atomRenderers)
        {
            Color originalColor = atom.material.color;
            for (float alpha = 1f; alpha >= 0; alpha -= fadeOutSpeed)
            {
                atom.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
