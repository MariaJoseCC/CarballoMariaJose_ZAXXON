using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //la velocidad que la vamos a obtener del jugador
    float speed;

    //Component5e del jugador
    [SerializeField] PlayerManager playerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Para acceder al objeto (jugador) que es el que tiene le componente de playerManager
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Para acceder a su coimponente
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        transform.Translate(Vector3.back * speed * Time.deltaTime);

    }
}
