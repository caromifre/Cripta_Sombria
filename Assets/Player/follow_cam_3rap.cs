using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float mouseSensitivity = 3f;
    public float smoothSpeed = 10f;
    public float rotationLerpSpeed = 10f;

    private float yaw;
    private float pitch;
    public float minPitch = -10f;
    public float maxPitch = 60f;

    void LateUpdate()
    {
        // Solo rotar la cámara si se mantiene el botón derecho
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Suavizar la posición y orientación
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 1.5f);

        // Sincronizar rotación del jugador con cámara
        Vector3 forward = transform.forward;
        forward.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(forward);
        player.rotation = Quaternion.Lerp(player.rotation, targetRotation, rotationLerpSpeed * Time.deltaTime);
    }
}
