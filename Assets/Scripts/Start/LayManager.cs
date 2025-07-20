using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayManager : MonoBehaviour
{   
    public Change_Material[] Cm;
    public GameObject[] Monitor;
    public void Operation(){
        foreach(Change_Material cm in Cm){
            cm.Change();
        }
        foreach(GameObject go in Monitor)
        {
            go.SetActive(true);
        }
    }
}
