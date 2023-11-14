using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneDependenciesContainer : Depandency
{
    //[SerializeField] private Unit unit;
    [SerializeField] private DialogController dialoger;
    [SerializeField] private LevelController levelController;
    [SerializeField] private UnitSelector unitSelector;
    [SerializeField] private DialogGetter dialogGetter;

    protected override void BindAll(MonoBehaviour monoBehaviorusInScene)
    {
        //Bind<Unit>(unit, monoBehaviorusInScene);
        Bind<DialogController>(dialoger, monoBehaviorusInScene);
        Bind<LevelController>(levelController, monoBehaviorusInScene);
        Bind<UnitSelector>(unitSelector, monoBehaviorusInScene);
        Bind<DialogGetter>(dialogGetter, monoBehaviorusInScene);



        //IDependency<TrackpointCircuit> t = mono as IDependency<TrackpointCircuit>;
        //if (t != null) t.Construct(trackpointCircuit);

        //или (mono as IDependency<TrackpointCircuit>)?.Construct(trackpointCircuit);

        //или if (mono is IDependency<RaceStateTracker>) (mono as IDependency<RaceStateTracker>).Construct(raceStateTracker);
    }


    private void Awake()
    {
        FindAllObjectToBind();
    }


}
