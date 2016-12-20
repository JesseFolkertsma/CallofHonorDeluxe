using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    PlayerMotor motor;
    Transform model;

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float sensitivity = 3f;
    [SerializeField]
    float jumpHeight = 5f;

    public LayerMask playerLayer;
    public bool isGrounded;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        model = transform.GetChild(0);
    }

    void Update()
    {
        CheckInput();
        CheckRaycasts();
    }

    void CheckInput()
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            motor.Jump(jumpHeight);
        }
    }

    void CheckRaycasts()
    {
        RaycastHit hit;
        if(Physics.Raycast(model.position, Vector3.down, out hit, 1.1f, playerLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
