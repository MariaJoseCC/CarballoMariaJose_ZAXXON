using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Prefab que se va a spawnear
    [SerializeField] GameObject[] enemies;
    //Internalo de tiempo para spawnear
    [SerializeField] float interval = 0.5f;
    //Limites aleatorios de los ejes x e y
    [SerializeField] float limitX  = 5f;
    [SerializeField] float limitUp = 5f;
    [SerializeField] float limitDown = 5f;

    //Distancia a la que sale el primer enemigo intermedio
    float firstEnemyDistance;

    float distanceEntreEnemies;
    [SerializeField] PlayerManager playerManager;
    //Oleadas/bucles
    [SerializeField] int waves;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        EnemigosIntermedios();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int n = 0; n < waves; n++)
            {
                SacarLechuza(15);
            }
            interval = distanceEntreEnemies / playerManager.speed;
            yield return new WaitForSeconds(interval);
        }
    }
    void EnemigosIntermedios()
    { 
    float distanceToFill = transform.position.z - firstEnemyDistance;
    float numberOfEnemiesf = distanceToFill / distanceEntreEnemies;
    int ciclos = Mathf.FloorToInt(numberOfEnemiesf);
        for (int i = 0; i < ciclos; i++)
        {
        
        SacarLechuza(distanceToFill);
        distanceToFill -= distanceEntreEnemies;
        
        }
    }
 
    void SacarLechuza(float distanceZ=0)
    { 
    float randomX = Random.Range(-limitX, limitX);
    float randomY = Random.Range(limitDown, limitUp);
    //Instanciamos en posición aleayoria en x e y pero en z donde está el spawner
    Vector3 instPos = new Vector3(randomX, randomY, transform.position.z - distanceZ);
    int r = Random.Range(0, enemies.Length);
    Instantiate(enemies[r], instPos, Quaternion.identity);
    }
}
