using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerAttack : PlayerBehaviour
{
    public bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _anim.SetTrigger("SimpleAttack");
            attacking = true;
        }
        if(Input.GetButton("Fire2"))
        {
            _anim.SetBool("Defend",true);
        }
        else
        {
            _anim.SetBool("Defend",false);
        }
    }
}


