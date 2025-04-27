using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class eMove_Trigger : MonoBehaviour
{
    public Transform Target;
    public GameObject[] MoveElectrons;
    public GameObject[] ActiveElectrons;
    public GameObject[] PositiveObj;
    public GameObject NegativeObj;
    public GameObject[] Electrons;
    [HideInInspector]
    public bool active = false;

    public float speed;
    private float elapsedTime = 0f; // 경과 시간
    public float duration; // 이동 시간 (1초)

    float fadeDuration = 1f;
    float elapsedTime2 = 0f;
    bool ChangeObj = false;
    bool End = false;
    public void Update()
    {
        if (active)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime<=duration)
            {
                foreach (var electron in MoveElectrons)
                {
                    Vector3 d = Target.position-electron.transform.position;
                    d.Normalize();
                    electron.transform.Translate(d*speed*Time.deltaTime,Space.World);
                }
            }
            else
            {
                elapsedTime2 += Time.deltaTime;
                if (!ChangeObj)
                {
                    foreach (var electron in ActiveElectrons)
                    {
                        float alpha = Mathf.SmoothStep(0f, 1f, elapsedTime2 / fadeDuration);
                        Color c = electron.GetComponent<Renderer>().material.color;
                        c.a = alpha;
                        electron.GetComponent<Renderer>().material.color = c;
                        if (alpha == 1f)
                        {
                            ChangeObj = true;
                            elapsedTime2 = 0f;
                        }
                    }
                }
                else
                {
                    elapsedTime2 += Time.deltaTime;
                    float other = Mathf.SmoothStep(1f, 120f/255f, elapsedTime2 / fadeDuration);
                    foreach (var Obj in PositiveObj)
                    {
                        float r = Mathf.SmoothStep(0f, 0.8f, elapsedTime2 / fadeDuration);
                        Color cr = Obj.GetComponent<Renderer>().material.color;
                        cr.r = r;
                        cr.g = other;
                        cr.b = other;
                        Obj.GetComponent<Renderer>().material.color = cr;
                    }
                    float b = Mathf.SmoothStep(0f, 0.8f, elapsedTime2 / fadeDuration);
                    Color cb = NegativeObj.GetComponent<Renderer>().material.color;
                    cb.b = b;
                    cb.g = other;
                    cb.r = other;
                    NegativeObj.GetComponent<Renderer>().material.color = cb;
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
