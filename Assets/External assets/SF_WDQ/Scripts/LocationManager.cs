using System;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    

    [Serializable]
    public class Setting
    {
        public string name;
        public Sprite backgound;
    }


    [SerializeField] private Setting[] settings;
    [SerializeField] private string currentLocation;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Location"))
        ChangeLocation(PlayerPrefs.GetString("Location"));
    }

    public void ChangeLocation(string newLocation)
    {
        Sprite sprite = null;

        foreach (var set in settings)
        {
            if (set.name == newLocation)
            {
                sprite = set.backgound;
                break;
            }
        }

        if (sprite)
        {
            currentLocation = newLocation;

            GameObject.FindWithTag("Location").GetComponent<UnityEngine.UI.Image>().sprite = sprite;

            PlayerPrefs.SetString("Location", newLocation);
        }
        else
            Debug.LogWarning($"Попытка перейти в локацию {newLocation}. Такой локации нет в настройках");
               
    }


}
