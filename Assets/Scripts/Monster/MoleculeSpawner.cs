using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    // 분자 프리팹들 => AlCl3, CaF2, Cl2, SiO2 순서로 등록해야 함
    public GameObject[] moleculePrefabs;

    // 분자가 소환될 수 있는 위치들 (Transform 배열로 여러 위치 등록 가능)
    public Transform[] spawnPoints;

    // 턴 사이의 대기 시간 (초 단위)
    public float delayBetweenTurns = 2f;

    // 현재 진행 중인 턴 번호 (0부터 시작)
    private int cycle = 0;

    // 게임 시작 시 호출되는 함수
    void Start()
    {
        // 턴마다 분자를 자동으로 소환하는 코루틴 시작
        StartCoroutine(GameTurnRoutine());
    }

    // 턴마다 분자를 소환하고 일정 시간 대기하는 루틴
    IEnumerator GameTurnRoutine()
    {
        // 게임 시작 전 약간의 대기 시간
        yield return new WaitForSeconds(2f);

        // 총 3턴까지 반복 (cycle: 0, 1, 2)
        while (cycle < 3)
        {
            StartNextCycle(); // 현재 턴에 해당하는 분자 소환
            cycle++; // 다음 턴으로 이동
            yield return new WaitForSeconds(delayBetweenTurns); // 1분 대기 -> 한 턴마다 1분씩 주어짐
        }
        Debug.Log("모든 턴이 끝났습니다.");
    }

    // 현재 턴에 맞는 분자(몬스터)들을 소환하는 함수
    void StartNextCycle()
    {
        switch (cycle)
        {
            case 0:
                // 1턴: AlCl3, CaF2 소환
                SpawnMolecule(0); // AlCl3
                SpawnMolecule(1); // CaF2
                break;
            case 1:
                // 2턴: Cl2 소환
                SpawnMolecule(2); // Cl2
                break;
            case 2:
                // 3턴: SiO2 소환
                SpawnMolecule(3); // SiO2
                break;
            default:
                // 턴이 모두 끝났을 때
                Debug.Log("모든 턴이 끝났습니다.");
                break;
        }
    }

    // 지정된 인덱스의 분자 프리팹을 랜덤 위치에 소환하는 함수
    void SpawnMolecule(int prefabIndex)
    {
        // 인덱스 유효성 검사
        if (prefabIndex >= moleculePrefabs.Length)
        {
            Debug.LogWarning("잘못된 프리팹 인덱스");
            return;
        }

        // 랜덤 위치 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 해당 위치에 프리팹 생성
        Instantiate(moleculePrefabs[prefabIndex], spawnPoint.position, Quaternion.identity);
    }
}
