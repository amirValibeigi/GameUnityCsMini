using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnEnemy()
    {
        foreach (Transform enemyTrans in spawners)
        {
            Instantiate(enemy, enemyTrans.position, enemyTrans.rotation);
        }

    }
}
