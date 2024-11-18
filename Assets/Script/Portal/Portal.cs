using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour,IPasajero,ITeletrasportar
{
    Game_manager _controller;
    bool _pasajero;

    private void Start()
    {
        _controller=Game_manager.Instance;
    }

    public void Pasajero() { }

    public void Teletrasportar(Collider other) { }
}
