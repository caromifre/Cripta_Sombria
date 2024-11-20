using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_audio_menu : MonoBehaviour
{
    [SerializeField] AudioSource fuenteAudio; // Control del AudioSource
    [SerializeField] Toggle botonOnOff; // Toggle del menú
    [SerializeField] Audio_config configuracionAudio; // Referencia al ScriptableObject

    void Start()
    {
        // Sincronizar el estado inicial con el ScriptableObject
        botonOnOff.isOn = configuracionAudio.Audio_onOff;
        fuenteAudio.enabled = configuracionAudio.Audio_onOff;

        // Suscribir al evento de cambio del Toggle
        botonOnOff.onValueChanged.AddListener(delegate { CambiarEstadoAudio(); });
    }

    void CambiarEstadoAudio()
    {
        // Actualizar el estado del ScriptableObject y del AudioSource
        configuracionAudio.Audio_onOff = botonOnOff.isOn;
        fuenteAudio.enabled = botonOnOff.isOn;
    }

}
