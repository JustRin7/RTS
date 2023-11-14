using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(QuestController))]
public class DialogController : MonoBehaviour
{
    [SerializeField] private DialogPhrase activePhrase;
    [SerializeField] private bool forceStartPhrase = false;
    [SerializeField] private Text textDisplay;
    private QuestController questController;


    public bool DialogIsAvable {
        get{
            return !textDisplay.transform.parent.gameObject.activeSelf;
        }
    }


    void Start()
    {
        questController = GetComponent<QuestController>();

        //�������� �������
        /*if (!forceStartPhrase)
        {
            if(PlayerPrefs.HasKey("Phrase"))
            {
                var savedArrayString = PlayerPrefs.GetString("Phrase");
                (DialogPhrase phrase, int _) loadedData = JsonUtility.FromJson<(DialogPhrase phrase, int _)>(savedArrayString);
                if(loadedData.phrase)
                    activePhrase = loadedData.phrase;
            }
        }*/

        ShowNewPhrase(activePhrase);
    }


    public void ShowNewPhrase(DialogPhrase dp)
    {
        textDisplay.transform.parent.gameObject.SetActive(true);

        //�������
        if (dp.newLocation != "")
        {
            var lman = FindObjectOfType<LocationManager>();
            if (lman != null)
                lman.ChangeLocation(dp.newLocation);
        }

        //��������
        Image situationImage = GameObject.FindWithTag("Situation").GetComponent<Image>();

        if (dp.situationSprite)
        {            
            situationImage.enabled = true;
            situationImage.sprite = dp.situationSprite;
        }
        else
        {
            
            situationImage.enabled = false;
        }

        //�����
        textDisplay.text = dp.text;


        //������
        foreach (var quest in dp.endQuests)
        {
            if (quest)
            {
                questController.Dectivate(quest);
            }
        }


        foreach (var quest in dp.startQuests)
        {
            if (quest)
            {
                questController.Activate(quest);                
            }
        }        

            

        activePhrase = dp;
        
        //���������� �������
        /*(DialogPhrase phrase, int _) savedPhrase = (activePhrase, 0);
        PlayerPrefs.SetString("Phrase", JsonUtility.ToJson(savedPhrase));*/
    }


    private void Update()
    {
        foreach(var pk in activePhrase.phraseOnKeys)
        {
            if(Input.GetKeyDown(pk.key) ||
                (pk.key == KeyCode.Return && Input.GetMouseButtonDown(0)) )
            {

                if (pk.dialog)
                {
                    ShowNewPhrase(pk.dialog);
                }
                else
                {
                    EndDialog();
                }
                
            }
        }
    }

    public void EndDialog()
    {
        Image situationImage = GameObject.FindWithTag("Situation").GetComponent<Image>();
        situationImage.enabled = false;

        textDisplay.transform.parent.gameObject.SetActive(false);
    }


}
