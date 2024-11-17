using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    private void Update()
    {
        Controller();
    }

    // Metodo principal para manejar el movimiento
    private void Controller()
    {
        Vector3 direction = GetInputDirection();
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Cambiamos las animaciones segun el estado
        if (direction.magnitude > 0)
        {
            // Verificamos si la direccion no es cero
            if (direction != Vector3.zero)
            {
                rotationManager.Rotate(ref characterTransform, ref rb, ref direction, smoothTime, ref currentVelocity);
            }
            MovePlayer(direction);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animationManager.RunningAnimation();
            }
            else
            {
                animationManager.WalkingAnimation();
            }
        }
        else
        {
            animationManager.IdleAnimation();
        }

        // Verificar si se hizo click izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            TryInteractWithObject();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UseHealthPotion();
        }
        if (Input.GetButton("Fire2"))
        {
            defenseManager.StartDefending();
        }
        else
        {
            defenseManager.StopDefending();
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

    // Metodo para mover al jugador
    private void MovePlayer(Vector3 direction)
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        Vector3 newPosition = rb.position + direction * currentSpeed * Time.deltaTime;
        direction.y = 0;
        rb.MovePosition(newPosition);
    }

    // Rotar el persoaje al hacer click sobre un item recolectable o enemigo con la clase RotationManager
    private void RotatePlayerTowardsItem(Vector3 objectPosition)
    {
        // Establezco la direccion objetivo
        Vector3 direction = (objectPosition - characterTransform.position).normalized;

        // Verifico si la direccion no es cero
        if (direction != Vector3.zero)
        {
            rotationManager.Rotate(ref characterTransform, ref rb, ref direction, smoothTimeItem, ref currentVelocityItem);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Resetea la velocidad cuando colisiona con algo
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Metodo para interactuar con enemigos y/o items recolectables
    public void TryInteractWithObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Recolectable", "Enemy")))
        {
            float distance = Vector3.Distance(characterTransform.position, hit.transform.position);
            if ((distance <= distanceAttack && hit.collider.CompareTag("Enemy")) || (distance <= interactRange && hit.collider.CompareTag("Item")))
            {
                RotatePlayerTowardsItem(hit.transform.position);

                if (distance <= distanceAttack && hit.collider.CompareTag("Enemy") && !attacking)
                {
                    // Registrar el último ataque y activar la animación
                    attacking = true;
                    animationManager.AttackAnimation();
                    // Si el enemigo implementa IInteractable, ejecutar la interacción
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                    interactable?.Interact(this);
                    // Esperar la duración de la animación antes de permitir otro ataque
                    Invoke(nameof(ResetAttack), 1.5f);
                }

                if (distance <= interactRange && hit.collider.CompareTag("Item"))
                {
                    // Interactuar con otros objetos recolectables
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                    interactable?.Interact(this);
                }
            }
            else
            {
                Debug.Log("El objeto está demasiado lejos.");
            }
        }
    }
    public void ResetAttack()
    {
        attacking = false;
    }
}