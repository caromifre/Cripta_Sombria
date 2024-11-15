using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour, IAdditive_scene,ILoad_scene, ILoose_scene
{ 
    public static Game_manager Instance=>instance;
    public static Game_manager instance;
    /*[SerializeField] int _cant_vidas = 3;*/
    public float _tot_vida;
    //nombre de las escenas a cargar
    [SerializeField] string _Hud,_Menu_muerte;
    

    string _nivel_actual;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else //Instance != null
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        agregar_escena();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //mostrar el hud
    public void agregar_escena() {
        SceneManager.LoadScene(_Hud, LoadSceneMode.Additive);
    }

    //caragar nivel1
    public void Cargar_nueva_escena() {
        SceneManager.LoadScene("Nivel1", LoadSceneMode.Single);
        SceneManager.LoadScene(_Hud, LoadSceneMode.Additive);
    }

    //mostrar menu muerte
    public void mostrar_menu_muerte() {
        SceneManager.LoadScene(_Menu_muerte, LoadSceneMode.Single);
    }

 
}
