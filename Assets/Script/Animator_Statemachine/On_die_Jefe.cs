using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_die_Jefe : StateMachineBehaviour
{
    [SerializeField] GameObject _Gmo_conluz;
    [SerializeField] GameObject _Portal;
    
        // Este método se llama cuando una transición sale del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Estado de animación terminado");
        
        //notificar la muerte del jefe 
        Game_manager.Instance.jefe_muerto();
       /* if (_Portal.GetComponent<BoxCollider>() != null){
            Debug.Log("activando portal");
            _Portal.GetComponent<BoxCollider>().enabled = true;
        }
        else
            Debug.Log("Al gameobject le falta el collider");*/
       _Portal.SetActive(true);
        //elmiinar al jefe de la escena
        Destroy(animator.gameObject);

    
    }

}
