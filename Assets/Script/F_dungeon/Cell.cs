using UnityEngine;
[System.Serializable]
public class Cell
{
    public bool visited = false;//indica si esta celda se instancia o no
    //public bool[] status = new bool[4];
    public bool[] puerta = new bool[4];
    public bool[] pared = new bool[4];
    public bool galeria;//indica si es una galeria
    public bool rama_galeria;//indica que de esa celda sale una rama
    public bool pasillo;//indica que esun pasillo
    public int direccion;
    public bool vacio;
    public bool fin;//indica que es la celda de fin
    public bool inicio;//indica que es la celda de inicio
    public bool recompensa;// indica que esa celda tiene una recompensa
    public int num_galeria;//numero de orden de la galeria
    //public int tipo_celda;//indica que celda es de las que estan predifinidas en los prefabs

    public void reset_puerta()
    {
        //resetear puertas
        for (int a = 0; a < puerta.Length; a++)
        {
            puerta[a] = false;
        }
    }
    public void reset_pared()
    {
        //resetear paredes
        for (int a = 0; a < pared.Length; a++)
        {
            pared[a] = false;

        }
    }
}