using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eMove_Trigger : MonoBehaviour
{
    public GameObject[] MoveElectrons;
    public GameObject[] ActiveElectrons;
    public GameObject[] PositiveObj;
    public GameObject[] NegativeObj;
    public GameObject[] Electrons;
    [HideInInspector]
    public bool active = false;

    public float speed;
    private float elapsedTime = 0f; // 경과 시간
    public float duration; // 이동 시간 (1초)

    Vector3 Pscale;
    Vector3 Nscale;
    public float minusS;
    public float plusS;
    public float fadeDuration;
    float elapsedTime2 = 0f;
    bool DeActiveE = false;
    bool ChangeObj = false;
    bool End = false;
    private void Start()
    {
        Pscale = PositiveObj[0].transform.localScale;
        Nscale = NegativeObj[0].transform.localScale;
    }
    public void Update()
    {
        if (active)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime<=duration)
            {


                for (int i = 0; i < MoveElectrons.Length; i++)
                {
                    Vector3 d = NegativeObj[i].transform.position - MoveElectrons[i].transform.position;
                    d.Normalize();
                    MoveElectrons[i].transform.Translate(d * speed * Time.deltaTime, Space.World);
                }
                
                
            }
            else
            {
                elapsedTime2 += Time.deltaTime;
                if (!DeActiveE)
                {
                    foreach(var electron in MoveElectrons)
                    {
                        electron.SetActive(false);
                    }
                    DeActiveE = true;
                }
                if (!ChangeObj)
                {
                    float alpha = Mathf.SmoothStep(0f, 1f, elapsedTime2 / fadeDuration);
                    foreach (var electron in ActiveElectrons)
                    {
                        
                        Color c = electron.GetComponent<Renderer>().material.color;
                        c.a = alpha;
                        electron.GetComponent<Renderer>().material.color = c;
                    }
                    if (alpha == 1f)
                    {
                        ChangeObj = true;
                        elapsedTime2 = 0f;
                    }
                }
                else
                {
                    elapsedTime2 += Time.deltaTime;
                    float pscale = Mathf.SmoothStep(Pscale.x, Pscale.x - minusS, elapsedTime2 / fadeDuration);
                    float nscale = Mathf.SmoothStep(Nscale.x, Nscale.x + plusS, elapsedTime2 / fadeDuration);
                    float other = Mathf.SmoothStep(1f, 120f/255f, elapsedTime2 / fadeDuration);
                    foreach (var Obj in PositiveObj)
                    {
                        float r = Mathf.SmoothStep(0f, 0.8f, elapsedTime2 / fadeDuration);
                        Color cr = Obj.GetComponent<Renderer>().material.color;
                        cr.r = r;
                        cr.g = other;
                        cr.b = other;
                        Obj.GetComponent<Renderer>().material.color = cr;
                        Obj.transform.localScale = new Vector3(pscale, pscale, pscale);
                    }
                    foreach (var Obj in NegativeObj)
                    {
                        float b = Mathf.SmoothStep(0f, 0.8f, elapsedTime2 / fadeDuration);
                        Color cb = Obj.GetComponent<Renderer>().material.color;
                        cb.b = b;
                        cb.g = other;
                        cb.r = other;
                        Obj.GetComponent<Renderer>().material.color = cb;
                        Obj.transform.localScale = new Vector3(nscale, nscale, nscale);
                    }
                    if (elapsedTime2 >= fadeDuration)
                    {
                        active = false;
                        End = true;
                    }
                }
            }
        }
        if (End)
        {
            foreach (var electron in Electrons)
                Destroy(electron);

            gameObject.GetComponent<Molcule_Ionic_Trigger>().isActive = true;
        } 
    }
}
