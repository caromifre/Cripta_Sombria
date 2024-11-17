using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] float _health = 50;
    private void Start()
    {
        // Valores de la ara�a
        health = _health;
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
            // Llamo al metodo del player para restarle vida, segun el da�o que genera el enemigo
            Character playerCharacter = other.gameObject.GetComponent<Character>();
            if (playerCharacter != null)
            {
                playerCharacter.TakeDamage(damageGenerate);
            }
        }
    }
}
