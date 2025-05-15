using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class After_Generator : MonoBehaviour
{
    List<GameObject> EnterCorrectAtom = new List<GameObject>();

    private float elapsedTime = 0f; // ��� �ð�
    private float duration = 2.0f; //  
    public int count; //�ʿ��� ���ڰ���
    private int current_count; // ���� ���� ���� ��
    int count2; // �˸��� ���� ���� Ȯ��
    public GameObject molcule;
    string[] splitResult;
    public int[] atom_count;
    private int[] current_atom_count;
    public GameObject ProgressBar;
    private void Start()
    {
        string input = molcule.tag;
        input = Regex.Replace(input, @"\d", "");
        splitResult = Regex.Split(input, "(?=[A-Z])");
        current_atom_count = new int[splitResult.Length-1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.enabled)
        {
            return; // ��ũ��Ʈ�� ��Ȱ��ȭ�� ���¶�� �޼��带 ����
        }
        current_count++;
        for (int i = 1; i < splitResult.Length; i++)
        {
            if (other.CompareTag(splitResult[i]))
            {
                if (current_atom_count[i - 1] < atom_count[i - 1])
                {
                    current_atom_count[i - 1]++;
                    count2++;
                    EnterCorrectAtom.Add(other.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!this.enabled)
        {
            return; // ��ũ��Ʈ�� ��Ȱ��ȭ�� ���¶�� �޼��带 ����
        }
        
        for (int i = 1; i < splitResult.Length; i++)
        {
            if (other.CompareTag(splitResult[i]))
            {
                if (current_atom_count[i - 1] < atom_count[i - 1])
                {
                    current_atom_count[i - 1]--;
                    count2--;
                    EnterCorrectAtom.Remove(other.gameObject);
                }
            }
        }
        current_count--;
    }
    private void Update()
    {   
        if (count == count2 && count == current_count)
        {
            StartCoroutine(WaitTime2());
            ProgressBar.SetActive(true);
            ProgressBar.transform.localScale = new(ProgressBar.transform.localScale.x, ProgressBar.transform.localScale.y, elapsedTime/duration);

            if (EnterCorrectAtom.Count > 0)
            {
                foreach (GameObject atom in EnterCorrectAtom)
                {
                    Destroy(atom);
                }
            }
            elapsedTime += Time.deltaTime;
            if (duration <= elapsedTime)
            {
                
                EnterCorrectAtom.Clear();
                elapsedTime = 0f;
                current_count = 0;
                count2 = 0;
                for (int i = 0; i < current_atom_count.Length; i++)
                {
                    current_atom_count[i] = 0;
                }
                Instantiate(molcule, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 90f, 0));
                StartCoroutine(WaitTime());
            }
        }
        else
            elapsedTime = 0f; 
    }

    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator WaitTime()
    {
        Transform barTransform = ProgressBar.transform.Find("Bar");
        Color OriginalColor = barTransform.GetComponent<Renderer>().material.color;
        barTransform.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        barTransform.GetComponent<Renderer>().material.color = OriginalColor;
        ProgressBar.SetActive(false);
    }
}

