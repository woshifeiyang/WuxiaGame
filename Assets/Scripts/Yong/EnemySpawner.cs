using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoSingleton<EnemySpawner>
{
    public float enemySpawnCd;
    public float spawnCdFactor = 0.1f;
    public string currentPool;

    private const float ScreenWidthUnit = 8.5f;
    private const float ScreenHeightUnit = 19f;

    public int enemySpawningCount = 0;
    public int monsterOnField = 0;
    public float timer = 0f;

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    public void InitEnemySpawner()
    {
        currentPool = "101";
=======
>>>>>>> Stashed changes
    private Dictionary<int, float> difficultyOfEnemyPool = new Dictionary<int, float>();

    protected override void InitAwake()
    {
        base.InitAwake();
        objectPoolHolder = GetComponent<EnemyObjectPool>();
<<<<<<< Updated upstream

        for (int i = 0; i < 5; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                int tempId = 100 + i * 10 + j;
                difficultyOfEnemyPool.Add(tempId, 0f);
            }
        }
    }
=======
>>>>>>> Stashed changes

        for (int i = 0; i < 5; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                int tempId = 100 + i * 10 + j;
                difficultyOfEnemyPool.Add(tempId, 0f);
            }
        }
>>>>>>> b00a4d0f7b222e81146e4e0c5fb8187861f0472b
    }

    private void FixedUpdate()
    {
        //UpdateSpawnCd();
        
        timer += Time.fixedDeltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            enemySpawningCount = 0;
        }
    }

    IEnumerator UpdateCurrentPool()
    {
        yield return null;
    }
    
    void UpdateSpawnCd()
    {
        float spawnCdResult = 1f;

        int poolCurrentCount = EnemyObjectPool.Instance.EnemyNumInPool[currentPool];
        int poolMaxCount = EnemyObjectPool.Instance.EnemyNumInPool[currentPool + "Max"];
        monsterOnField = EnemyObjectPool.Instance.EnemyNumInPool[currentPool + "OnField"];

        spawnCdResult = (float)monsterOnField / (float)poolMaxCount;

        float tempSpawnSpeed = 1 / spawnCdResult;
        tempSpawnSpeed *= spawnCdFactor;

        enemySpawnCd = 1/tempSpawnSpeed;
    }

    public void SpawnEnemy()
    {
        StartCoroutine(UpdateCurrentPool());
        StartCoroutine(SpawnEnemy_C());
    }
    
    IEnumerator SpawnEnemy_C()
    {
        float cd = enemySpawnCd;
        while (true)
        {
            yield return new WaitForSeconds(cd);
            GameObject enemy = EnemyObjectPool.Instance.GetObjectFromPool(currentPool); //  后期要改
            if (enemy)
            {
                enemy.transform.position = GetRandomPosition();
                enemy.transform.SetParent(EnemyObjectPool.Instance.objectOutOfPool.transform);
                enemy.SetActive(true);

                enemySpawningCount++;
            }
            else
            {
                Debug.Log("enemy is null, please check whether the name of pool is right or pool is null");
            }
            cd = enemySpawnCd;
        }
    }

    private void SetEnemySpawningSpeed(int id, float targetSpeed)
    {
        difficultyOfEnemyPool[id] = targetSpeed;
    }

    private void ClearEnemySpawningSpeed()
    {
        foreach(KeyValuePair<int,float> entry in difficultyOfEnemyPool)
        {
            difficultyOfEnemyPool[entry.Key] = 0f;
        }
    }

    private void SetEnemySpawningSpeed(int id, float targetSpeed)
    {
        difficultyOfEnemyPool[id] = targetSpeed;
    }

    private void ClearEnemySpawningSpeed()
    {
        foreach(KeyValuePair<int,float> entry in difficultyOfEnemyPool)
        {
            difficultyOfEnemyPool[entry.Key] = 0f;
        }
    }
    
    public static Vector2 GetRandomPosition()
    {
        float playerPositionX = PlayerController.Instance.GetPlayerPosition().x;
        float playerPositionY = PlayerController.Instance.GetPlayerPosition().y;

        float direction = Random.Range(0, 100);
        // 生成在玩家左右两侧
        if (direction <= 30)
        {
            float x;
            float y = Random.Range(playerPositionY - (ScreenHeightUnit / 2), playerPositionY + (ScreenHeightUnit / 2));
            int left = Random.Range(0, 100);
            float randomNum = Random.Range(0.5f, 1.5f);
            if (left <= 50)
            {
                x = playerPositionX - (ScreenWidthUnit / 2) - 0.3f;
                //x = Random.Range(playerPositionX - (screenWidthUnit/2), playerPositionX - (screenWidthUnit/2) - randomNum);
            }
            else
            {
                x = playerPositionX + (ScreenWidthUnit / 2) + 0.3f;
                //x = Random.Range(playerPositionX + (screenWidthUnit/2), playerPositionX + (screenWidthUnit/2) + randomNum);
            }

            return new Vector2(x, y);
        }
        // 生成在玩家上下两侧
        else
        {
            float randomNum = Random.Range(0.0f, ScreenWidthUnit);
            float x = Random.Range(playerPositionX + randomNum, playerPositionX - randomNum);
            float y;
            int top = Random.Range(0, 100);
            if (top <= 65)
            {
                y = playerPositionY + (ScreenHeightUnit / 2) + 1f;
                //y = Random.Range(playerPositionY + 6.0f, playerPositionY + 6.0f + randomNum);
            }
            else
            {
                y = playerPositionY - (ScreenHeightUnit / 2) + 1f;
                //y = Random.Range(playerPositionY - 6.0f, playerPositionY - 6.0f - randomNum);
            }
            return new Vector2(x, y);
        }
        
    }
}
