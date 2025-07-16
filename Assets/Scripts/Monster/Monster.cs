using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public GameObject[] moleculePrefabs;     //분자 프리팹들
    public Transform[] spawnPoints;     //소환 위치
    public float spawnInterval = 5f; //소환 간격 초

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
            Debug.LogWarning("프리팹 또는 소환 위치가 비어있습니다.");
            return;
        }

        // 랜덤 분자 프리팹 선택
        GameObject selectedMolecule = moleculePrefabs[Random.Range(0, moleculePrefabs.Length)];
        // 랜덤 위치 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // 프리팹 소환
        Instantiate(selectedMolecule, spawnPoint.position, spawnPoint.rotation);
    }
}

