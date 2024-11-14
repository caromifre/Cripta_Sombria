using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player; // El jugador al que debe seguir la camara
    public Vector3 defaultOffset = new Vector3(-10, 15, -10); // Posicion inicial de la camara
    public Vector3 flippedOffset = new Vector3(10, 15, 10); // Posicion de la camara con rotacion
    public float rotationSpeed = 70f; // Velocidad de rotacion de la camara

    private Vector3 currentOffset; // Offset actual de la camara
    public bool isCameraFlipped = false; // �Esta la camara dada vuelta?

    private void Awake()
    {
        currentOffset = defaultOffset; // Offset por defecto
    }

    private void LateUpdate()
    {
        // Actualizamos la posicion de la camara
        transform.position = player.position + currentOffset;

        // La camara siempre mira al jugador
        transform.LookAt(player);

        // Rotacion con las teclas Q y E
        GirarCamara();
    }

    private void GirarCamara()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            // Si toca Q o E se cambia la vista de la camara, tambien podria hacerse con un boton solo, pero asi genera mayor comodidad, ademas a futuro se pueden agregar mas angulos
            CambiarPosicionCamara();
        }
    }

    private void CambiarPosicionCamara()
    {
        // Alterna entre las posiciones
        SetPosicion(isCameraFlipped ? defaultOffset : flippedOffset);
    }

    private void SetPosicion(Vector3 newOffset)
    {
        // Cambia a la vista opuesta
        currentOffset = newOffset;
        RotarCamara();
        isCameraFlipped = !isCameraFlipped;
    }

    private void RotarCamara()
    {
        // Rota la camara
        transform.RotateAround(player.position, Vector3.up, -rotationSpeed * Time.deltaTime);
    }
}