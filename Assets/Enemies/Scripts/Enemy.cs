using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Atributos comunes para todos los enemigos
    public float health { get; protected set; }
    public float walkSpeed { get; protected set; }
    public float runSpeed { get; protected set; }
    public float detectionRange { get; protected set; }
    public float damageGenerate { get; protected set; }
    public float distanceAttack { get; protected set; }

    protected Animator animator;
    protected GameObject player;
    private Rigidbody rb;

    protected float player_distance; // Distancia del jugador
    protected string action; // Animacion
    protected int routine; // Rutina de comportamiento
    private float timer;   // Cronometro
    private Quaternion targetRotation;
    public bool attacking = false; // Cambia su estado para saber cuando se toco al jugador para atacarlo o de casualidad

    // variables para el suavizado de la rotacion
    private bool isRotating = false;
    private float rotationSpeed = 2.0f; // Ajusta la velocidad de rotaci�n
  
    //[SerializeField] GameObject _activar_portal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        attacking = false;

        // Si el jugador esta cerca y:
        if (DetectPlayer())
        {
            // detecta al jugador y este esta dentro de su rango de ataque procede a atacarlo
            if (DistanceToPlayer() <= distanceAttack)
            {
                Attack(); 
            }
            // detecta al jugador y este esta fuera del area de ataque, procede a acercarse
            if (DistanceToPlayer() > distanceAttack)
            {
                MoveTowardsPlayer();
            }
        }
        // En caso de que no detecte al jugador cerca continua con su rutina
        else 
        { 
            BehaviourRoutine(); 
        }
    }

    // Logica de comportamiento segun una rutina basica
    public virtual void BehaviourRoutine()
    {
        // Contador
        timer += Time.deltaTime;

        // Cada 4 segundos el enemigo volvera a elegir una accion a realizar
        if (timer >= 4)
        {
            routine = Random.Range(0, 2);
            timer = 0;
        }

        // Si el enemigo esta vivo elije una accion a realizar
        if (health > 0)
        {
            switch (routine)
            {
                case 0: // Quedarse quieto
                    SetAnimationFalse();
                    break;
                case 1: // Rotar
                    RotateEnemy();
                    break;
                case 2: // Caminar
                    Walk();
                    break;
            }
        }
    }

    // Funcion para esquivar paredes
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Desactivar la animacion de caminar
            animator.SetBool("Walk", false);

            // Sumar 90 grados a la direccion actual
            transform.Rotate(0, 90, 0);
        }
    }

    // Rotacion del enemigo a un angulo aleatorio
    protected void RotateEnemy()
    {
        // Elijo un angulo random
        float degree = Random.Range(0, 360);

        // Roto al enemigo
        targetRotation = Quaternion.Euler(0, degree, 0);
        routine++;
    }

    // Movimiento basico del enemigo
    protected void Walk()
    {
        // Rota el Rigidbody hacia la direcci�n de la rotaci�n objetivo
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, 0.5f));

        // Mueve el Rigidbody en la direcci�n hacia adelante
        rb.MovePosition(rb.position + transform.forward * walkSpeed * Time.deltaTime);

        // Actualiza la animaci�n de caminar
        SetAnimation("Walk");
    }

    // Calcula la distancia a la que se encuentra del player
    protected float DistanceToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer;
    }
    
    // Deteccion del jugador con un rango personalizado por cada enemigo, devuelve verdadero si el jugador esta dentro de la zona del enemigo
    protected bool DetectPlayer()
    {
        if (DistanceToPlayer() <= detectionRange)
        {
            return true;
        }
        else { return false; }  
    }

    //corrutina para suavisar el giro
    private IEnumerator SmoothRotation()
    {
        isRotating = true;

        // Mientras el objeto no haya alcanzado la rotaci�n deseada
        while (Quaternion.Angle(rb.rotation, targetRotation) > 0.1f)
        {
            // Interpolamos la rotaci�n suavemente usando Slerp
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

            // Esperamos hasta el siguiente frame
            yield return null;
        }

        // Aseguramos que la rotaci�n final sea exactamente la deseada
        rb.MoveRotation(targetRotation);

        isRotating = false;
    }

    // Movimiento hacia el jugador
    protected void MoveTowardsPlayer()
    {
        // Calcula la direcci�n hacia el jugador y normaliza la direcci�n en el plano XZ (y = 0)
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0;

        // Rota el Rigidbody hacia la direcci�n del jugador
        rb.MoveRotation(Quaternion.LookRotation(direction));

        // Mueve el Rigidbody hacia adelante en la direcci�n del movimiento
        rb.MovePosition(rb.position + direction * runSpeed * Time.deltaTime);

        // Actualiza la animaci�n de caminar
        SetAnimation("Walk");
    }

    // Ataque
    protected void Attack()
    {
        // Calcula la direcci�n hacia el jugador
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;

        // Calcula la rotaci�n para mirar al jugador
        var rotation = Quaternion.LookRotation(lookPos);

        // Rota el Rigidbody hacia el jugador utilizando MoveRotation
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, rotation, 5f));

        // Inicia la animaci�n de ataque
        SetAnimation("Attack");

        // Marca que est� atacando
        attacking = true;
    }

    // Recibe dano
    public void TakeDamage(float damage)
    {
        /*Debug.Log("dano al esqueleto!");
        Debug.Log(health);
        Debug.Log("-------------------");*/
        // Animacion de recibir da�o
        SetAnimation("Damage");

        // Restar vida
        health -= damage;

        // Actualizar vida en el animator controller
        animator.SetFloat("Health", health);

        // En caso de que la vida sea menor a 1 el player muere
        if (health <= 0) Die();
    }

    // Metodo para manejar la muerte
    protected virtual void Die()
    {
        SetAnimation("Die");
        Destroy(this);
        /// hay que agregar una demora para que se reproduzca la animacion de muerte
    }

    // Metodo para manejar los cambios de animaciones
    protected void SetAnimation(string action)
    {
        SetAnimationFalse();

        switch (action)
        {
            case "Still": // Quieto
                SetAnimationFalse();
                break;
            case "Walk": // Caminar
                animator.SetBool("Walk", true);
                break;
            case "Attack": // Atacar
                animator.SetBool("Attack", true);
                break;
            case "Damage": // Recibir dano
                animator.SetBool("Damage", true);
                break;
            case "Die": // Morir
                animator.SetFloat("Health", 0);
                break;
        }
    }

    // Metodo para establecer las animaciones en false
    protected void SetAnimationFalse()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Damage", false);
    }
}