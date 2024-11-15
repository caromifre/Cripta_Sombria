using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constantes_celda;

public class Fabrica_mazmorras : MonoBehaviour
{
    Laberinto_Base _Laberinto = new Laberinto_Base();
    Galerias _C_galerias= new Galerias();
    Instancia_mazmorra _Gen_mazmorra;
    [SerializeField] int _x, _y;
    //[SerializeField] int _startPos = 0;

    [SerializeField] GameObject[] _rooms;
    [SerializeField] _TIPO_CELDA _tipo_celda;//selecionar decoracion
    [SerializeField] Vector2 offset;
    [SerializeField] int _Galerias;
    Cell[,] _board;

    void Start() {
        GameObject go = new GameObject("GeneradorCripta");
        _Gen_mazmorra = go.AddComponent<Instancia_mazmorra>();
        _board = new Cell[_x, _y];

        _Laberinto.crear_camino(_board);
        _C_galerias.crear_galerias(_board);
        _Gen_mazmorra.Generardungeon(_rooms,_board,_x, _y,offset.x,offset.y,(int)_tipo_celda);
        //Debug.Log("celda elegida: " + ((int)_tipo_celda));
    }

    //crea botonera basica
    private void OnGUI()
    {
        float w = Screen.width / 2;
        float h = Screen.height - 80;
        if (GUI.Button(new Rect(w, h, 250, 50), "Regenerate Dungeon"))
        {
            RegenerateDungeon();
        }
        if (GUI.Button(new Rect(w, h - 60f, 250, 50), "Guardar Nivel")) {
            GuardarMazmorra();
        }
        if (GUI.Button(new Rect(w, h - 120f, 250, 50), "Cargar Nivel"))
        {
            CargarMazmorra();
        }
    }

    void RegenerateDungeon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GuardarMazmorra()
    {
        //GuardarCargarMazmorra2 guardado = GetComponent<GuardarCargarMazmorra2>();
        GuardarCargarMazmorra guardado = GetComponent<GuardarCargarMazmorra>();
        guardado.GuardarEnScriptableObject(_board, _x, _y,offset.x,offset.y);
        //guardado.GuardarEnJSON();
    }

    void CargarMazmorra()
    {
        //GuardarCargarMazmorra2 guardado = GetComponent<GuardarCargarMazmorra2>();
        GuardarCargarMazmorra guardado = GetComponent<GuardarCargarMazmorra>();
        guardado.CargarDesdeScriptableObject(ref _board,ref offset.x,ref offset.y);
        //guardado.CargarDesdeJSON();
        _Gen_mazmorra.Generardungeon(_rooms, _board, _x, _y, offset.x, offset.y,(int)_tipo_celda);
    }
}
