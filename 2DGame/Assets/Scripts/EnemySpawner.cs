using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyData> enemysettings;
    [SerializeField] private int enemyCount;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTime;
    public static Dictionary<GameObject, Enemy> enemies;
    private Queue<GameObject> currentEnemies;

    private void Start()
    {
        enemies = new Dictionary<GameObject, Enemy>(); 
        currentEnemies = new Queue<GameObject>();

        for (int i = 0; i < enemyCount; i++)
        {
            var prefab = Instantiate(enemyPrefab);
            var script = prefab.GetComponent<Enemy>();
            prefab.SetActive(false);
            enemies.Add(prefab, script); 
            currentEnemies.Enqueue(prefab);
        }
        Enemy.OnEnemyOverFly += ReturnEnemy;
        StartCoroutine("Spawn");
    }  

    private IEnumerator Spawn()
    {
        if (spawnTime == 0)
        {
            spawnTime = 1;
        }
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (currentEnemies.Count > 0)
            {
                var enemy = currentEnemies.Dequeue();
                var script = enemies[enemy];
                enemy.SetActive(true);

                int rand = Random.Range(0, enemysettings.Count);
                script.Init(enemysettings[rand]);
                float xPos = Random.Range(-7, 7);
                enemy.transform.position = new Vector2(xPos, transform.position.y);
            }
        }
    }

    private void ReturnEnemy(GameObject _enemy)
    {
        _enemy.transform.position = transform.position;
        _enemy.SetActive(false);
        currentEnemies.Enqueue(_enemy);
    }
}
