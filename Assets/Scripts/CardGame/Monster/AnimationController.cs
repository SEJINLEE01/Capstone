using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   // 분자 구성 원자 렌더러들
    public List<Renderer> atomRenderers;

   // 색상 설정
    public Color normalColor = Color.cyan;
    public Color attackFlashColor = Color.red;
    public Color hitFlashColor = Color.white;

    // 시간 설정
    public float flashDuration = 0.2f;
    public float fadeOutSpeed = 0.05f;

    // 공격 연출: 중심 원자 붉게 깜빡임
    public void ShowAttackEffect()
    {
        if (atomRenderers.Count > 0)
            StartCoroutine(FlashSingleAtom(atomRenderers[0], attackFlashColor));
    }

    // 피격 연출: 전체 원자 흰색으로 깜빡임
    public void ShowHitEffect()
    {
        StartCoroutine(FlashAllAtoms(hitFlashColor));
    }

    // 사망 연출: 전체 원자 하나씩 투명해지며 사라짐
    public void ShowDeathEffect()
    {
        StartCoroutine(FadeOutAllAtoms());
    }

    // 개별 원자 깜빡임
    IEnumerator FlashSingleAtom(Renderer targetAtom, Color flashColor)
    {
        targetAtom.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        targetAtom.material.color = normalColor;
    }

    // 전체 원자 깜빡임
    IEnumerator FlashAllAtoms(Color flashColor)
    {
        foreach (var atom in atomRenderers)
            atom.material.color = flashColor;

        yield return new WaitForSeconds(flashDuration);

        foreach (var atom in atomRenderers)
            atom.material.color = normalColor;
    }

    // 전체 원자 하나씩 투명하게 사라지기
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
