using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private void Start()
    {
        // Valores de la araña
        health = 50;
        walkSpeed = 3;
        runSpeed = 5;
        detectionRange = 15;
        damageGenerate = 5;
        distanceAttack = 0.7f;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && attacking)
        {
            attacking = false;

            // Llamo al metodo del player para reastale vida, segun el daño que genera el esqueleto
            PlayerBehaviour playerHealth = other.gameObject.GetComponent<PlayerBehaviour>();
            playerHealth.TakeDamage(damageGenerate);
        }
    }
}
