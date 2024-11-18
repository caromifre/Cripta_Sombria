using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase gestiona la defensa de los characteres que poseen escudo
public class DefenseManager
{
    private Animator _anim;

    public DefenseManager(Animator anim)
    {
        _anim = anim;
    }

    // Activa la defensa
    public void StartDefending()
    {
        _anim.SetBool("Defend", true);
        Debug.Log("Defensa activada.");
    }

    // Desactiva la defensa
    public void StopDefending()
    {
        _anim.SetBool("Defend", false);
       // Debug.Log("Defensa desactivada.");
    }

    // Verifica si esta en defensa
    public bool IsDefending()
    {
        return _anim.GetBool("Defend");
    }
}

