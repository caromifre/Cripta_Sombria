using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_luz : MonoBehaviour,IActivar_luz
{
    // Referencia al GameObject que tiene la luz
    public GameObject objetoConLuz;

    Light luzPuntual;

    // Método para activar la luz
    public void ActivarLuz()
    {
        objetoConLuz = GameObject.FindGameObjectWithTag( "Chest" );
        // Verifica que el objeto este exista
        if (!objetoConLuz)
        {
            //objetoConLuz.SetActive(true); // Activa el GameObject completo
            Debug.Log("objeto 'Chest' no encontrado");
            return;
        }
        else{
            // Ahora busca el componente Light y activa la luz

            luzPuntual = objetoConLuz.GetComponent<Light>();

            if (luzPuntual != null)
            {
                luzPuntual.enabled = true;  // Activa el componente Light
            }
            else
            {
                Debug.LogError("No se encontró el componente Light en el GameObject.");
            }
        }
    }
}
