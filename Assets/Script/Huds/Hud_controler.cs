using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
public class Hud_controler : MonoBehaviour, IObtener_cantidad_vida
{
    //[SerializeField] TextMeshProUGUI _cantidad_vida;//asignar el objeto TextMeshPro donde se mostrara la informacion
    [SerializeField] Image _health_bar;
    Game_manager _controler;
    float _vida_maxima;

    private void Start()
    {
        _controler = Game_manager.Instance;
        _vida_maxima = _controler._max_vida;
    }

    // Update is called once per frame
    void Update()
    {
        actualizar_barra_vida();
        //muestra el valor en el hud
        //_cantidad_vida.text = _vida;
    }

    //carga la vida del player en la variable
    public void actualizar_barra_vida()
    {
        //Debug.Log(_vida_maxima / _controler._tot_vida);
        //_vida = ((int)_controler._tot_vida).ToString();
        _health_bar.fillAmount =  _controler._tot_vida/ _vida_maxima;
    }
}
