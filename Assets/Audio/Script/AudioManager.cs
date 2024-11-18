using UnityEngine;
using System.Collections;

public class AudioSourceManager : MonoBehaviour
{
    [Header("Componentes")]
    public AudioSource audioSource;
    public AudioSource audioSourceItem;
    public AudioSource audioSourceDamage;
    public AudioSource audioSourceDie;


    [Header("Sonidos")]
    public AudioClip itemPickupSound;

    private bool isDamageSoundPlaying = false;
    private bool isDieSoundPlaying = false;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Reproduce un sonido de pasos dependiendo del estado (caminando o corriendo)
    public void PlayFootstepSound(bool isRunning, AudioClip walkSound, AudioClip runSound)
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
        if (audioSource.isPlaying && audioSource.clip != itemPickupSound)
        {
            // Detenemos gradualmente el sonido
            audioSource.loop = false; // Desactivamos el loop
            audioSource.Stop(); // Detenemos el audio
            audioSource.clip = null; // Limpiamos el clip actual
        }
    }
    // Reproduce el sonido de recoger un ítem
    public void PlayItemPickupSound()
    {
        if (itemPickupSound != null)
        {
            audioSourceItem.PlayOneShot(itemPickupSound);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el sonido para recoger ítem");
        }
    }
    public void DamageEnemy(AudioClip sound)
    {
        if (sound != null && !isDamageSoundPlaying)
        {
            isDamageSoundPlaying = true;
            audioSourceDamage.PlayOneShot(sound);
            StartCoroutine(ResetDamageSound(0f)); //2.14
        }
    }
    private IEnumerator ResetDamageSound(float clipDuration)
    {
        yield return new WaitForSeconds(clipDuration); 
        isDamageSoundPlaying = false; 
    }
    public void Die(AudioClip sound)
    {
        if (sound != null && !isDieSoundPlaying)
        {
            isDieSoundPlaying = true;
            audioSourceDie.PlayOneShot(sound);
            StartCoroutine(ResetDamageSound(0f)); //2.14
        }
    }
}