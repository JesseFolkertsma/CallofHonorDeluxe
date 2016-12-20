using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    PlayerMotor motor;

    [SerializeField]
    float speed = 5f;
    float sensitivity = 3f;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * yMove;
        Vector3 _velocity = (moveHorizontal + moveVertical).normalized * speed;
        motor.Move(_velocity);

        //Calculate player rotation
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * sensitivity;
        motor.Rotate(rotation);

        //Calculate camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0, 0) * sensitivity;
        motor.CameraRotate(-camRotation);
    }

}
