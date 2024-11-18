using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;

//esta clase va en el player
public class Detectar_portal : MonoBehaviour, ITeletrasportar
{
    Game_manager _controller;

    private void Start()
    {
        _controller = Game_manager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Teletrasportar(other);
        
    }

    public void Teletrasportar(Collider other) {
        
        if (other.tag == _PORTAL_TAG)
        {
            //si esta en el portal 
            if (_controller._Jefe_muerto)
            {
                //si el jefe esta muerto
                Debug.Log("cambio de nivel");
                _controller.Cargar_nueva_escena(true);
            }
        }

    }
}
