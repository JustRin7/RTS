using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneButton : UISelectableButton, IScriptableObjectProperty
{
    [SerializeField] private SceneInfo sceneInfo;

    [SerializeField] private Image icon;
    [SerializeField] private Text title;


    private void Start()
    {
        ApplyProperty(sceneInfo);
    }


    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (sceneInfo == null) return;

        SceneManager.LoadScene(sceneInfo.SceneName);
    }


    public void ApplyProperty(ScriptableObject property)
    {
        if (property == null) return;

        if (property is SceneInfo == false) return;
        sceneInfo = property as SceneInfo;

        icon.sprite = sceneInfo.Icon;
        title.text = sceneInfo.Title;
    }


}
