using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    float DamageGenerate { get; }
    bool IsAttacking { get; }
    AudioClip DamageSound { get; }
    bool IsPlayer { get; } // Nueva propiedad para identificar si es el jugador
}

public class Sword : MonoBehaviour
{
    private IAttacker attacker; // Referencia al atacante (Jugador o Enemigo)
    private Collider swordCollider; // El collider de la espada
    private float damageCooldown = 1.14f; // Tiempo entre ataques
    private float lastAttackTime = 0f; // Tiempo de la ultima vez que se aplico da�o

    // Referencia a AudioSourceManager
    public AudioSourceManager audioSourceManager;

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
                // Verificar si el atacante es el jugador o un enemigo
                if (attacker.IsPlayer && target.CompareTag("Enemy"))
                {
                    // Si el atacante es el jugador, da�ar solo a enemigos
                    Debug.Log("Jugador atacando al enemigo, aplicando da�o");
                    target.TakeDamage(attacker.DamageGenerate);
                }
                else if (!attacker.IsPlayer && target.CompareTag("Player"))
                {
                    // Si el atacante es un enemigo, da�ar solo al jugador
                    Debug.Log("Enemigo atacando al jugador, aplicando da�o");
                    target.TakeDamage(attacker.DamageGenerate);
                }

                // Reproducir el sonido de da�o desde la espada
                if (audioSourceManager != null)
                {
                    audioSourceManager.DamageEnemy(attacker.DamageSound);
                }

                // Actualizamos el tiempo del �ltimo ataque
                lastAttackTime = Time.time;
            }
        }
    }
}

