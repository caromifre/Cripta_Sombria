using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;

public class Activar_portal : MonoBehaviour
{
    [SerializeField] GameObject _portal;
    Game_manager _controller;

    private void Start()
    {
        _controller= Game_manager.Instance;
    }

    private void Update()
    {
        if (_controller._Jefe_muerto)
        {
            if (_portal.GetComponent<BoxCollider>() != null)
                _portal.GetComponent<BoxCollider>().enabled = true;
            else 
                Debug.Log("Al gameobject le falta el collider");
        }
    }

}
