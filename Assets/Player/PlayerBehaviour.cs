using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float health { get; protected set; }
    public float damageGenerate = 10;

    protected Animator _anim;

    public void Awake()
    {
        health = 500;
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Health", health);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Recibe dano
    public void TakeDamage(float damage)
    {
        Debug.Log(health);
        health -= damage;
        _anim.SetFloat("Health", health);
        // if (health <= 0) Die();
    }
}
