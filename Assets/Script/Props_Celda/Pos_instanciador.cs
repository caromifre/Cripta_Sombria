using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos_instanciador : MonoBehaviour
{
    Transform _transform;
    [SerializeField] GameObject _ins_enemy;
    GameObject _nuevo_ins_enemy;
    Datos_celda _datos_Celda;
    Instanciar_enemigos _Enemigos;
    // Start is called before the first frame update
    void Start()
    {
        _transform=this.transform;
        _datos_Celda=this.GetComponent<Datos_celda>();
        
        _nuevo_ins_enemy=Instantiate(_ins_enemy, _transform.position, Quaternion.identity) as GameObject;
        
        _Enemigos=_nuevo_ins_enemy.GetComponent<Instanciar_enemigos>();
        Debug.Log("enviando datos de galerias al instanciador num:" + _datos_Celda._num_gal + " tot: " + _datos_Celda._tot_gal);
        _Enemigos.SetGal(_datos_Celda._num_gal, _datos_Celda._tot_gal);
    }


}
