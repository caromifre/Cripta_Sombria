using UnityEngine;

/*Crea un scriptable object para guardar las mazmorras que parezcan utiles como nivel
 Esta clase herda de Guardar_nivel_disk 
 */


[CreateAssetMenu(fileName = "NuevaMazmorra", menuName = "Mazmorra/Nueva Mazmorra")]//crea menu en unity

//clase base para guardar el laberinto 
public class SO_guardaNivel : Guardar_nivel_Disk
{
    public Cell[] cells;
    public int width;
    public int height;
}