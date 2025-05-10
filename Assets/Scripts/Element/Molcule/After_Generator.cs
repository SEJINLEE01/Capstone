using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;

public class After_Generator : MonoBehaviour
{
    List<GameObject> EnterCorrectAtom = new List<GameObject>();

    private float elapsedTime = 0f; // 경과 시간
    private float duration = 2.0f; //  
    public int count; //필요한 원자개수
    private int current_count;
    public GameObject molcule;
    private Transform SpawnPoint;
    string[] splitResult;
    public int[] atom_count;
    private int[] current_atom_count;
    private void Start()
    {
        SpawnPoint = GameObject.Find("SpawnPoint").transform;

        string input = molcule.tag;
        input = Regex.Replace(input, @"\d", "");
        Debug.Log("ㅑ인풋은어떻게되냐고요?:" + input);
        splitResult = Regex.Split(input, "(?=[A-Z])");
        current_atom_count = new int[splitResult.Length-1];
        for(int i=0;i< splitResult.Length;i++)
            Debug.Log("나뉜토큰들"+ splitResult[i]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.enabled)
        {
            return; // 스크립트가 비활성화된 상태라면 메서드를 종료
        }
        current_count++;
        for (int i = 1; i < splitResult.Length; i++)
        {
            if (other.CompareTag(splitResult[i]))
            {
                if (current_atom_count[i - 1] < atom_count[i - 1])
                {
                    current_atom_count[i - 1]++;
                    EnterCorrectAtom.Add(other.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!this.enabled)
        {
            return; // 스크립트가 비활성화된 상태라면 메서드를 종료
        }
        
        for (int i = 1; i < splitResult.Length; i++)
        {
            if (other.CompareTag(splitResult[i]))
            {
                if (current_atom_count[i - 1] < atom_count[i - 1])
                {
                    current_atom_count[i - 1]--;
                    EnterCorrectAtom.Remove(other.gameObject);
                }
            }
        }
        current_count--;
    }
    private void Update()
    {
            if (count == EnterCorrectAtom.Count && count == current_count)
            {
                elapsedTime += Time.deltaTime;
                if (duration <= elapsedTime)
                {
                    Instantiate(molcule, SpawnPoint.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 90f, 0));
                    foreach (GameObject atom in EnterCorrectAtom)
                    {
                        Destroy(atom);
                    }
                    EnterCorrectAtom.Clear();
                    elapsedTime = 0f;
                    current_count = 0;
                    for (int i = 0; i < current_atom_count.Length; i++)
                    {
                        current_atom_count[i] = 0;
                    }
                }
            }
            else
                elapsedTime = 0f;
    }
}
