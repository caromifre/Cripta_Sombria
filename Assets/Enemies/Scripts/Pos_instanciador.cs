using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos_instanciador : MonoBehaviour
{
    Transform _transform;
    [SerializeField] GameObject _ins_enemy;
    GameObject _nuevo_ins_enemy;
    // Start is called before the first frame update
    void Start()
    {
        _transform=this.transform;
        _nuevo_ins_enemy=Instantiate(_ins_enemy, _transform.position, Quaternion.identity) as GameObject;

    }


}
