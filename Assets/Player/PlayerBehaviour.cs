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
    }

    // Recibe dano
    public void TakeDamage(float damage)
    {
        if (!Input.GetButton("Fire2"))
            Debug.Log(health);
            health -= damage;
            _anim.SetFloat("Health", health);
    }
}
