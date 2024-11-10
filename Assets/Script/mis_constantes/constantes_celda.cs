
//libreria de constantes de uso general
public static class Constantes_celda
{
    //constantes para el manejo de las  celdas o habitaciones    
    public const int _PAREDES = 0, //array paredes
                     _PUERTAS = 1, //array  puertas
                     _PILARES = 2, //array pilares
                     _PISO = 3, //activa piso
                     _TODO = 4, //activa todo
                     _PUERTA_PARED = 5, //array seccion pared de la puerta
                     _ARRIBA = 0, //indica posicion
                     _ABAJO = 1, //indica posicion
                     _DERECHA = 2,//indica posicion
                     _IZQUIERDA = 3, //indica posicion
                     _ARRIBA_IZQ = 0,//indica posicion pilares
                     _ARIBA_DER = 1,//indica posicion pilares
                     _ABAJO_DER = 2,
                     _ABAJO_IZQ = 3,
                     _INICIO = 0,
                     _FIN = 1,//indica posicion pilares
                     _CELDA_DECORADA = 2,//incica la posicion en el array para las celdas decordas
                     _CELDA_GAlERIA = 3;//indica la posicion para las celdas tipo galeria



    // booleanos para el control de los elementos de cada celda
    public const bool 
                    _DESACTIVAR_CELDA=false,
                    _ACTIVAR_CELDA=true,
                    _DESACTIVAR_PISO=false,
                    _ACTIVAR_PISO=true,
                    _ACTIVAR=true,
                    _DESACTIVAR=false;
    
    //enum para indicar que celda de los prefabs se va a mostrar o instanciar
    public enum _TIPO_CELDA { 
        INICIO=0,
        FIN=1,
        BASICA=2,
        ORN_CANDELABRO=3,
        ORN_LAMPARA=4,
        ORN_ESQUELETO=5
    
    }
}
