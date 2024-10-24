using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float hor;
    public float ver;
    public Vector2 sensibility;
    private new Transform camera;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Mouse X");
        ver = Input.GetAxis("Mouse Y");
        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }
        if (ver != 0)
        {
            //camera.Rotate(Vector3.left * ver * sensibility.y);
            angle = (camera.localEulerAngles.x - ver * sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -75, 75);

            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
