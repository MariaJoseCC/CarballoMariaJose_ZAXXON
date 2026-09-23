using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float distance = -10f;
    [SerializeField] float verticalOffset = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 offset = new Vector3(0f, verticalOffset, distance);
        transform.position = playerTransform.position + offset;
      
    }
}
