using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Constantes_celda;

public class Control_Pausa : MonoBehaviour
{
    [SerializeField] GameObject _menuPausa; // Referencia al menú de pausa (UI)
    [SerializeField] AudioSource _audioFuente; // Referencia al audio principal del juego
    [SerializeField] Button _btn_inicio, _volver_a_jugar,_btn_salir;
    Game_manager _controler;

    bool _juego_Pausado = false; // Estado del juego

    private void Awake()
    {
        _controler = Game_manager.Instance;
        _volver_a_jugar?.onClick.AddListener(Reanudar_Juego);
        _btn_salir?.onClick.AddListener(Salir);
        _btn_inicio?.onClick.AddListener(_controler.mostrar_menu_incio);
    }

    void Update()
    {
        // Verificar si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_juego_Pausado)
            {
                Reanudar_Juego();
            }
            else
            {
                Pausar_Juego();
            }
        }
    }

    public void Pausar_Juego()
    {
        _juego_Pausado = true;

        // Mostrar el menú de pausa si existe
        if (_menuPausa != null){
            _controler.ocultar_hud();
            _menuPausa.SetActive(true);
        }

        // Pausar el tiempo y el audio
        Time.timeScale = 0f;
        if (_audioFuente != null)
            _audioFuente.Pause();
    }

    public void Reanudar_Juego()
    {
        _juego_Pausado = false;

        // Ocultar el menú de pausa si existe
        if (_menuPausa != null){
            _menuPausa.SetActive(false);
            _controler.agregar_escena();//mostrar hud
        }
            

        // Reanudar el tiempo y el audio
        Time.timeScale = 1f;
        if (_audioFuente != null)
            _audioFuente.UnPause();
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}

