using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayManager : MonoBehaviour
{
    public Image HPimg;
    public float MaxHP = 100f;
    public float HP;
    public float damage = 10f;
    public static RayManager Instance { get; private set; } // 싱글톤 패턴
    // Start is called before the first frame update
    private GameObject selectedObject;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);  // 중복 방지

       
    }
    public void SetSelectedObject(GameObject obj) //선택된 오브젝트
    {
        selectedObject = obj;
        Debug.Log("선택된 오브젝트: " + obj.name);
    }

    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }

    public void cardselect()
    {
        HP -= damage;
        HPimg.fillAmount = HP/MaxHP;
    }


}
