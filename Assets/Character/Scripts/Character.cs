using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tanto los enemigos como el player heredan de character ya que tienen algunas caracteristicas y funciones en comun
public class Character : MonoBehaviour, IAttacker
{
    // Caracteristicas en comun de enemigos y player
    public float health { get; protected set;} // Vida
    public float maxHealth { get; protected set; } // Vida max
    public float damageGenerate; // Dano que genera al pegar
    protected float speed; // Velocidad de movimiento normal
    protected float sprintSpeed; // Velocidad al correr
    public bool isSprinting = false; // False = caminando / True = corriendo
    public float distanceAttack;
    public bool attacking = false; // Cambia su estado para saber cuando se toco al jugador para atacarlo o de casualidad

    // Valores para rotar al caminar 
    [SerializeField] public float smoothTime = 0.05f; // Tiempo de suavizado
    [SerializeField] public float currentVelocity = 0.1f; // Variable para SmoothDamp

    // Componentes en comun
    protected Animator _anim;
    public Transform characterTransform;
    public Rigidbody rb;

    // Manager
    protected RotationManager rotationManager;
    protected DefenseManager defenseManager;
    protected AnimationManager animationManager;

    // Implementación de IAttacker
    public float DamageGenerate => damageGenerate;
    public bool IsAttacking => attacking;

    public virtual void Awake()
    {
        // Componentes
        characterTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        // Manager
        defenseManager = new DefenseManager(_anim);
        animationManager = new AnimationManager(_anim);
        rotationManager = new RotationManager();
    }

    // Funcion para recibir dano
    public void TakeDamage(float damage)
    {
        if (defenseManager.IsDefending())
        {
            Debug.Log("Ataque fallido: defensa activa.");
        }
        else
        {
            health -= damage;

            if (health <= 0) 
            {
                health = 0;
            }
            animationManager.UpdateHealthAnimation(health);

            Debug.Log($"{gameObject.name} recibio daño: {damage}, Salud restante: {health}");
        }
    }
}