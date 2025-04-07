using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Make_Molcule : MonoBehaviour
{
    public Molcule_Manager MM;
    private SnapInteractable snapInteractable;
    [HideInInspector]
    public bool isCorrect = false;
    void Start(){
        snapInteractable = GetComponent<SnapInteractable>();
    }
    public void OnSelect()
    {
        foreach (var interactor in snapInteractable.Interactors)
        {
            string Name = interactor.transform.parent.gameObject.name;
            if(Name.Contains(transform.parent.gameObject.name)){
                isCorrect = true;
                MM.check();
            }
        }
    }

    public void DeleteElement()
    {
        
        foreach (var interactor in snapInteractable.Interactors)
        {
           interactor.Unselect();
           StartCoroutine(DestroyAfterFrame(interactor.transform.parent.gameObject));
        }
    }
    private IEnumerator DestroyAfterFrame(GameObject obj)
    {
        yield return null; // 한 프레임 대기
        Destroy(obj); // 안전하게 파괴
    }
}
