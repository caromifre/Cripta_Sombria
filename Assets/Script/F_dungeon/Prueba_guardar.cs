using System.IO;
using UnityEngine;

public class GuardarCargarMazmorra2 : MonoBehaviour
{
    [SerializeField] private SO_guardaNivel _mazmorraSO;
    private string _filePath;

    private void Awake()
    {
        // Define la ruta del archivo en la carpeta de persistencia de Unity
        _filePath = Path.Combine(Application.persistentDataPath, "mazmorraGuardada.json");
    }

    public void GuardarEnJSON()
    {
        string jsonData = JsonUtility.ToJson(_mazmorraSO);
        File.WriteAllText(_filePath, jsonData);
        Debug.Log("Mazmorra guardada en JSON en: " + _filePath);
    }

    public void CargarDesdeJSON()
    {
        if (File.Exists(_filePath))
        {
            string jsonData = File.ReadAllText(_filePath);
            JsonUtility.FromJsonOverwrite(jsonData, _mazmorraSO);
            Debug.Log("Mazmorra cargada desde JSON.");
        }
        else
        {
            Debug.LogError("No se encontró el archivo de la mazmorra.");
        }
    }
}
