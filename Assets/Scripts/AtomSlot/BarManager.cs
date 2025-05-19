using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public GameObject[] Clear; //별 그림이 활성화 되어있으면 클리어로 간주
    int count;

    public void ProgressUpdate() {
        count = 0;
        foreach (GameObject clear in Clear)
        {
            if (clear.activeSelf)
                count++;
        }

        StartCoroutine(Amount_calc(image.fillAmount, 1f - (count / (float)Clear.Length)));
        text.text = count.ToString();
        
    }

    IEnumerator Amount_calc(float currAmount, float newAmount)
    {
        float duration = 2f; // 변경에 걸리는 시간
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime; // 프레임 간의 시간 간격을 더함
            float normalizedTime = Mathf.Clamp01(time / duration); // 0과 1 사이의 값으로 정규화

            // Lerp 함수를 사용하여 현재 값에서 목표 값으로 부드럽게 보간
            image.fillAmount = Mathf.Lerp(currAmount, newAmount, normalizedTime);

            yield return null; // 다음 프레임까지 대기
        }

        // 최종 값을 정확하게 설정
        image.fillAmount = newAmount;
    }
    
}
