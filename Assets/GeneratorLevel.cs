using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    [SerializeField] private GameObject LevelPrefab;
    [SerializeField] private int spawnDistance;
    [SerializeField] private int platformCount;
    void Start()
    {
        for (int i = 0; i < platformCount; i++)
        {
            float y = 0;
            if (i != 0) y = Random.Range(-3f, 3f); 
            Vector2 position = new Vector2(spawnDistance * i, y);
            Instantiate(LevelPrefab, position, Quaternion.identity);
        }
    }

}
