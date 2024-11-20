using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Drop_colectables : MonoBehaviour, ISoltar_item
{
    [SerializeField] GameObject _drop_colectable; // Objeto que se instanciará
    [SerializeField] float _fuerza_impulso = 5f; // Fuerza del impulso
    [SerializeField] float _radio_explosion = 2f; // Radio de la explosión
    GameObject _Soltar_item;
    Rigidbody _rb;
    // Llamar esta función al eliminar al enemigo

    
    public void soltar_Item()
    {
        Debug.Log("Deteccion de muerte");
        // Instanciar el objeto en la posición del enemigo
        if (_drop_colectable != null)
        {
            _Soltar_item = Instantiate(_drop_colectable, transform.position, Quaternion.identity);

            // Verificar si tiene un Rigidbody para aplicar el impulso
            _rb = _Soltar_item.GetComponent<Rigidbody>();
            if (_rb != null)
            {
                Debug.Log("soltando item");
                // Aplicar un impulso en una dirección aleatoria
                Vector3 dir_explosion = Random.onUnitSphere * _radio_explosion; // Genera una dirección aleatoria en un radio especifico
                _rb.AddForce(dir_explosion * _fuerza_impulso, ForceMode.Impulse);
            }
        }

        // Destruir al enemigo
        //Destroy(gameObject);
    }
}
