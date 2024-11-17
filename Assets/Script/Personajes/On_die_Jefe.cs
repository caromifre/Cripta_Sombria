using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_die_Jefe : StateMachineBehaviour
{
    // Este m�todo se llama cuando una transici�n sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animaci�n terminado");

        Game_manager.Instance.jefe_muerto();
    }

}
