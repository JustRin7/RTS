using UnityEngine;

[CreateAssetMenu()]
public class DialogPhrase : ScriptableObject
{

    [System.Serializable]
    public struct PhraseOnKey
    {
        public KeyCode key;
        public DialogPhrase dialog;
    }


    public string text = "";
    public Quest[] startQuests;
    public Quest[] endQuests;
    public PhraseOnKey[] phraseOnKeys = { new PhraseOnKey { key = KeyCode.Return } };

    [Header("����� �������")]
    public string newLocation = "";

    [Header("��������")]
    public Sprite situationSprite;
}
