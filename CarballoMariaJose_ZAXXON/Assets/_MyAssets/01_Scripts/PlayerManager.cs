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
    [SerializeField] float smoothTime = 0.2f;
    float myLimitX = 15f;
    float myLimitY = 15f;

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
        speed = 20f;

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
       MovePlayer();
       Rotation();

    }

    //Rotación del jugador en X e Y
    void Rotation()
    {
        
        Vector3 vectorRotZ = Vector3.forward * -maxRotationZ * moveX;
        Vector3 vectorRotX = Vector3.right * -maxRotationX * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;

    }

    //Movimiento del jugador en X e Y
    void MovePlayer()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (CheckPositionX(myLimitX) == true)
        {
            transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime, Space.World);
        }
        if (CheckPositionY(myLimitY) == true)
        {
            transform.Translate(Vector3.up * lateralSpeed * moveY * Time.deltaTime, Space.World);
        }

        transform.Rotate(Vector3.forward * rotation * rotationSpeed * Time.deltaTime * -360);
    }


    //Limites del jugador en un área, X e Y
    bool CheckPositionX(float myLimitX)
    {
        bool inLimit;
         float posX = transform.position.x;
        if (posX > myLimitX && moveX > 0)
        {
            //transform.position = new Vector3(this.myLimitX, 0, 0);
            inLimit = false;
        }
        else if (posX < -myLimitX && moveX < 0)
        {
            //transform.position = new Vector3(-this.myLimitX, 0, 0);
            inLimit = false;
        }
        else
        {
            inLimit = true;
        }
        return inLimit;

    }
    bool CheckPositionY(float myLimitY)
    {
        bool inLimit;
        float posY = transform.position.y;
        if (posY > myLimitY && moveY > 0)
        {
           // transform.position = new Vector3(0, myLimitY, 0);
            inLimit = false;
        }
        else if (posY < -myLimitY && moveY < 0)
        {
           // transform.position = new Vector3(0, -myLimitY, 0);
            inLimit = false;
        }
        else
        {
            inLimit = true;
        }
        return inLimit;

    }

}
