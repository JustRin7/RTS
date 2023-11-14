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

    [Header("Смена локации")]
    public string newLocation = "";

    [Header("Ситуация")]
    public Sprite situationSprite;
}
