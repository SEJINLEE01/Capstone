using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Active : MonoBehaviour
{
    public InteractableUnityEventWrapper wrapper;

    public void Button_on()
    {
        wrapper.enabled = true;
    }
    public void Button_off() 
    {
        wrapper.enabled = false;
    }
}
