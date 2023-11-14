using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogPhrase))]
public class DialogPhraseInspector : Editor
{


    public override void OnInspectorGUI()
    {        
        var t = (DialogPhrase)target;
        t.text = GUILayout.TextArea(t.text, 1000);
        base.OnInspectorGUI();
    }


}
