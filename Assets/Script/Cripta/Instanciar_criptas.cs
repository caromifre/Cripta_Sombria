using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;

public class Instanciar_criptas : MonoBehaviour, IGen_mazmorra
{
    Prop_Celda _P_celda;
    Datos_celda _datos_celda;
    public void GenerateDungeon()
    {
        Debug.Log("Este metodo fue sobrecaragdo usaer el nuevo metodo:\n Generardungeon(GameObject[] rooms, Cell[,] board, int X, int Y,float o_x,float o_y)");
    }
    //public void Generardungeon(GameObject[] rooms, Cell[,] board, int X, int Y, float o_x, float o_y, int tipo_celda)
    public void Generardungeon(GameObject[] rooms, GameObject[] celda_inicio, GameObject[] galerias, GameObject[] pasillos, GameObject room_fin, Cell[,] board, int X, int Y, float o_x, float o_y, int tipo_celda)
    {
        //rooms recibe un array de gameobjects a instanciar donde el elemento [0] es primer elemento a instanciar y [1] sera el ultimo
        //board es una matriz que indica que elemtos se van a instanciar
        // X,Y indican el tamaño de la matriz de objetos a instanciar
        //o_x,o_y es el tamaño de la celda offset en x e y
        GameObject Nueva_celda, _room;
        int //celda,
            tot_gal=0,
            num_gal=0;
        bool galeria=false;
        //Debug.Log("tamaño: " + board.GetLength(0) + " - " + board.GetLength(1));
        for (int a = 0; a < X; a++)
        {
            for (int b = 0; b < Y; b++)
            {
                galeria = board[a,b].galeria;
                if (board[a, b].visited)
                {
                    if (board[a, b].inicio)
                    {
                        _room = celda_inicio[Random.Range(0, celda_inicio.Length)];
                    }

                    else if (board[a, b].fin)
                    {
                        //celda = _FIN;
                        _room = room_fin;

                    }
                    //else celda = Random.Range(2, rooms.Length);

                    else if (galeria)
                    {
                        //celda = 3; 
                        _room = galerias[Random.Range(0, galerias.Length)];
                    }

                    //else if (board[a, b].pasillo) celda = 2;

                    else if (board[a, b].pasillo)
                    {
                        //celda = 2;
                        _room = pasillos[Random.Range(0, pasillos.Length)];
                    }

                    else
                    {
                        //celda = 4;
                        _room = rooms[Random.Range(0, rooms.Length)];
                    }

                    //Debug.Log("instancia: " + a + " - "+ b);
                    //Nueva_celda = Instantiate(rooms[celda], new Vector3(a * o_x, 0f, -b * o_y), Quaternion.identity) as GameObject;
                    Nueva_celda = Instantiate(_room, new Vector3(a * o_x, 0f, -b * o_y), Quaternion.identity);

                    //adjuntar informacion
                    _datos_celda = Nueva_celda.GetComponent<Datos_celda>();
                    //guardar coordenadas de la matriz
                    _datos_celda.SetCoords(a, b);
                    //guardar datos de las galerias
                    if (tot_gal == 0 && galeria) {
                        
                        tot_gal = board[a, b].num_galeria;
                        //Debug.Log("detecto total de galerias" + tot_gal);
                    }
                    if (galeria) {
                        num_gal = board[a, b].num_galeria;
                        //Debug.Log("Guarda valores para galeria tot: "+ tot_gal +" num:" + num_gal);
                        _datos_celda.SetGal(num_gal, tot_gal);
                    }

                    _P_celda = Nueva_celda.GetComponent<Prop_Celda>();
                    _P_celda.actualizar_celda(_PAREDES, board[a, b].pared);
                    _P_celda.actualizar_celda(_PUERTAS, board[a, b].puerta);
                    Nueva_celda.name += " " + a + "_" + b;

                }

            }
        }

    }
}
