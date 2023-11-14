using UnityEngine;
using UnityEngine.UI;

public class ItemShowInfo : MonoBehaviour
{
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemDescription;

    private void Awake()
    {
        ItemGUI.OnItemSelected += UpdateItem; /*(InventoryItem ii) =>
        {
            itemName.text = ii.Name;
            itemDescription.text = ii.Description;
        };*/

        UpdateItem(FindObjectOfType<UseItem>().Item);
    }


    private void UpdateItem(InventoryItem ii)
        {
            itemName.text = ii.Name;
            itemDescription.text = ii.Description;
        }


}
