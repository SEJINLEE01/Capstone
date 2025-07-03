using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainManager : MonoBehaviour
{   
    [HideInInspector]
    public GameObject ExplainInstance;

    public bool Showing(){
        if(ExplainInstance == null) return true;
        else return false;
    }
}
