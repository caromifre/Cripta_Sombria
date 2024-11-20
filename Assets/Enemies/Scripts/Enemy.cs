using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character, IInteractable
{
    // Atributos comunes para todos los enemigos
    public float detectionRange { get; protected set; }

    // Player
    protected GameObject player;

    protected float player_distance; // Distancia del jugador
    protected string action; // Animacion
    protected int routine; // Rutina de comportamiento
    private float timer;   // Cronometro
    private Quaternion targetRotation;

    // Variables para el suavizado de la rotacion
    private float rotationSpeed = 2.0f; // Ajusta la velocidad de rotacion
    public void Start()
    {
        isPlayer = false;

    }
    private void Update()
    {
     
        if (Time.timeScale == 0f) return;//pausar a los enemigos

        attacking = false;
        // Si el jugador está cerca y la vida es mayor que 0
        if (DetectPlayer() && health > 0)
        {
            animationManager.IdleAnimation();

            // Si está en rango de ataque y no está atacando
            if (DistanceToPlayer() <= distanceAttack && !attacking)
            {
                // Ejecutar la rutina de ataque
                Attack();
                audioSourceManager.StopFootstepSound();
            }
            // Si el jugador está fuera del rango de ataque, moverse hacia él
            else if (DistanceToPlayer() > distanceAttack && !attacking)
            {
                MoveTowardsPlayer();
                audioSourceManager.PlayFootstepSound(false, walkSound, runSound);
            }
        }
        // Si el jugador no está cerca, continuar con la rutina de comportamiento
        else if (!DetectPlayer() && health > 0)
        {
            BehaviourRoutine();
        }

        // Si la salud es menor que 0, actualizar la animación de muerte o salud
        if (health <= 0)
        {
            animationManager.UpdateHealthAnimation(health);
        }
    }
    //audioSourceManager.DamageEnemy(damageSound);
    public void Interact(PlayerBehaviour player)
    {
        Debug.Log($"{player.name} ha interactuado con {this.name}");
        //TakeDamage(player.damageGenerate);
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
                    animationManager.IdleAnimation();
                    audioSourceManager.StopFootstepSound();
                    break;
                case 1: // Rotar
                    RotateEnemy();
                    audioSourceManager.StopFootstepSound();
                    break;
                case 2: // Caminar
                    Walk();
                    audioSourceManager.PlayFootstepSound(false, walkSound, runSound);
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
            animationManager.IdleAnimation();

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
        // Rota el Rigidbody hacia la dirección de la rotación objetivo
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, 0.5f));

        // Mueve el Rigidbody en la dirección hacia adelante
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);

        // Actualiza la animación de caminar
        animationManager.WalkingAnimation();
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

    // Corrutina para suavisar el giro
    private IEnumerator SmoothRotation()
    {
        // Mientras el objeto no haya alcanzado la rotacion deseada
        while (Quaternion.Angle(rb.rotation, targetRotation) > 0.1f)
        {
            // Interpolamos la rotacion suavemente usando Slerp
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

            // Esperamos hasta el siguiente frame
            yield return null;
        }

        // Aseguramos que la rotación final sea exactamente la deseada
        rb.MoveRotation(targetRotation);
    }

    // Movimiento hacia el jugador
    protected void MoveTowardsPlayer()
    {
        // Calcula la dirección hacia el jugador y normaliza la dirección en el plano XZ (y = 0)
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0;

        // Rota el Rigidbody hacia la dirección del jugador
        rb.MoveRotation(Quaternion.LookRotation(direction));

        // Mueve el Rigidbody hacia adelante en la dirección del movimiento
        rb.MovePosition(rb.position + direction * sprintSpeed * Time.deltaTime);

        // Actualiza la animación de caminar
        animationManager.WalkingAnimation();
    }

    // Ataque
    protected void Attack()
    {
        // Marca que esta atacando
        attacking = true;

        // Calcula la dirección hacia el jugador
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;

        // Calcula la rotación para mirar al jugador
        var rotation = Quaternion.LookRotation(lookPos);

        // Rota el Rigidbody hacia el jugador utilizando MoveRotation
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, rotation, 5f));

        // Inicia la animacion de ataque
        animationManager.AttackAnimation();
    }
}