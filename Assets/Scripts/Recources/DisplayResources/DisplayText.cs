using UnityEngine;
using UnityEngine.UI;

public abstract class DisplayText : MonoBehaviour
{
    [SerializeField] private Text displayText;

    private void Awake()
    {
        var resource = FindResource();
        resource.OnChangeResource += ShowResouceOnText;
    }


    protected abstract Resource FindResource();


    private void ShowResouceOnText(int resouceValue)
    {
        displayText.text = resouceValue.ToString();
    }
}
