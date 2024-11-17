using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lose_menu : MonoBehaviour 
{
    [SerializeField] Button _volver_a_jugar;
    Game_manager _controler;

    private void Awake()
    {
        _controler= Game_manager.Instance;
        _volver_a_jugar?.onClick.AddListener(_controler.Cargar_nueva_escena);
    }


}
