using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] string _Nom_nivel = "Nivel1";

    public void Jugar()
    {
        if (Game_manager.Instance != null)
        {
            Destroy(Game_manager.Instance.gameObject);
            Debug.Log("La instancia de Game_manager ha sido destruida.");
        }

        SceneManager.LoadScene(_Nom_nivel);

    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }


}
