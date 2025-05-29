using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int count;
    [SerializeField]
    private float minDistance;

    const float minX = -10;
    const float maxX = 10;
    const float minZ = 100;
    const float maxZ = 620;

    private List<Vector3> spawnedPos = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnTarget();
    }

    void SpawnTarget()
    {
        int spawned = 0;
        int tryLimit = 1000;
        int tries = 0;

        while (spawned < count && tries < tryLimit)
        {
            tries++;

            // Генеруємо рандомну точку в колі (від -1 до 1) і масштабуємо до діапазону
            Vector2 randomPoint = Random.insideUnitCircle;
            float randomX = Mathf.Lerp(minX, maxX, (randomPoint.x + 1f) / 2f);
            float randomZ = Mathf.Lerp(minZ, maxZ, (randomPoint.y + 1f) / 2f);
            float y = 0f;

            Vector3 candidatePos = new Vector3(randomX, y, randomZ);

            bool canSpawn = true;
            foreach (var pos in spawnedPos)
            {
                if (Vector3.Distance(pos, candidatePos) < minDistance)
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                Instantiate(target, candidatePos, Quaternion.Euler(0f, 180f, 0f));
                spawnedPos.Add(candidatePos);
                spawned++;
            }
        }

        if (spawned < count)
        {
            Debug.LogWarning("Не вдалося розмістити всі цілі з заданою мінімальною відстанню.");
        }

        //for (int i = 0; i < count; i++)
        //{
        //    Vector2 randomPoint = Random.insideUnitSphere;
        //    float randomX = Mathf.Lerp(minX, maxX, (randomPoint.x + 1f) / 2f);
        //    float randomZ = Mathf.Lerp(minZ, maxZ, (randomPoint.y + 1f) / 2f);
        //    Instantiate(target, new Vector3(randomX, 0f, randomZ), Quaternion.Euler(-90f, 180f, 0f));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
