using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject enemy;

    private int maxCountBot = GlobalState.getCountBot();
    private GameObject[] bots;
    private float lastCheck = 0f;


    // Start is called before the first frame update
    void Start()
    {
        initVarables();
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCheck <= Time.time && isAllBotDie())
        {
            GlobalState.restartGame();
            return;
        }
    }

    private void spawnEnemy()
    {
        for (int i = 0; i < maxCountBot; i++)
        {
            Transform enemyTrans = spawners[Random.Range(0, spawners.Length)];

            bots[i] = Instantiate(enemy, enemyTrans.position, enemyTrans.rotation);

            BotState botState = bots[i].GetComponent<BotState>();

            botState.setPlayerName(GlobalState.getNamesBot()[Random.Range(0, 29)]);
        }

    }


    private bool isAllBotDie()
    {
        lastCheck = Time.time + 2;

        for (int i = 0; i < maxCountBot; i++)
        {
            if (bots[i] != null)
                return false;
        }

        return true;
    }

    private void initVarables()
    {
        bots = new GameObject[maxCountBot];
    }
}
