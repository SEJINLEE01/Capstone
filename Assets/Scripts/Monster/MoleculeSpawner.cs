using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    // ���� �����յ� => AlCl3, CaF2, Cl2, SiO2 ������ ����ؾ� ��
    public GameObject[] moleculePrefabs;

    // ���ڰ� ��ȯ�� �� �ִ� ��ġ�� (Transform �迭�� ���� ��ġ ��� ����)
    public Transform[] spawnPoints;

    // �� ������ ��� �ð� (�� ����)
    public float delayBetweenTurns = 2f;

    // ���� ���� ���� �� ��ȣ (0���� ����)
    private int cycle = 0;

    // ���� ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // �ϸ��� ���ڸ� �ڵ����� ��ȯ�ϴ� �ڷ�ƾ ����
        StartCoroutine(GameTurnRoutine());
    }

    // �ϸ��� ���ڸ� ��ȯ�ϰ� ���� �ð� ����ϴ� ��ƾ
    IEnumerator GameTurnRoutine()
    {
        // ���� ���� �� �ణ�� ��� �ð�
        yield return new WaitForSeconds(2f);

        // �� 3�ϱ��� �ݺ� (cycle: 0, 1, 2)
        while (cycle < 3)
        {
            StartNextCycle(); // ���� �Ͽ� �ش��ϴ� ���� ��ȯ
            cycle++; // ���� ������ �̵�
            yield return new WaitForSeconds(delayBetweenTurns); // 1�� ��� -> �� �ϸ��� 1�о� �־���
        }
        Debug.Log("��� ���� �������ϴ�.");
    }

    // ���� �Ͽ� �´� ����(����)���� ��ȯ�ϴ� �Լ�
    void StartNextCycle()
    {
        switch (cycle)
        {
            case 0:
                // 1��: AlCl3, CaF2 ��ȯ
                SpawnMolecule(0); // AlCl3
                SpawnMolecule(1); // CaF2
                break;
            case 1:
                // 2��: Cl2 ��ȯ
                SpawnMolecule(2); // Cl2
                break;
            case 2:
                // 3��: SiO2 ��ȯ
                SpawnMolecule(3); // SiO2
                break;
            default:
                // ���� ��� ������ ��
                Debug.Log("��� ���� �������ϴ�.");
                break;
        }
    }

    // ������ �ε����� ���� �������� ���� ��ġ�� ��ȯ�ϴ� �Լ�
    void SpawnMolecule(int prefabIndex)
    {
        // �ε��� ��ȿ�� �˻�
        if (prefabIndex >= moleculePrefabs.Length)
        {
            Debug.LogWarning("�߸��� ������ �ε���");
            return;
        }

        // ���� ��ġ ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // �ش� ��ġ�� ������ ����
        Instantiate(moleculePrefabs[prefabIndex], spawnPoint.position, Quaternion.identity);
    }
}
