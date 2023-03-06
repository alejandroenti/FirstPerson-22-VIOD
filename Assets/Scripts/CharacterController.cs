using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Camera cam;
    public Vector2 sensitivity;
    public Vector2 rotationLimit;
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        View();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (temp.magnitude > 1f) {
            temp = temp.normalized;
        }

        temp *= speed * Time.fixedDeltaTime;
        transform.position += transform.forward * temp.y + transform.right * temp.x;
    }
    void View()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + horizontal, transform.eulerAngles.z);

        float correctedangle = cam.transform.localEulerAngles.x;
        if (correctedangle > 90)
        {
            correctedangle -= 360;
        }
        vertical = Mathf.Clamp(correctedangle + vertical, rotationLimit.x, rotationLimit.y);

        cam.transform.localEulerAngles = new Vector3(vertical, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
    }
}