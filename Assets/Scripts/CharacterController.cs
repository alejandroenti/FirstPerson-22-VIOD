using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;

    public Vector2 sensitivity;
    public Vector2 rotationLimit;
    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        View();
        Move();
    }

    void Move() 
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += transform.forward * vertical + transform.right * horizontal;
    }

    void View()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + horizontal, transform.eulerAngles.z);
        cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x + vertical, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
    }
}
