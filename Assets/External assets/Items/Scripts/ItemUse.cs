using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemUse : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Inventory>().GetActiveItem().Use();
        }
    }


}
