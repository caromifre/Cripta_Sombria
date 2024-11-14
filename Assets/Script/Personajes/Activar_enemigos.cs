using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_enemigos : MonoBehaviour
{
    /*esta clase instancia los enemigos cuando el player
     esta cerca de la celda que posea el gameObject
    Instanciar_enemigo*/
    GameObject _Enemy_isntan;
    Instanciar_enemigos _Enemigos;

   
    void OnTriggerEnter(Collider choque)
    {
        if (choque.gameObject.CompareTag("Instan_Enemy")) { 
            _Enemy_isntan = choque.gameObject;
            _Enemigos= _Enemy_isntan.GetComponent<Instanciar_enemigos>();
            _Enemigos.instanciar_enemigos();
            //_Enemy_isntan.SetActive(false);
            Destroy( _Enemy_isntan );
            Debug.Log("limite del insanciador de la celda");
        }
    }
}
