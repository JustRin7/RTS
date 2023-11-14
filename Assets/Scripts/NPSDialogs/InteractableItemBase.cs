using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemBase : MonoBehaviour
{
    public string Name;
    public Sprite Image;
    public string InteractText = "Press F to item";
    public EItemType ItemType;


    public virtual void OnIteractAnimation(Animator animator)
    {
        animator.SetTrigger("tp_pickup");
    }


    public virtual void OnInteract()
    {

    }


    public virtual bool CanInteract(Collider other)
    {
        return true;
    }

}
