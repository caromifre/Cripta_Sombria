using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instanciar_enemigos : MonoBehaviour
{
    /* factoria para instanciar enemigos al momento en que el player colisiona con
     box collider de la celda*/
    [SerializeField] GameObject[] _Enemigos;
    [SerializeField] Vector2 _offset;//offset para instanciar a los enemigos
    Transform _transform;
    float _O_X, _O_Y;
    GameObject _Nuevo_enemigo;
   

    public void instanciar_enemigos() {
        _O_X = Random.Range(-_offset.x, _offset.x);
        _O_Y = Random.Range(-_offset.y, _offset.y);
        int t_en = Random.Range(0, _Enemigos.Length);
        _transform = this.transform;
        
        //Vector3 pos_enemy = new Vector3(transform.position.x+_O_X, 0f, - transform.position.y + _O_Y );
        //Debug.Log("posicion: " + this.transform.position);
        //Debug.Log("new vector3: " + new Vector3(_O_X, 0f, _O_Y));
        Vector3 nn = this.transform.position + new Vector3(_O_X, 0f, _O_Y);
        //Debug.Log("suam de vectores: " + nn);

        _Nuevo_enemigo = Instantiate(_Enemigos[t_en],nn , Quaternion.identity);
    }

   /* void recargar_enemigos() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
    //crea botonera basica
    /*private void OnGUI()
    {
        float w = Screen.width / 2;
        float h = Screen.height - 80;
        if (GUI.Button(new Rect(w, h, 250, 50), "Recargar enemigos"))
        {
            recargar_enemigos();
        }
        
    }*/
}
