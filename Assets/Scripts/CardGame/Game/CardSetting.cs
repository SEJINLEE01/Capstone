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
            // SnapInteractor�� ���� ������Ʈ�� �����ɴϴ�.
            GameObject snappedInteractorGameObject = snapInteractor.gameObject.transform.root.gameObject;
            Debug.Log($"<color=green>SnapInteractable�� SnapInteractor�� ���������� �����Ǿ����ϴ�!</color>");
            Debug.Log($"���� SnapInteractor�� ���� ������Ʈ: <color=yellow>{snappedInteractorGameObject.name}</color>");

        }
    }
}
