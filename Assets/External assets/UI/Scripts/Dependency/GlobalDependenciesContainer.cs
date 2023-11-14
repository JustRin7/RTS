using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalDependenciesContainer : Depandency
{
    [SerializeField] private Pauser pauser;

    private static GlobalDependenciesContainer instance;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    protected override void BindAll(MonoBehaviour monoBehaviorusInScene)
    {
        Bind<Pauser>(pauser, monoBehaviorusInScene);
    }


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        FindAllObjectToBind();
    }


}
