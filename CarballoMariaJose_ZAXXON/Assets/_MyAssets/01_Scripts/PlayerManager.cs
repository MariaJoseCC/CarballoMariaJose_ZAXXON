using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float lateralSpeed;
    InputActions inputActions;
    float moveX;
    InputActions player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Shoot()
    {
        print("POOM");
    }
    private void Awake()
    {

        inputActions = new InputActions();

        inputActions.Player.Shoot.started += _ => Shoot();
        inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += ctx => moveX = 0f;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime);
    }
}
