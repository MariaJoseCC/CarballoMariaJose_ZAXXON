using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float lateralSpeed;
    InputActions inputActions;
    float moveX;
    float moveY;
    float rotation;
    [SerializeField] float rotationSpeed;
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
        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += ctx => moveY = 0f;
        inputActions.Player.MoveX.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => rotation = 0f;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime);
        transform.Translate(Vector3.up * lateralSpeed * moveY * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotation * rotationSpeed * Time.deltaTime * -360);
    }
}
