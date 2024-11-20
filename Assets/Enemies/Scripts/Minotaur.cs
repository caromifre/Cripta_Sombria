using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    [SerializeField] float _healt = 250;
    [SerializeField] float _speed = 1f;
    [SerializeField] float _sprintSpeed = 2f;
    [SerializeField] float _detectionRange = 3f;
    [SerializeField] float _damageGenerate = 20f;
    [SerializeField] float _distanceAttack = 1.5f;

    private void Start()
    {
        // Valores del orco
        health = _healt;
        speed = 1f;
        sprintSpeed = 2f;
        detectionRange = 3f;
        damageGenerate = 20f;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
}
