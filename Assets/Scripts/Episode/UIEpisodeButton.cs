using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class UIEpisodeButton : UISelectableButton, IScriptableObjectProperty
    {
        [SerializeField] private Episode m_Episode;
        [SerializeField] private Image icon;
        [SerializeField] private Text title;


        private void Start()
        {
            ApplyProperty(m_Episode);
        }


        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (m_Episode == null) return;

            LevelSequenceController.Instance.StartEpisode(m_Episode);
        }


        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is Episode == false) return;
            m_Episode = property as Episode;

            icon.sprite = m_Episode.PreviewImage;
            title.text = m_Episode.EpisodeName;
        }


    }
}
