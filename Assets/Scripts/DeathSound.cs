using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PauseAudioSource))]
public class DeathSound : MonoBehaviour
{
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }


}
