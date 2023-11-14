using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMineAndForest : MonoBehaviour, IDependency<DialogController>
{
    private DialogController dialoger;
    public void Construct(DialogController obj) => dialoger = obj;


    [SerializeField] private DialogPhrase initialDialog;

    private bool inExplore = true;


    private void OnTriggerEnter(Collider other)
    {
        if(inExplore == true)
            {
            if (other.CompareTag("Player"))
            {
                inExplore = false;
                dialoger.ShowNewPhrase(initialDialog);
            }
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if(inExplore == true)
        {
            if (other.CompareTag("Player"))
            {
                dialoger.EndDialog();
            }
        }
        
    }


}
