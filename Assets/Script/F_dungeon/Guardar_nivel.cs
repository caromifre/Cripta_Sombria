using UnityEngine;

/*clase para guardar o cargar el nivel o mazmorra creada aleatoriamente*/
public class GuardarCargarMazmorra : MonoBehaviour
{
    [SerializeField] private SO_guardaNivel _mazmorraSO;

    //guardar la mazmorra o nivel elegido
    public void GuardarEnScriptableObject(Cell[,] board, int x, int y)
    {
        _mazmorraSO.width = x;
        _mazmorraSO.height = y;
        _mazmorraSO.cells = new Cell[x * y];
        //inicializar celdas
        //crea un tablero en blanco

          if(inicializar_tablero(ref _mazmorraSO.cells)){
            //guardar tablero
            int c = 0;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        _mazmorraSO.cells[c] = board[i, j];
                        c++;
                    }
                }
                //guardar datos en archivo binario
                _mazmorraSO.Guardar("nivel1");
                Debug.Log("Mazmorra guardada en Scriptable Object");
          }
    }

    //carga el o los niveles desde el scriptable object
    public void CargarDesdeScriptableObject(ref Cell[,] board)
    {
        board = new Cell[_mazmorraSO.width, _mazmorraSO.height];

        if(inicializar_tablero(ref board)){
            //obtener datos del archivo binario
            int c = 0;
            _mazmorraSO.Cargar("nivel1");

            for (int i = 0; i < _mazmorraSO.width; i++)
            {
                for (int j = 0; j < _mazmorraSO.height; j++)
                {
                    //Debug.Log("celda: " + _mazmorraSO.cells);
                    board[i, j] = _mazmorraSO.cells[c];
                    c++;
                }
            }
            
            Debug.Log("Mazmorra cargada desde Scriptable Object");
        }
    }
    
    //----
    //-----------------------------
    //----

    //inicializa el array (tablero) en blanco
    bool inicializar_tablero(ref Cell[] board)
    {
        if (board == null)
        {
            Debug.Log("error al inicializar el tablero inicicalizar board con 'new' ");
            return false;
        }
        else
        {
            //crea un tablero en blanco
            for (int a = 0; a < board.GetLength(0); a++)
            {
                
                    board[a] = new Cell();
                
            }
            return true;
        }

    }
    
    //sobrecarga para matrices 2d
    bool inicializar_tablero(ref Cell[,] board)
    {
        if (board == null)
        {
            Debug.Log("error al inicializar el tablero inicicalizar board con 'new' ");
            return false;
        }
        else
        {
            //crea un tablero en blanco
            for (int a = 0; a < _mazmorraSO.width; a++)
            {
                for(int b =0; b< _mazmorraSO.height; b++)
                    board[a,b] = new Cell();
                
            }
            return true;
        }
    }
}