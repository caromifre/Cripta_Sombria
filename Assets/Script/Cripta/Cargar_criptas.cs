using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargar_criptas : MonoBehaviour
{
    //matriz de celdas
    [SerializeField] GameObject[] _rooms;

    Instancia_mazmorra _Gen_mazmorra;
    GuardarCargarMazmorra _guardado;
    SO_guardaNivel _SO_props;

    Cell[,] _board;

    private void Awake()
    {
        
    }

    void Start()
    {
        //inicializar go como gameobject para evitar el error relacionado con MonoBehaviour
        GameObject go = new GameObject("GeneradorMazmorra");
        _SO_props = new SO_guardaNivel();
        _SO_props.Cargar("nivel1");
        _board = new Cell[_SO_props.width, _SO_props.height];
        inicializar_tablero();
        _guardado = GetComponent<GuardarCargarMazmorra>();


        //Debug.Log(_SO_props.width+ "  " +  _SO_props.height);

        _Gen_mazmorra = go.AddComponent<Instancia_mazmorra>();

        _guardado.CargarDesdeScriptableObject(ref _board);
        
        _Gen_mazmorra.Generardungeon(_rooms, _board, _SO_props.width, _SO_props.height, 6, 6);

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
