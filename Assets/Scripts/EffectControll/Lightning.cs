using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    float shrinkDuration = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("element"))
        {
            Destroy(collision.gameObject);
           
            GameObject l = Instantiate(lightning, transform.position + new Vector3(0f,0.5f,0f), Quaternion.identity);
            l.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(l, shrinkDuration+1f);
            StartCoroutine(ChangeScale(l));
        }
    }

    IEnumerator ChangeScale(GameObject l)
    {
        Vector3 initialScale = l.transform.localScale;
        float timer = 0f;
        while (timer < shrinkDuration)
        {
            // 경과 시간 비율 계산 (0에서 1까지)
            float t = timer / shrinkDuration;

            // Lerp 함수를 사용하여 스케일을 선형적으로 보간
            // initialScale에서 Vector3.zero (0,0,0)까지 t 값에 따라 변화
            l.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);

            timer += Time.deltaTime; // 지난 프레임 시간만큼 타이머 증가
            yield return null; // 다음 프레임까지 기다림
        }
    }
}
