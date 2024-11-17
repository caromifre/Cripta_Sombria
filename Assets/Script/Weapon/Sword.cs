using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Interface que representa a los atacantes
public interface IAttacker
{
    float DamageGenerate { get; }
    bool IsAttacking { get; }
}

public class Sword : MonoBehaviour
{
    private IAttacker attacker; // Referencia al atacante (Jugador o Enemigo)

    private void Start()
    {
        attacker = GetComponentInParent<IAttacker>(); // Obtener el atacante
    }

    private void OnTriggerEnter(Collider other)
    {
        Character target = other.GetComponentInParent<Character>();
        Debug.Log("Objeto detectado: " + target);

        if (target != null && attacker != null)
        {
            Debug.Log("Atacante encontrado: " + attacker);

            if (attacker.IsAttacking)
            {
                Debug.Log("Atacante está atacando, aplicando daño");
                target.TakeDamage(attacker.DamageGenerate); // Aplica daño al objetivo
            }
            else
            {
                Debug.Log("Atacante no está atacando");
            }
        }
    }

}