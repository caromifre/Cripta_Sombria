using UnityEngine;

/*Crea un scriptable object para guardar las mazmorras que parezcan utiles como nivel
 Esta clase hereda de Guardar_nivel_disk.
cells es un array unidimensional donde se "serializa un array bidimensional"(de otra forma no me anduvo)
por eso width y height guardan el tamaño de la matriz
archivo es el nombre con el que se guardan los datos para este scriptableObject
 */


[CreateAssetMenu(fileName = "NuevaMazmorra", menuName = "Mazmorra/Nueva Mazmorra")]//crea menu en unity

//clase base para guardar el laberinto 
public class SO_guardaNivel : Guardar_nivel_Disk
{
    //array tipo cell para alamacernar la mazmorra
    public Cell[] cells;
    //ancho de la mazmora
    [Tooltip("¡NO MODIFICAR! este valor esta solo para ser visualizdo")]
    public int width;
    //alto de la mazmorra
    [Tooltip("¡NO MODIFICAR! este valor esta solo para ser visualizdo")]
    public int height;
    //nombre del archivo donde se alamacena la mazmorra
    [Tooltip("Nombre del archivo con el que se guarda el mapa")]
    public string archivo;
    //nombre de la carpeta donde se guardara el archivo
    //esta carpeta se debe crear en la carpeta donde se halla 
    //el sriptableobject
    [Tooltip("Esta Carpeta se creara dentro de Assets")]
    public string nom_carpeta="Mapas_bin";
    //tamaño de la celda
    [Tooltip("Especifica tamaño de la celda en X y en Y, ¡NO MODIFICAR!")]
    public float offset_X, offset_Y;
}