using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_die_Jefe : StateMachineBehaviour
{
    // Este método se llama cuando una transición sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animación terminado");

        Game_manager.Instance.jefe_muerto();
    }

}
