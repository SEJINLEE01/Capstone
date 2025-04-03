using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_element : MonoBehaviour
{
    public GameObject element;

    public void Spawn(){
        Instantiate(element, gameObject.transform.position,Quaternion.identity);
    }
}
