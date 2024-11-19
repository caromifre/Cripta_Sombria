using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;
//using static Constantes_celda;

/*Clase para instanciar el nivel en la escena*/
public class Cargar_criptas : MonoBehaviour
{
    //matriz de celdas
    [SerializeField] GameObject[] _rooms;
    [SerializeField] _TIPO_CELDA _tipo_celda;
    Instanciar_criptas _Gen_mazmorra;
    GuardarCargarMazmorra _guardado;
    float _X, _Y;

    Cell[,] _board;

    void Start()
    {
        //inicializar go como gameobject para evitar el error relacionado con MonoBehaviour
        GameObject go = new GameObject("GeneradorCripta");
        _guardado = GetComponent<GuardarCargarMazmorra>();

        _board = new Cell[_guardado._whidth, _guardado._height];
       
        inicializar_tablero();       

        _Gen_mazmorra = go.AddComponent<Instanciar_criptas>();

        _guardado.CargarDesdeScriptableObject(ref _board,ref _X, ref _Y);
        //Debug.Log("_X: " + _X + "_Y: " + _Y);
        _Gen_mazmorra.Generardungeon(_rooms, _board, _board.GetLength(0), _board.GetLength(1), _X, _Y,(int)_tipo_celda);

    }

    void inicializar_tablero()
    {
        //crea un tablero en blanco
        //Debug.Log("x= " + _board.GetLength(0) + " y= " + _board.GetLength(1));
        for (int a = 0; a < _board.GetLength(0); a++)
        {
            for (int b = 0; b < _board.GetLength(1); b++)
            {
                _board[a, b] = new Cell();
            }
        }           
      
    }
}
