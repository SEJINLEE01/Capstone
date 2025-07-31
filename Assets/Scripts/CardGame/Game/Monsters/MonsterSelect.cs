using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class MonsterSelect : MonoBehaviour
{
    public InteractableUnityEventWrapper wrapper; //���͸��� �߰��������
    public GameObject selectedImg;
    
    void Start()
    {
        if (wrapper == null)
            wrapper = GetComponent<InteractableUnityEventWrapper>();

        wrapper.WhenSelect.AddListener(OnSelected);
    }

    void OnSelected()
    {
        selectedImg.SetActive(true);
        GameManager.Instance.SetSelectedObject(this.gameObject);
    }
}
