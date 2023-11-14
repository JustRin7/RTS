using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Episode : ScriptableObject
{

    [SerializeField] private string episodeName;
    public string EpisodeName => episodeName;


    [SerializeField] private string[] levels;//массив строк имен уровней
    public string[] Levels => levels;


    [SerializeField] private Sprite previewImage;
    public Sprite PreviewImage => previewImage;
}
