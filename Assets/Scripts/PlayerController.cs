using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float Speed = 3f;
    [SerializeField]
    private float lookSpeed = 3f;
    [SerializeField]
    private AudioSource WalkSound;

    private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * Speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSpeed;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;

        motor.RotateCam(-camRotation);

        WalkSoundPlay(velocity);

    }
    
    private void WalkSoundPlay(Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            WalkSound.enabled = true;
            WalkSound.loop = true;
        }
        else if(velocity == Vector3.zero)
        {
            WalkSound.enabled = false;
            WalkSound.loop = false;
        }
    }
}
