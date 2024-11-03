using UnityEngine;

/*Crea un scriptable object para guardar las mazmorras que parezcan utiles como nivel
 Esta clase hereda de Guardar_nivel_disk.
cells es un array unidimensional donde se "serializa un array bidimensional"(de otra forma no me anduvo)
por eso width y height guardan el tamaño de la matriz
carperta es el nombre con el que se guardaron los datos para este scriptableObject
 */


[CreateAssetMenu(fileName = "NuevaMazmorra", menuName = "Mazmorra/Nueva Mazmorra")]//crea menu en unity

//clase base para guardar el laberinto 
public class SO_guardaNivel : Guardar_nivel_Disk
{
    //array tipo cell para alamacernar la mazmorra
    public Cell[] cells;
    //ancho de la mazmora
    public int width;
    //alto de la mazmorra
    public int height;
    //carpeta donde se alamacena la mazmorra
    public string carpeta;
}