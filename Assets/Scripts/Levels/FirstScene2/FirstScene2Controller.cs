using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene2Controller : MonoBehaviour, IDependency<DialogGetter>
{
    private DialogGetter dialogGetter;
    public void Construct(DialogGetter obj) => dialogGetter = obj;

    [SerializeField] private Resource goldResource;
    private int gold;
    [SerializeField] private int setGold;

    [SerializeField] public GameObject finishPosition;
    [SerializeField] private DialogPhrase initialDialog;


    void Awake()
    {
        finishPosition.SetActive(false);
        goldResource.OnChangeResource += ShowGoldResouce;
    }

    
    void Update()
    {
        if (gold >= setGold)
        {
            dialogGetter.GetDialog(initialDialog);
            finishPosition.SetActive(true);
        }
    }


    private void OnDestroy()
    {
        goldResource.OnChangeResource -= ShowGoldResouce;
    }


    private void ShowGoldResouce(int resouceValue)
    {
        gold = resouceValue;
    }


}
