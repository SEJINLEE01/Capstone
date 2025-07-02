using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float interactionDistance = 10f; // 상호작용 가능한 최대 거리
    public LayerMask interactableLayer; // 상호작용할 오브젝트들이 속한 레이어
    public float requiredGazeTime = 2f; // 상호작용을 트리거하기 위해 필요한 주시 시간 (초)

    private GameObject currentGazedObject = null; // 현재 바라보고 있는 오브젝트
    private float gazeTimer = 0f; // 주시 시간 타이머
    public PlayerMove PM;
    void Update()
    {
        // 카메라의 정면 방향으로 Ray를 발사
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Ray가 상호작용 가능한 레이어의 오브젝트와 충돌했는지 검사
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // 새로운 오브젝트를 바라보기 시작했거나, 이전에 바라보던 오브젝트가 아닌 경우
            if (hit.collider.gameObject != currentGazedObject)
            {
                // 새로운 오브젝트로 변경되었으니 타이머 초기화
                currentGazedObject = hit.collider.gameObject;
                gazeTimer = 0f;
                Debug.Log("새로운 오브젝트 '" + currentGazedObject.name + "'을(를) 바라보기 시작했습니다. 주시 타이머 초기화.");
                // 여기에 주시 시작 시 시각적 피드백 (예: UI 게이지 표시) 추가 가능
            }
            else // 이전에 바라보던 동일한 오브젝트를 계속 바라보고 있는 경우
            {
                gazeTimer += Time.deltaTime; // 시간 누적
                Debug.Log("'" + currentGazedObject.name + "'을(를) 주시 중: " + gazeTimer.ToString("F2") + "초");

                // 필요한 주시 시간을 초과했는지 확인
                if (gazeTimer >= requiredGazeTime)
                {
                    Debug.Log("'" + currentGazedObject.name + "'에 대한 주시 시간이 충족되었습니다! 상호작용 실행.");
                    PM.enabled = true;
                    this.enabled = false; 
                }
            }
        }
        else // 아무것도 바라보고 있지 않거나, 상호작용 레이어의 오브젝트가 아닌 경우
        {
            if (currentGazedObject != null)
            {
                Debug.Log("더 이상 '" + currentGazedObject.name + "'을(를) 바라보고 있지 않습니다. 주시 타이머 초기화.");
                // 여기에 주시 종료 시 시각적 피드백 (예: UI 게이지 숨기기) 추가 가능
            }
            currentGazedObject = null; // 현재 바라보던 오브젝트 해제
            gazeTimer = 0f; // 타이머 초기화
        }
    }
}
