using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_portal : MonoBehaviour
{
    [SerializeField] GameObject _portal;
    Game_manager _controller;
   

   /* private void Awake()
    {
        // Asegúrate de activar el GameObject inmediatamente
        if (_portal != null)
        {
            //_portal.SetActive(true);  // Activa el GameObject si estaba desactivado
        }
        else
        {
            Debug.LogError("_portal no está asignado en el Inspector.");
        }
    }*/
   /* private void Start()
    {
       
        _portal.GetComponent<Light>().enabled = true;  
    }*/

    public void activar_portal() {
        //este metodo activa el componente light del gameobject
        if (_portal.GetComponent<Light>() != null) {

            _portal.GetComponent<Light>().enabled = true;
        }
        else
        {
            Debug.Log("El GameObject no tiene el componente Light");
        }
        
    }

   /* private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Chest" && _controller._Jefe_muerto ) {
            //aca se muestra menu para ir al otro nivel
            Debug.Log("activa el portal");
        }
    }*/
}
