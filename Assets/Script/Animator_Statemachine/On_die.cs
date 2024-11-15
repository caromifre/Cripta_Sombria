using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_die : StateMachineBehaviour
{ 
    // Este m�todo se llama cuando una transici�n sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animaci�n terminado");
        // Aqu� puedes llamar a otro script o ejecutar cualquier l�gica
        //animator.gameObject.GetComponent<MyScript>().OnAnimationEnd();
        Game_manager.Instance.mostrar_menu_muerte();
    }
   /* public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("iniciando la animacion morir");
        
    }*/
}
