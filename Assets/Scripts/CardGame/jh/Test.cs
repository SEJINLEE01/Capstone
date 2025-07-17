using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class Test : MonoBehaviour
{
    public InteractableUnityEventWrapper wrapper; 

    void Start()
    {
        if (wrapper == null)
            wrapper = GetComponent<InteractableUnityEventWrapper>();

        wrapper.WhenSelect.AddListener(OnSelected);
    }

    void OnSelected()
    {
        RayManager.Instance.SetSelectedObject(this.gameObject);
    }




}
