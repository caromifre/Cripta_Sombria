using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [Header("Componentes")]
    public AudioSource audioSource;

    [Header("Sonidos")]
    public AudioClip walkSound;
    public AudioClip runSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Reproduce un sonido de pasos dependiendo del estado (caminando o corriendo)
    public void PlayFootstepSound(bool isRunning)
    {
        if (isRunning)
        {
            if (audioSource.clip != runSound)
            {
                audioSource.clip = runSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip != walkSound)
            {
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    // Detiene los sonidos de pasos
    public void StopFootstepSound()
    {
        // Verifica si el clip actual es un sonido de pasos (caminando o corriendo)
        if (audioSource.isPlaying && (audioSource.clip == walkSound || audioSource.clip == runSound))
        {
            // Detenemos gradualmente el sonido
            audioSource.loop = false; // Desactivamos el loop
            audioSource.Stop(); // Detenemos el audio
            audioSource.clip = null; // Limpiamos el clip actual
        }
    }



}

