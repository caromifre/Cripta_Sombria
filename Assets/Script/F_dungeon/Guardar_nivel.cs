using UnityEngine;

/*clase para guardar o cargar el nivel o mazmorra creada aleatoriamente*/
public class GuardarCargarMazmorra : MonoBehaviour
{
    [SerializeField] private SO_guardaNivel _mazmorraSO;
    public int _whidth, _height;
    string _name_arch;

    private void Awake()
    {
        //precargar informacion del SO
        _name_arch = _mazmorraSO.archivo;
        _whidth = _mazmorraSO.width;
        _height = _mazmorraSO.height;
    }
    public void GuardarEnScriptableObject(Cell[,] board, int x, int y,float o_x,float o_y)
    {
        //guardar la mazmorra o nivel elegido
        /* Este metodo recibe el tablero a ser guardado en board
         en x e y las dimensiones de la matriz*/
        _mazmorraSO.width = x;
        _mazmorraSO.height = y;
        _mazmorraSO.offset_X = o_x;
        _mazmorraSO.offset_Y = o_y;
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
                //guardar datos en archivo binario en 
                _mazmorraSO.Guardar(_mazmorraSO.cells,_mazmorraSO.archivo);
                Debug.Log("Mazmorra guardada en Scriptable Object");
          }
    }

    //-----
    //--------------------------------
    //-----
    
    public void CargarDesdeScriptableObject(ref Cell[,] board,ref float o_x,ref float o_y)
    {
        //carga el o los niveles desde el scriptable object
        /* Este metodo recibe el tablero como referencia en board
         en x e y las dimensiones de la matriz busca el archivo
        donde se guardo al configuracion del scriotableObject y 
        lo carga en la matriz board*/
        board = new Cell[_mazmorraSO.width, _mazmorraSO.height];

        if(inicializar_tablero(ref board)){
            //obtener datos del archivo binario
            int c = 0;
            _mazmorraSO.Cargar(_mazmorraSO.archivo);
            o_x = _mazmorraSO.offset_X;
            o_y = _mazmorraSO.offset_Y;
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

    
    bool inicializar_tablero(ref Cell[] board)
    {
        //inicializa el array (tablero) en blanco
        //para un array unidimensional
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

    //----
    //-----------------------------
    //----

    bool inicializar_tablero(ref Cell[,] board)
    {
        //sobrecarga para matrices 2d
        //inicializa el array (tablero) en blanco
        //para un matriz 2D
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

    //----
    //-----------------------------
    //----
    public string Obt_nom_archivo() {
        return _name_arch;
    }
}