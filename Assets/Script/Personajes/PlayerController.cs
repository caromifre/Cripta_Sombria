using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    [SerializeField] private float speed = 1f; // Velocidad de movimiento normal
    [SerializeField] private float sprintSpeed = 2f; // Velocidad al correr
    [SerializeField] private float smoothTime = 0f; // Tiempo de suavizado
    private float currentVelocity = 0.1f; // Variable para SmoothDamp
    private FollowCamera cameraScript; // Inyectar referencia desde el Inspector
    private Rigidbody rb;
    private bool isSprinting = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraScript = Camera.main.GetComponent<FollowCamera>();
    }
    private void Update()
    {
        Controller();
    }

    // Metodo principal para manejar el movimiento
    private void Controller()
    {
        Vector3 inputDirection = GetInputDirection();
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Cambiamos las animaciones según el estado
        if (inputDirection.magnitude > 0)
        {
            RotatePlayer(inputDirection);
            MovePlayer(inputDirection);
            _anim.SetBool("Walk", !isSprinting);
            _anim.SetBool("Run", isSprinting);
        }
        else
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Run", false);
        }
    }

    // Obtener la direccion basada en la entrada del jugador
    private Vector3 GetInputDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Direccion normalizada del movimiento
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Invertir direccion si la camara esta volteada
        if (cameraScript != null && cameraScript.isCameraFlipped)
        {
            return -direction;
        }

        return direction;
    }

    // Metodo para rotar al jugador hacia la direccion de movimiento
    private void RotatePlayer(Vector3 direction)
    {
        // Angulo objetivo basado en la direccion
        float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Quaternion.LookRotation(direction).eulerAngles.y, ref currentVelocity, smoothTime);

        // Rotacion al Rigidbody de forma suave
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        rb.MoveRotation(targetRotation); // Usamos MoveRotation en lugar de transform.rotation
    }

    // Metodo para mover al jugador
    private void MovePlayer(Vector3 direction)
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        Vector3 newPosition = rb.position + direction * currentSpeed * Time.deltaTime;
        direction.y = 0;
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Resetea la velocidad cuando colisiona con algo
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}