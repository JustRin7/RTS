using UnityEngine;

public class DialogGetter : MonoBehaviour, IDependency<DialogController>
{
    private DialogController dialoger;
    public void Construct(DialogController obj) => dialoger = obj;


    public void GetDialog(DialogPhrase initialDialog)
    {
        dialoger.ShowNewPhrase(initialDialog);
    }
}
