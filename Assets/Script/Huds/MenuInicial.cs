using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    public void Jugar()
    {
        if (Game_manager.Instance != null) {
            Game_manager.Instance.Cargar_nueva_escena();
        }
        else{
            SceneManager.LoadScene("Nivel1");
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }


}
