using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // 몬스터 관련
    public Transform hitEffectSpawnPoint;           // 공격 받았을 때 위치
    public Transform deathEffectSpawnPoint;         // 죽었을 때 effect 위치
    public GameObject hitEffectPrefab;              // 공격 받았을 때 effect
    public GameObject deathEffectPrefab;            // 죽었을 때 effect

    // 화면 빨간 플래시 
    public Image damageOverlay;
    public float flashInSpeed = 5f;
    public float flashOutSpeed = 2f;
    public float maxAlpha = 0.4f;

    private Coroutine flashRoutine;

    // 몬스터 피격 (effect 이름 : vfx_impact_01)
    public void TriggerHitEffect()
    {
        if (hitEffectPrefab && hitEffectSpawnPoint)
            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);
    }

    // 몬스터가 공격 → 플레이어 피격 → 화면 붉게
    public void TriggerAttackEffect()
    {
        TriggerDamageFlash();
    }

    // 몬스터 죽음 (effect 이름 : vfx_Explosion_01 + 즉시 제거)
    public void TriggerDeathEffect()
    {
        if (deathEffectPrefab && deathEffectSpawnPoint)
            Instantiate(deathEffectPrefab, deathEffectSpawnPoint.position, deathEffectSpawnPoint.rotation);

        Destroy(gameObject); // 즉시 제거
    }

    // 화면 붉게 플래시 효과
    private void TriggerDamageFlash()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        float alpha = 0f;

        // 알파 증가
        while (alpha < maxAlpha)
        {
            alpha += Time.deltaTime * flashInSpeed;
            SetOverlayAlpha(alpha);
            yield return null;
        }

        // 알파 감소
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * flashOutSpeed;
            SetOverlayAlpha(alpha);
            yield return null;
        }

        SetOverlayAlpha(0f); // 종료
    }

    private void SetOverlayAlpha(float alpha)
    {
        if (damageOverlay != null)
        {
            Color c = damageOverlay.color;
            c.a = Mathf.Clamp01(alpha);
            damageOverlay.color = c;
        }
    }
}
