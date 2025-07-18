using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetting : MonoBehaviour
{
    SnapInteractable targetSnapInteractable;

    private void Start()
    {
        targetSnapInteractable = GetComponent<SnapInteractable>();
        targetSnapInteractable.WhenSelectingInteractorViewAdded += InteractorDetected;
    }
    private void InteractorDetected(IInteractorView interactorView)
    {
        if (interactorView is SnapInteractor snapInteractor)
        {
            // SnapInteractor의 게임 오브젝트를 가져옵니다.
            GameObject snappedInteractorGameObject = snapInteractor.gameObject.transform.root.gameObject;
            Debug.Log($"<color=green>SnapInteractable에 SnapInteractor가 성공적으로 스냅되었습니다!</color>");
            Debug.Log($"붙은 SnapInteractor의 게임 오브젝트: <color=yellow>{snappedInteractorGameObject.name}</color>");

        }
    }
}
