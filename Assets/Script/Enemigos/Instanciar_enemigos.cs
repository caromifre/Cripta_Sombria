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
    float _O_X, _O_Y;
    GameObject _Nuevo_enemigo;
    // Start is called before the first frame update
    void Start()
    {
        _O_X = Random.Range(-_offset.x, _offset.x);
        _O_Y = Random.Range(-_offset.y, _offset.y);
        int t_en = Random.Range(0, 3);
        _Nuevo_enemigo= Instantiate(_Enemigos[t_en], new Vector3(_O_X, 0f, _O_Y), Quaternion.identity) as GameObject;
    }

    void recargar_enemigos() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //crea botonera basica
    private void OnGUI()
    {
        float w = Screen.width / 2;
        float h = Screen.height - 80;
        if (GUI.Button(new Rect(w, h, 250, 50), "Recargar enemigos"))
        {
            recargar_enemigos();
        }
        
    }
}
