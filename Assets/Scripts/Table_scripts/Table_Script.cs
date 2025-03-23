using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class Table_Script : MonoBehaviour
{
    public GameObject element;
    private XRGrabInteractable spawnedObject;
    private XRBaseInputInteractor controllerInteractor;
    
    public void OnTable(SelectEnterEventArgs args)
    {
        controllerInteractor = args.interactorObject as XRBaseInputInteractor;
        spawnedObject = Instantiate(element, controllerInteractor.transform.position, controllerInteractor.transform.rotation).GetComponent<XRGrabInteractable>();

        
    }


}
