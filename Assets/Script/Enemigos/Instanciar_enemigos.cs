using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instanciar_enemigos : MonoBehaviour,ISetGal
{
    /* factoria para instanciar enemigos al momento en que el player colisiona con
     box collider de la celda*/
    [SerializeField] GameObject[] _Enemigos,_Jefes;
    [SerializeField] Vector2 _offset;//offset para instanciar a los enemigos
    Transform _transform;
    float _O_X, _O_Y;
    GameObject _Nuevo_enemigo;
    Game_manager _controler;
    int _num_gal = 0,
        _tot_gal=0;

    public void instanciar_enemigos() {
        _O_X = Random.Range(-_offset.x, _offset.x);
        _O_Y = Random.Range(-_offset.y, _offset.y);
        int t_en = Random.Range(0, _Enemigos.Length);
        _transform = this.transform;
        _controler = Game_manager.Instance;
        //Vector3 pos_enemy = new Vector3(transform.position.x+_O_X, 0f, - transform.position.y + _O_Y );
        //Debug.Log("posicion: " + this.transform.position);
        //Debug.Log("new vector3: " + new Vector3(_O_X, 0f, _O_Y));

        Vector3 nn = this.transform.position + new Vector3(_O_X, 0f, _O_Y);
        //Debug.Log("suam de vectores: " + nn);
        Debug.Log("numero de galeria= " + _num_gal);
        if (_num_gal== 1 && !_controler._Jefe_activo)//si es la ultima galeria instancia el jefe una sola vez
        {
            Debug.Log("APARECE EL JEFE");
            _Nuevo_enemigo = Instantiate(_Jefes[0], nn, Quaternion.identity);
            _controler.activar_jefe();
        }
        else
        {
            _Nuevo_enemigo = Instantiate(_Enemigos[t_en], nn, Quaternion.identity);
        }
    }

    public void SetGal(int num, int tot)
    {
        //guardar datos de las galerias
        _tot_gal = tot;
        _num_gal = num;
    }
}
