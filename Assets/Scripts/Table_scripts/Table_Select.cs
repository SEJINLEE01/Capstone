using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class Table_Select : XRBaseInteractor
{
    private XRBaseInteractor currentInteractor;
    private XRBaseInteractable currentInteractable;
    public GameObject Prefabs;

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        // � ��Ʈ�ѷ�(Interactor)�� �����ߴ��� Ȯ��
        currentInteractor = args.interactorObject as XRBaseInteractor;
        currentInteractable = args.interactableObject as XRBaseInteractable;

        GameObject newObject = Instantiate(Prefabs, currentInteractor.transform.position, Quaternion.identity);
        newObject.GetComponent<Rigidbody>().useGravity = false;
    }
}
