using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject[] Smokes;
    Vector3 initialScale;
    Vector3 zScale;
    float shrinkDuration = 3f;
    private void Start()
    {
        initialScale = Smokes[0].transform.localScale;
        zScale = new Vector3(Smokes[0].transform.localScale.x, Smokes[0].transform.localScale.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("element"))
        {
            StartCoroutine(ActiveSmoke());
        }
    }

    IEnumerator ActiveSmoke()
    {
        foreach (GameObject item in Smokes)
        {   
            item.transform.localScale = initialScale;
            item.SetActive(true);
        }

        yield return new WaitForSeconds(8f);
        float timer = 0f; // 시간 측정을 위한 타이머
        while (timer < shrinkDuration)
        {
            // 경과 시간 비율 계산 (0에서 1까지)
            float t = timer / shrinkDuration;

            // Lerp 함수를 사용하여 스케일을 선형적으로 보간
            // initialScale에서 Vector3.zero (0,0,0)까지 t 값에 따라 변화
            
            Smokes[0].transform.localScale = Vector3.Lerp(initialScale, zScale, t);
            Smokes[1].transform.localScale = Vector3.Lerp(initialScale, zScale, t);
            Smokes[2].transform.localScale = Vector3.Lerp(initialScale, zScale, t);

            timer += Time.deltaTime; // 지난 프레임 시간만큼 타이머 증가
            yield return null; // 다음 프레임까지 기다림
        }
        yield return new WaitForSeconds(1f);
        foreach (GameObject item in Smokes)
        {
            item.SetActive(false);
        }
    }
}
