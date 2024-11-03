using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/*clase apra guardar en disco los datos del scriptable object*/
public class Guardar_nivel_Disk : ScriptableObject
{
    public void Guardar(string nom_arch=null) {

        //funcion para guardar los datos del scriptable object en modo binario
        BinaryFormatter Bf = new BinaryFormatter();
        //crear archivo
        FileStream file = File.Create(Obt_Dir( nom_arch));
        //convertir a json
        string json= JsonUtility.ToJson(this);
        //guardar
        Bf.Serialize(file, json);

        Debug.Log("directorio: " + Obt_Dir(nom_arch)  + " nombre: " + nom_arch);
        //cerrar
        file.Close();
    }
    public void Cargar(string nom_arch = null) {
        //carga los datos el scriptableObject
        if (File.Exists(Obt_Dir(nom_arch)))
        {
            //variable para descifrar modo binario
            BinaryFormatter Bf = new BinaryFormatter();
            //abrir archivo
            FileStream file = File.Open(Obt_Dir(nom_arch), FileMode.Open);
            //descifrar y sobreescrobir el scriptableObject
            JsonUtility.FromJsonOverwrite((string)Bf.Deserialize(file), this);
            //cerrar archivo
            Debug.Log("directorio: " + Obt_Dir(nom_arch) + " nombre: " + nom_arch);
            file.Close();
        }
    }

    string Obt_Dir(string nom_arch = null) {
        //comprueba y obtiene nombre  y direcion completo para guardar el archivo 

        //comprobar que haya un valor
        string nom_compl = string.IsNullOrEmpty(nom_arch)?name:nom_arch;
        //devuelve nombre completo mas extension
        return string.Format("{0}/{1}.bin", Application.persistentDataPath,nom_compl);
    }

    //----
    //-----------------------------
    //----

    //inicializa el array (tablero) en blanco
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
            for (int a = 0; a < board.GetLength(0); a++)
            {
                for (int b = 0; b < board.GetLength(1); b++)
                {
                    board[a, b] = new Cell();
                }
            }
            return true;
        }
    }

}
