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
    Vector3 velocity;
    Vector3 currentRot;
    float maxRotationX = 40f;
    float maxRotationZ = 40f;
   [SerializeField] float smoothTime = 0.5f;

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
        inputActions.Player.Rotate.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += _ => rotation = 0f;
        
        

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
        Vector3 vectorRotZ = Vector3. forward * maxRotationZ * moveY;
        Vector3 vectorRotX = Vector3.right * maxRotationX * moveX;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }
   
      
    
    
}
