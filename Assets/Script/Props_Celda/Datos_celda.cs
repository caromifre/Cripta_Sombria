using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datos_celda : MonoBehaviour, ISetGal,ISetCoord
{
    /* esta clase sirve para adjundar datos a las celdas al momento de instanciar
     * la celda
     * para que luego seran usados para adminstrar el nivel */
    public int _coord_X { get; private set; }//cordenada x de la celda en la matriz  
    public int _coord_Y { get; private set; }//coordeanda y de la matriz
    public int _num_gal { get; private set; }//indice de galeria
    public int _tot_gal { get; private set; }//total de galerias en el nivel

    // Método para inicializar los índices
    public void SetCoords(int x, int y)
    {
        //guardar coordenadas
        _coord_X = x;
        _coord_Y = y;
    }

    public void SetGal(int num,int tot) { 
        //guardar datos de las galerias
        _tot_gal = tot;
        _num_gal = num;
        //Debug.Log(_tot_gal + " - " + _num_gal);
    }
    
}
