using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GetNPSDialog : InteractableItemBase, IDependency<DialogController>
{
    private DialogController dialoger;
    public void Construct(DialogController obj) => dialoger = obj;


    [SerializeField] private DialogPhrase initialDialog;

    private AudioSource dialogAudioSource;
    [SerializeField] private AudioClip hiSound;
    [SerializeField] private AudioClip byeSound;
    


    private void Start()
    {
        dialogAudioSource = GetComponent<AudioSource>();
    }


    public override void OnIteractAnimation(Animator animator)
    {
        dialoger.ShowNewPhrase(initialDialog);
    }


    public override bool CanInteract(Collider other)
    {
        return dialoger.DialogIsAvable;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            dialoger.ShowNewPhrase(initialDialog);
            dialogAudioSource.PlayOneShot(hiSound);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialoger.EndDialog();
            dialogAudioSource.PlayOneShot(byeSound);
        }
    }


}
