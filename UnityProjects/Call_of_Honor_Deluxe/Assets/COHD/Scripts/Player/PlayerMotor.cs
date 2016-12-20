using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    Rigidbody rb;
    Vector3 velocity;
    Vector3 rotation;
    Vector3 cameraRotation;

    [SerializeField]
    Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    public void CameraRotate(Vector3 rot)
    {
        cameraRotation = rot;
    }

    public void Jump(float jumpHeigt)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeigt, rb.velocity.z);
    }

    void FixedUpdate()
    {
        PreformMovement();
        PreformRotation();
    }

    void PreformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PreformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }
    }

    
}
