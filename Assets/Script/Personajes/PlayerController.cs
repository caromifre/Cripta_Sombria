using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    [SerializeField] private float speed = 3f; // Velocidad de movimiento normal
    [SerializeField] private float sprintSpeed = 5f; // Velocidad al correr
    [SerializeField] private float smoothTime = 0.1f; // Tiempo de suavizado
    [SerializeField] private FollowCamera cameraScript; // Inyectar referencia desde el Inspector

    private float currentVelocity = 0f; // Variable para SmoothDamp

    private void Update()
    {
        Controller();
    }

    // Metodo principal para manejar el movimiento
    private void Controller()
    {
        Vector3 inputDirection = GetInputDirection();
        if (inputDirection.magnitude > 0)
        {
            RotatePlayer(inputDirection);
            MovePlayer(inputDirection);
            _anim.SetBool("Walk", true);
        }
        else
        {
            _anim.SetBool("Walk", false);
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
        // Rotacion suavizada
        float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Quaternion.LookRotation(direction).eulerAngles.y, ref currentVelocity, smoothTime);

        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    // Metodo para mover al jugador
    private void MovePlayer(Vector3 direction)
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
    }
}