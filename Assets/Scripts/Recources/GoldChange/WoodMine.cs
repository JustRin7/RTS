using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WoodMine : MonoBehaviour
{
    [SerializeField] private float timer;
    private float currentTime;
    private bool timerisSet;
    private AudioSource changeOilAudioSource;

    private void Start()
    {
        changeOilAudioSource = GetComponent<AudioSource>();
        timerisSet = false;
    }


    private void Update()
    {
        if(currentTime < timer && timerisSet == true)
        {
            currentTime += Time.deltaTime;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Worker>(out var worker))
        {
            if (currentTime >= timer)
            {
                worker.MineTreeOrder(transform.position);
                changeOilAudioSource.Stop();
                timerisSet = false;
                currentTime = 0;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Worker>(out var worker))
        {
            timerisSet = true;
            changeOilAudioSource.Play(); 
        }
    }


}
