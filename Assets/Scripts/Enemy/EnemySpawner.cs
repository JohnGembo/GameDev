using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    private float spawnTimer;
    public float spawnInterval;



    // Update is called once per frame
    void Update()
    {
        if(PlayerController.Instance.gameObject.activeSelf == true){
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnInterval)
            {
                spawnTimer = 0;
                SpawnEnemy(); 
            }
        }
    }


    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
