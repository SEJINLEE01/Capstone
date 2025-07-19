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
        targetSnapInteractable.WhenSelectingInteractorViewRemoved += InteractorDelete;
    }
    private void InteractorDetected(IInteractorView interactorView)
    {
        if (interactorView is SnapInteractor snapInteractor)
        {
            // SnapInteractor�� ���� ������Ʈ�� �����ɴϴ�.
            GameObject snappedInteractorGameObject = snapInteractor.gameObject.transform.root.gameObject;
            Debug.Log(snappedInteractorGameObject.name);
            GameManager.Instance.AddCard(snappedInteractorGameObject);

        }
    }

    private void InteractorDelete(IInteractorView interactorView)
    {
        if (interactorView is SnapInteractor snapInteractor)
        {
            // SnapInteractor�� ���� ������Ʈ�� �����ɴϴ�.
            GameObject snappedInteractorGameObject = snapInteractor.gameObject.transform.root.gameObject;
            Debug.Log(snappedInteractorGameObject.name);
            GameManager.Instance.RemoveCard(snappedInteractorGameObject);

        }
    }
}
