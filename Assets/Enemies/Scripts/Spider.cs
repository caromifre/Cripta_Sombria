using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private void Start()
    {
        // Valores de la araña
        health = 50f;
        speed = 3f;
        sprintSpeed = 5f;
        detectionRange = 15f;
        damageGenerate = 5f;
        distanceAttack = 0.7f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && attacking)
        {
            attacking = false;

            // Llamo al metodo del player para restarle vida, segun el daño que genera el enemigo
            Character playerCharacter = other.gameObject.GetComponent<Character>();
            if (playerCharacter != null)
            {
                playerCharacter.TakeDamage(damageGenerate);
            }
        }
    }
}
