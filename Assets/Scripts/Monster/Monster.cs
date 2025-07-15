using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public GameObject[] moleculePrefabs;     //���� �����յ�
    public Transform[] spawnPoints;     //��ȯ ��ġ
    public float spawnInterval = 5f; //��ȯ ���� ��

    private void Start()
    {
        StartCoroutine(SpawnMoleculeLoop());
    }

    IEnumerator SpawnMoleculeLoop()
    {
        while (true)
        {
            SpawnRandomMolecule();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomMolecule()
    {
        if (moleculePrefabs.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogWarning("������ �Ǵ� ��ȯ ��ġ�� ����ֽ��ϴ�.");
            return;
        }

        // ���� ���� ������ ����
        GameObject selectedMolecule = moleculePrefabs[Random.Range(0, moleculePrefabs.Length)];
        // ���� ��ġ ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // ������ ��ȯ
        Instantiate(selectedMolecule, spawnPoint.position, spawnPoint.rotation);
    }
}

