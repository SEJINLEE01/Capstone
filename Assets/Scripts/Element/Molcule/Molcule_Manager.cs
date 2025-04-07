using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molcule_Manager : MonoBehaviour
{
    public Make_Molcule[] molcules;
    public GameObject molcule;
    public GameObject Effect;
    public void check(){
        foreach(var check in molcules){
            if (!check.isCorrect)
                return;
        }
        foreach (var check in molcules)
        {
            check.DeleteElement();
        }
        Instantiate(molcule,gameObject.transform.position,Quaternion.identity);
        Instantiate(Effect,gameObject.transform.position,Quaternion.identity);
        StartCoroutine(DestroyAfterFrame());
    }

    private IEnumerator DestroyAfterFrame()
    {
        yield return null; // 한 프레임 대기
        Destroy(gameObject); // 안전하게 파괴
    }
}
