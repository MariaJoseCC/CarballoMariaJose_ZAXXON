using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Prefab que se va a spawnear
    [SerializeField] GameObject enemy;
    //Internalo de tiempo para spawnear
    [SerializeField] float interval = 0.5f;
    //Limites aleatorios de los ejes x e y
    [SerializeField] float limitX;
    [SerializeField] float limitUp;
    [SerializeField] float limitDown;

    //Distancia a la que sale el primer enemigo intermedio
    float firstEnemyDistance = 0f;

    //Oleadas/bucles
    [SerializeField] int waves;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemiosIntermedios()
    { 
    float firstEnemy = transform.position.z - firstEnemyDistance;
        float n = firstEnemy / distanceEntreEnemies;

    }

    void SacarLechuza(float distanceZ=0)
    { 
    float randomX = Random.Range(-limitX, limitX);
    float randomY = Random.Range(limitDown, limitUp);
    //Instanciamos en posición aleayoria en x e y pero en z donde está el spawner
    Vector3 despl = new Vector3(randomX, randomY, distanceZ);
    Vector3 instPost = transform.position + despl;
    Instantiate(enemy, instPost, Quaternion.identity);
    }
}
