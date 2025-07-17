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
    public static RayManager Instance { get; private set; } // �̱��� ����
    // Start is called before the first frame update
    private GameObject selectedObject;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);  // �ߺ� ����

       
    }
    public void SetSelectedObject(GameObject obj) //���õ� ������Ʈ
    {
        selectedObject = obj;
        Debug.Log("���õ� ������Ʈ: " + obj.name);
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
