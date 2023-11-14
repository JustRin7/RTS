using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OilBorehole : MonoBehaviour
{
    private AudioSource changeOilAudioSource;

    private void Start()
    {
        changeOilAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Worker>(out var worker))
        {

            worker.MineOilOrder(transform.position);
            changeOilAudioSource.Play();
        }
    }


}
