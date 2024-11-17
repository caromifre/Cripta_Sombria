using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase controla las animaciones de enemigos y player
public class AnimationManager
{
    private Animator _anim;

    public AnimationManager(Animator anim)
    {
        _anim = anim;
    }

    // Actualiza la animacion de la salud
    public void UpdateHealthAnimation(float health)
    {
        _anim.SetFloat("Health", health);
    }

    // Controla la animacion de idle
    public void IdleAnimation()
    {
        ResetAnimations();
    }

    // Controla la animacion de caminar
    public void WalkingAnimation()
    {
        ResetAnimations();
        _anim.SetBool("Walk", true);

    }

    // Controla la animacion de correr
    public void RunningAnimation()
    {
        ResetAnimations();
        _anim.SetBool("Run", true);
    }

    // Controla la animacion de ataque
    public void AttackAnimation()
    {
        _anim.SetTrigger("Attack");
    }

    // Controla la animacion de recibir daño
    public void UpdateDamageAnimation()
    {
        _anim.SetTrigger("Damage");
    }
    public void ResetAnimations()
    {
        _anim.SetBool("Walk", false);
        _anim.SetBool("Run", false);
    }
}

