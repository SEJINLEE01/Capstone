using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCanvas : MonoBehaviour
{
    public GameObject Player;
    public GameObject childCanvasObject;


    void Start()
    {
        Player = GameObject.Find("CenterEyeAnchor");
        childCanvasObject = transform.Find("Canvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        childCanvasObject.transform.position = Player.transform.position + (Player.transform.forward * 0.2f);
        childCanvasObject.transform.rotation = Player.transform.rotation;
    }
}
