using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static Constantes_celda;

public class Cargar_criptas : MonoBehaviour
{
    //matriz de celdas
    [SerializeField] GameObject[] _rooms;

    Instancia_mazmorra _Gen_mazmorra;
    GuardarCargarMazmorra _guardado;
    //scriptable leer propiedades
    SO_guardaNivel _SO_props;

    Cell[,] _board;

    void Start()
    {
        //inicializar go como gameobject para evitar el error relacionado con MonoBehaviour
        GameObject go = new GameObject("GeneradorMazmorra");
        _guardado = GetComponent<GuardarCargarMazmorra>();

        _SO_props = new SO_guardaNivel();

        Debug.Log("Archivo: "+_guardado.Obt_nom_archivo().ToString());

        //_SO_props.Cargar(_SO_props.);

        _board = new Cell[_guardado._whidth, _guardado._height];
        Debug.Log(_guardado._whidth + "  " + _guardado._height);
        inicializar_tablero();
        


       

        _Gen_mazmorra = go.AddComponent<Instancia_mazmorra>();

        _guardado.CargarDesdeScriptableObject(ref _board);
        
        _Gen_mazmorra.Generardungeon(_rooms, _board, _board.GetLength(0), _board.GetLength(1), 6, 6);

    }

    void inicializar_tablero()
    {
        //crea un tablero en blanco
        Debug.Log("x= " + _board.GetLength(0) + " y= " + _board.GetLength(1));
        for (int a = 0; a < _board.GetLength(0); a++)
        {
            for (int b = 0; b < _board.GetLength(1); b++)
            {
                _board[a, b] = new Cell();
            }
        }           
      
    }
}
