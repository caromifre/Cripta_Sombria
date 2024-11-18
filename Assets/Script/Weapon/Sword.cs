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
    private float damageCooldown = 1.14f; // Tiempo entre ataques
    private float lastAttackTime = 0f; // Tiempo de la ultima vez que se aplico daño

    private void Start()
    {
        attacker = GetComponentInParent<IAttacker>(); // Obtener el atacante
        swordCollider = GetComponent<Collider>(); // Obtener el collider de la espada
    }

    private void Update()
    {
        // Activar o desactivar el collider según el estado de ataque
        if (attacker.IsAttacking)
        {
            if (!swordCollider.enabled)
            {
                swordCollider.enabled = true; // Activar el collider cuando esta atacando
            }
        }
        else
        {
            if (swordCollider.enabled)
            {
                swordCollider.enabled = false; // Desactivar el collider cuando no esta atacando
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el atacante esta en el proceso de ataque
        if (attacker.IsAttacking && Time.time - lastAttackTime >= damageCooldown)
        {
            // Solo aplicamos daño si ha pasado el tiempo suficiente desde el ultimo ataque
            Character target = other.GetComponentInParent<Character>();
            if (target != null)
            {
                Debug.Log("Atacante está atacando, aplicando daño");
                target.TakeDamage(attacker.DamageGenerate); // Aplica daño al objetivo
                lastAttackTime = Time.time; // Actualizamos el tiempo del ultimo ataque
            }
        }
    }
}
