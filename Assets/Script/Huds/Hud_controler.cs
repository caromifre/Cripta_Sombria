using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud_controler : MonoBehaviour, IObtener_canrtidad_vida
{
    [SerializeField] TextMeshProUGUI _cantidad_vida;//asignar el objeto TextMeshPro donde se mostrara la informacion
    Game_manager _controler;
    string _vida;

    private void Start()
    {
        _controler = Game_manager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        obtener_cantidad_vida();
        //muestra el valor en el hud
        _cantidad_vida.text = _vida;
    }

    //carga la vida del player en la variable
    public void obtener_cantidad_vida() { 
       _vida = ((int)_controler._tot_vida).ToString();
    }
}
