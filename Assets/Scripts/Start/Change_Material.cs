using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Material : MonoBehaviour
{
    private Renderer myRenderer; // Renderer 컴포넌트를 참조할 변수
    private Material currentMaterial; //원래 가지고 있던 메테리얼
    public Material Black;
    void Start()
    {
        // 1. 이 스크립트가 부착된 GameObject에서 Renderer 컴포넌트를 가져옵니다.
        myRenderer = GetComponent<Renderer>();
        currentMaterial = myRenderer.material;
        myRenderer.material = Black;
    }

    public void Change(){
        myRenderer.material = currentMaterial;
    }
}
