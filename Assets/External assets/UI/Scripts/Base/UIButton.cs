using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected bool interactable;

    private bool focuse = false;
    public bool Focuse => focuse;

    public UnityEvent OnClick;

    public event UnityAction<UIButton> PointerEnter;
    public event UnityAction<UIButton> PointerExit;
    public event UnityAction<UIButton> PointerClick;


    public virtual void SetFocuse()
    {
        if (interactable == false) return;

        focuse = true;
    }


    public virtual void SetUnFocuse()
    {
        if (interactable == false) return;

        focuse = false;
    }


    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (interactable == false) return;

        PointerEnter?.Invoke(this);
    }


    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (interactable == false) return;

        PointerExit?.Invoke(this);
    }


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (interactable == false) return;

        PointerClick?.Invoke(this);
        OnClick?.Invoke();
    }


}
