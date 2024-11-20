using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constantes_celda;

public class Game_manager : MonoBehaviour, IAdditive_scene, ILoad_scene, ILoose_scene
{
    public static Game_manager Instance => instance;
    public static Game_manager instance;
    /*[SerializeField] int _cant_vidas = 3;*/
    public float _tot_vida,_max_vida;
    //nombre de las escenas a cargar
    [SerializeField] string _Hud, _Menu_muerte,_Menu_ganar;
    [SerializeField] string[] _Nivel;
    [SerializeField] string[] _Menues;
    //gameobjetc del player para instanciarlo en el nuevo nivel
    //[SerializeField] GameObject _Player;
    GameObject _Iplayer;
    //cofigurar cantidad de jefes por nivel
    //[SerializeField] int _Jefe = 1;//por defecto 1

    //inventario
    Dictionary<string, int> _inventario;
    

    public bool _Jefe_activo { get; protected set; } = false;
    //esta variable se activa al morir el jefe para habilitar el cambio de nivel
    public bool _Jefe_muerto { get; protected set; } = false;

    int _nivel_actual = _NIVEL1;

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
        //crear  diccionario
        _inventario = new Dictionary<string, int>();
    }
    // Start is called before the first frame update
    void Start()
    {
        agregar_escena();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    //mostrar el hud
    public void agregar_escena() {
        SceneManager.LoadScene(_Hud, LoadSceneMode.Additive);
    }

    //cargar nivel1
    public void Cargar_nueva_escena() {
        Cargar_nueva_escena(false);
    }
    public void Cargar_nueva_escena(bool next = false) {
        if (!next)
        {
            //por defecto se carga el nivel 1
            SceneManager.LoadScene(_Nivel[_NIVEL1], LoadSceneMode.Single);
            SceneManager.LoadScene(_Hud, LoadSceneMode.Additive);
            reset_nivel();
            Reset_inventario();
        }
        else { 
            _nivel_actual++;
            if (_nivel_actual < _Nivel.Length)
            {
                SceneManager.LoadScene(_Nivel[_nivel_actual], LoadSceneMode.Single);
                SceneManager.LoadScene(_Hud, LoadSceneMode.Additive);
                //_Iplayer = Instantiate(_Player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                reset_nivel();
            }
            else {
                reset_nivel();
                Reset_inventario();
                mostrar_menu_ganar();
            }
        }

        
    }
    void reset_nivel()
    {
        desactivar_jefe();
        _Jefe_muerto = false;
    }

    //mostrar menu muerte
    public void mostrar_menu_muerte() {
        SceneManager.LoadScene(_Menu_muerte, LoadSceneMode.Single);
        reset_nivel();
        Reset_inventario();
    }

    public void activar_jefe() {
        //indicar que ya se instancio el jefe
        _Jefe_activo = true;
    }

    public void desactivar_jefe() { 
        //resetear la instanciacion del jefe
        _Jefe_activo = false;
    }

    public void jefe_muerto() { 
        _Jefe_muerto = true;
    }

    public void mostrar_menu_ganar() {
        reset_nivel();
        Reset_inventario();
        SceneManager.LoadScene(_Menu_ganar, LoadSceneMode.Single);
    }

    public void actualizar_pociones(string itemId,int cant) {
        //este metodo actualiza la lista de inventario en en el gamemanager
        _inventario[itemId] = cant;
    }

    public int obtener_cant_pociones(string itemId) { 

        return _inventario.ContainsKey(itemId) ? _inventario[itemId]:0;        
    }

    private void Reset_inventario()
    {
        //poner a 0 todo el inventario
        if (_inventario.Count>0 )
        {
            //obtener la lista de indices
            List<string> keys = new List<string>(_inventario.Keys);
            foreach (string item in keys)
            {
                _inventario[item] = 0;
            }
        }
    }

    public void mostrar_menu_incio() {
        //funcion para cargar un menu de forma aditiva
        reset_nivel();
        Reset_inventario();
        SceneManager.LoadScene(_Menues[_MENU_INICIO], LoadSceneMode.Single);
    }

    public void ocultar_hud() {
        //funcion para descargar la escena del menu
        SceneManager.UnloadSceneAsync(_Hud);
    }

}
