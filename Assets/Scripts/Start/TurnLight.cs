using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TurnLight : MonoBehaviour
{
    public float fadeDuration = 1.5f; // 색이 변하는 총 시간 (초)
    private Color startColor; // 시작 색상 (검은색)
    private Color endColor = new Color(140f / 255f, 140f / 255f, 140f / 255f, 1.0f); // 목표 색상 (R, G, B 각각 140/255f)
    public GameObject light;
    public GameObject pointlight;
    public LayManager LM; //기계들 메테리얼 관리
    public GameObject Hit_Lay; //카메라 레이 받는 객체
    void Start(){
        RenderSettings.reflectionIntensity = 0.3f;
        RenderSettings.ambientLight = new Color(0f,0f,0f,1.0f);
        startColor = RenderSettings.ambientLight;
    }

    public void TurnOn(){
        if(light.activeSelf)
            return;

        light.SetActive(true);
        
        LM.Operation();
        StartCoroutine(FadeAmbientColor());
    }
    IEnumerator FadeAmbientColor()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            // 경과 시간에 따라 시작 색상과 목표 색상 사이를 보간합니다.
            // Mathf.Lerp는 두 값 사이의 선형 보간을 수행합니다.
            RenderSettings.ambientLight = Color.Lerp(startColor, endColor, timer / fadeDuration);
            RenderSettings.reflectionIntensity = Mathf.Lerp(0.3f, 1.0f, timer / fadeDuration);
            timer += Time.deltaTime; // 지난 프레임부터 현재 프레임까지의 시간 더하기
            yield return null; // 다음 프레임까지 대기
        } 
        // 정확히 목표 색상으로 설정하여 오차를 줄입니다.
        RenderSettings.ambientLight = endColor;
        pointlight.SetActive(false);
        Hit_Lay.SetActive(true);
    }
}
