using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Posición relativa a mantener detrás del jugador
    public float smoothSpeed = 5f; // Suavizado del movimiento de cámara
    public float mouseSensitivity = 3f; // Sensibilidad del mouse para rotar
    private float currentYaw = 0f;

    void LateUpdate()
    {
        // Rotar alrededor del jugador con el mouse
        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        // Calcular posición deseada
        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Movimiento suave hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Mirar al jugador
        transform.LookAt(player.position + Vector3.up * 1.5f); // Opcional: mirar un poco por encima del jugador
    }
}
