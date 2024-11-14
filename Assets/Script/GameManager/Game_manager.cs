using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour, IAdditive_scene,ILoad_scene
{
    public static Game_manager Instance => instance;
    public static Game_manager instance;
    [SerializeField] int _cant_vidas = 3;
    public float _tot_vida;
    //nombre de las escenas a cargar
    [SerializeField] string _Hud;
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

    //pasar de nivel
    public void Cargar_nueva_escena() { 
    
    }
}