using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_luz : MonoBehaviour,IActivar_luz
{
    // Referencia al GameObject que tiene la luz
    //public GameObject objetoConLuz;

    //Light luzPuntual;

    // Método para activar la luz
    private void Update()
    {
        //si el objeto que tiene este script tiene un luz 
        //y esta desativada la activa
        if (Game_manager.instance._Jefe_muerto) {
            if (!this.GetComponent<Light>().enabled) {
                ActivarLuz();
            }            
        }
    }
    public void ActivarLuz()
    {
        //activar la luz del portal
        if (this.GetComponent<Light>() != null)
        {
            Debug.Log("Luz encendida");
            this.GetComponent<Light>().enabled = true;
        }
        else
        {
            Debug.Log("El GameObject no tiene el componente Light");
        }
    }
}
