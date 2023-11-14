using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GoldMine : MonoBehaviour
{
    private AudioSource changeGoldAudioSource;

    private void Start()
    {
        changeGoldAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Worker>(out var worker))
        {
            
            worker.MineGoldOrder(transform.position);
            changeGoldAudioSource.Play();
        }
    }


}
