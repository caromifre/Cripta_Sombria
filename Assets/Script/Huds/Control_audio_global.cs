using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*este script es para el control de audio fuera de la escena de inicio*/
public class Control_audio_global : MonoBehaviour
{
   
    [SerializeField] AudioSource fuenteAudio; // AudioSource de la escena
    [SerializeField] Audio_config configuracionAudio; // Referencia al ScriptableObject

    void Start()
    {
        // Sincronizar el AudioSource con el estado del ScriptableObject
        fuenteAudio.enabled = configuracionAudio.Audio_onOff;
    }

}
