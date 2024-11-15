using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/* clase para guardar en disco los datos del scriptable object
 * esta clase se usa para ser heredada en vez del ScriptableObject
 * asi el ScriptableObject que herede de esta clase ya tiene la funcion
 * de guardar a un archivo los datos que se le pasen*/
public class Guardar_nivel_Disk : ScriptableObject
{
    public void Guardar(Cell[] cell, string nom_arch=null) {//cambio a obtner la lista de cell desde la llmada al metodo

        //funcion para guardar los datos del scriptable object en modo binario
        BinaryFormatter Bf = new BinaryFormatter();
        //crear archivo
        FileStream file = File.Create(Obt_Dir( nom_arch));
        //convertir a json
        /*string json= JsonUtility.ToJson(this);
        string kk=JsonUtility.FromJson<string>(json);*/
        //guardar
        Bf.Serialize(file,cell);

        //Debug.Log("directorio: " + Obt_Dir(nom_arch)  + " nombre: " + nom_arch);
        //cerrar
        file.Close();
    }

    //----
    //-----------------------------
    //----
    public void Cargar(string nom_arch = null) {
        //carga los datos el scriptableObject
        if (File.Exists(Obt_Dir(nom_arch)))
        {
            //variable para descifrar modo binario
            BinaryFormatter Bf = new BinaryFormatter();
            //abrir archivo
            FileStream file = File.Open(Obt_Dir(nom_arch), FileMode.Open);
            //descifrar y sobreescrobir el scriptableObject
            //JsonUtility.FromJsonOverwrite((string)Bf.Deserialize(file), this);
            JsonUtility.ToJson(Bf.Deserialize(file),this);//modo binario
            //string jon=Bf.Deserialize(file); 
            //cerrar archivo

            Debug.Log("directorio: " + Obt_Dir(nom_arch) + " nombre: " + nom_arch);
            file.Close();
        }
    }

    //----
    //-----------------------------
    //----
    string Obt_Dir(string nom_arch = null) {
        //comprueba y obtiene nombre  y direcion completo para guardar el archivo 

        //comprobar que haya un valor
        string nom_compl = string.IsNullOrEmpty(nom_arch)?name:nom_arch;
        //devuelve nombre completo mas extension
        return string.Format("{0}/{1}.bin", Application.persistentDataPath,nom_compl);
    }

}
