using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_enemy_die : StateMachineBehaviour
{

    // Este método se llama cuando una transición sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animación enemigo  terminado");
        Destroy(animator.gameObject);       
    }
    /* public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
         //base.OnStateEnter(animator, stateInfo, layerIndex);
         Debug.Log("iniciando la animacion morir");

     }*/
}
