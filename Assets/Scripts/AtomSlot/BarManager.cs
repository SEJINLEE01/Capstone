using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public GameObject[] Clear; //�� �׸��� Ȱ��ȭ �Ǿ������� Ŭ����� ����
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
        float duration = 2f; // ���濡 �ɸ��� �ð�
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime; // ������ ���� �ð� ������ ����
            float normalizedTime = Mathf.Clamp01(time / duration); // 0�� 1 ������ ������ ����ȭ

            // Lerp �Լ��� ����Ͽ� ���� ������ ��ǥ ������ �ε巴�� ����
            image.fillAmount = Mathf.Lerp(currAmount, newAmount, normalizedTime);

            yield return null; // ���� �����ӱ��� ���
        }

        // ���� ���� ��Ȯ�ϰ� ����
        image.fillAmount = newAmount;
    }
    
}
