using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ShowPlayerItems m_ShowPlayerItems;
    [SerializeField] private ItemShowInfo m_ItemShowInfo;
    [SerializeField] private Button m_buttonOn;


    private void Start()
    {
        Toggle(false);
    }


    public void Toggle(bool on)
    {
        if (on)
        {
            foreach(var manager in FindObjectsOfType<InventoryManager>())
            {
                manager.Toggle(false);
            }
        }

        m_ShowPlayerItems.gameObject.SetActive(on);
        m_ItemShowInfo.gameObject.SetActive(on);
        m_buttonOn.gameObject.SetActive(!on);
    }


}
