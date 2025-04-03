using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_element : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        string name = collider.gameObject.name;

        if(name.Contains("element(u)"))
            Destroy(collider.gameObject);
        
    }
}
