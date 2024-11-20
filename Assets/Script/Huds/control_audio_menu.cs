using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_audio_menu : MonoBehaviour
{
    [SerializeField] AudioSource _audio;//control audio
    [SerializeField] Toggle _boton_onoff;
    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el Toggle refleje el estado inicial del audio
        _boton_onoff.isOn = _audio.enabled;

        // Suscribir el método onOff_sound al evento del Toggle
        _boton_onoff.onValueChanged.AddListener(delegate { onOff_sound(); });
    }

    void onOff_sound() {

        _audio.enabled = !_audio.enabled;
    }

}
