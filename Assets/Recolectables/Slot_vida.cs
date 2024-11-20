using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Constantes_celda;
public class Slot_item : MonoBehaviour
{
    [SerializeField] Image _Pocion_vida;
    [SerializeField] Sprite _Icon_Pvida;
    [SerializeField] TextMeshProUGUI _cantidad;

    private void Start()
    {
        _Pocion_vida.sprite = _Icon_Pvida;
        _Pocion_vida.enabled = false;
        _cantidad.enabled = false;
    }

    private void Update()
    {
        if (Game_manager.Instance.obtener_cant_pociones(_POCION_VIDA) > 0)
        {
            _Pocion_vida.enabled = true;
            _cantidad.enabled = true;   
            _cantidad.text = Game_manager.Instance.obtener_cant_pociones(_POCION_VIDA).ToString();
        }
        else { 
            _Pocion_vida.enabled = false;
            _cantidad.enabled = false;
        }
    }
}