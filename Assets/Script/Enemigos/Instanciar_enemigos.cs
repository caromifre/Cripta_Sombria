using UnityEngine;
using System.Collections;


public class Instanciar_enemigos : MonoBehaviour, ISetGal
{

    /* factoria para instanciar enemigos al momento en que el player colisiona con
      box collider de la celda*/
    [SerializeField] GameObject[] _Enemigos, _Jefes;
    [SerializeField] Vector2 _offset;//offset para instanciar a los enemigos
    [SerializeField] bool _mostrar_jefe = false;
    [SerializeField] GameObject _VFX_Spown_efect;
    [SerializeField] float _Altura_portal = 0.01f;
    Transform _transform;
    Vector3 _pos_isnt;
    float _O_X, _O_Y, _conteo;
    [SerializeField] float _delayAparicion = 1.0f;
    //GameObject _Nuevo_enemigo,_vfx;
    Game_manager _controler;
    int _num_gal = 0,
        _tot_gal = 0,
        _t_en = 0;
    bool _Insanciado = true;
    void Update()
    {
        if (!_Insanciado)
        {
            if (_conteo > 0)
            {
                _conteo -= Time.deltaTime;
            }
            else
            {
                if (_num_gal == 1 || _mostrar_jefe && !_controler._Jefe_activo)//si es la ultima galeria instancia el jefe una sola vez
                {
                    Debug.Log("APARECE EL JEFE");
                    Instantiate(_Jefes[0], _pos_isnt, Quaternion.identity);
                    _controler.activar_jefe();
                }
                else
                {
                    Instantiate(_Enemigos[_t_en], _pos_isnt, Quaternion.identity);
                }
                _Insanciado = true;
            }
        }
    }

    public void instanciar_enemigos()
    {
        _O_X = Random.Range(-_offset.x, _offset.x);
        _O_Y = Random.Range(-_offset.y, _offset.y);
        _conteo = _delayAparicion;
        _t_en = Random.Range(0, _Enemigos.Length);
        _transform = this.transform;
        _controler = Game_manager.Instance;
        _pos_isnt = _transform.position + new Vector3(_O_X, 0f, _O_Y);
       Vector3 pos_portal=_transform.position + new Vector3(_O_X, _Altura_portal, _O_Y);

        //Vector3 nn = _transform.position + new Vector3(_O_X, 0f, _O_Y);
        Instantiate(_VFX_Spown_efect,pos_portal, Quaternion.identity);
        _Insanciado = false;

    }
    public void SetGal(int num, int tot)
    {
        //guardar datos de las galerias
        _tot_gal = tot;
        _num_gal = num;
    }
}