using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_die_Jefe : StateMachineBehaviour
{
    [SerializeField] GameObject _Gmo_conluz;
    
    
        // Este m�todo se llama cuando una transici�n sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animaci�n terminado");
        
        //notificar la muerte del jefe 
        Game_manager.Instance.jefe_muerto();
        //elmiinar al jefe de la escena
        _Gmo_conluz.GetComponent<Light>().enabled = true;
        Destroy(animator.gameObject);

    
    }

}
