using System.Collections.Generic;
using UnityEngine;

public class Gen_Ramas : IRamas
{
    Cell[,] _board;//tablero temporal
    List<Cell> _celdas;//guarda las celdas visitadas
    void Crear_Rama() {
        Debug.Log("esat funcion fue sobrecargada");
    }

    void Crear_Rama(ref Cell[,] board) {
        //esta funcion recibe el tablero y busca espacios para crear ramas
        //board recibe la referencia del tablero para poder modificar los datos

        if (board == null)
        {
            Debug.Log("variable board es nula");
            return;
        }

 
    }

    void inicalizar(Cell[,] board)
    {
        //metodo para cargar lso datos en la lista

    }
}
