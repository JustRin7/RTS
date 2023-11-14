using UnityEngine;

[CreateAssetMenu()]
public class Quest : ScriptableObject
{

    [System.Serializable]
    public struct PhraseOnKey
    {
        public KeyCode key;
        public DialogPhrase dialog;
    }


    new public string name = "";
    //TODO: условия выполнения


}
