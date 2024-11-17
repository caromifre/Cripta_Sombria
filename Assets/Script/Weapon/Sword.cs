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

        if (target != null && attacker != null)
        {
            if (attacker is IAttacker && target != null)
            {
                if (attacker.IsAttacking) // Si esta atacando
                {
                    target.TakeDamage(attacker.DamageGenerate); // Aplica da�o al objetivo
                }
            }
        }
    }
}