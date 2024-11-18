using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    float DamageGenerate { get; }
    bool IsAttacking { get; }
}

public class Sword : MonoBehaviour
{
    private IAttacker attacker; // Referencia al atacante (Jugador o Enemigo)
    private Collider swordCollider; // El collider de la espada
    private bool canDealDamage = false; // Flag para permitir el da�o
    private float damageCooldown = 1.14f; // Tiempo entre ataques
    private float lastAttackTime = 0f; // Tiempo de la �ltima vez que se aplic� da�o

    private void Start()
    {
        attacker = GetComponentInParent<IAttacker>(); // Obtener el atacante
        swordCollider = GetComponent<Collider>(); // Obtener el collider de la espada
    }

    private void Update()
    {
        // Activar o desactivar el collider seg�n el estado de ataque
        if (attacker.IsAttacking)
        {
            if (!swordCollider.enabled)
            {
                swordCollider.enabled = true; // Activar el collider cuando est� atacando
            }
        }
        else
        {
            if (swordCollider.enabled)
            {
                swordCollider.enabled = false; // Desactivar el collider cuando no est� atacando
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el atacante est� en el proceso de ataque
        if (attacker.IsAttacking && Time.time - lastAttackTime >= damageCooldown)
        {
            // Solo aplicamos da�o si ha pasado el tiempo suficiente desde el �ltimo ataque
            Character target = other.GetComponentInParent<Character>();
            if (target != null)
            {
                Debug.Log("Atacante est� atacando, aplicando da�o");
                target.TakeDamage(attacker.DamageGenerate); // Aplica da�o al objetivo
                lastAttackTime = Time.time; // Actualizamos el tiempo del �ltimo ataque
            }
        }
    }
}
