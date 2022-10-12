using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{

    public GameObject selectMode;
    public GameObject onlineMode;

    public Button startButton;
    public Button menuButton;
    public Button modeButton;

    public TextMeshProUGUI modeText;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI characterName;

    public TMP_InputField idInput;

    public Image characterImage;
    public Image modeImage;
    public Sprite[] characters;
    public Sprite[] modeLogos;

    private string lastType;

    private void Awake()
    {
        Manager.ResetVariable();
        characterImage.sprite = characters[Manager.numberCharac];
        characterName.text = Manager.charNames[Manager.numberCharac];
    }

    public void NextCharacter()
    {
        if (Manager.numberCharac < 5)
        {
            Manager.numberCharac += 1;
        }
        characterImage.sprite = characters[Manager.numberCharac];
        characterName.text = Manager.charNames[Manager.numberCharac];
    }

    public void PreviusCaharacter()
    {
        if (Manager.numberCharac > 0)
        {
            Manager.numberCharac -= 1;
        }
        characterImage.sprite = characters[Manager.numberCharac];
        characterName.text = Manager.charNames[Manager.numberCharac];
    }

    public void PressStart()
    {
        switch (Manager.modeType)
        {
            case "SURVIVAL":
                //Debug.Log($"{Manager.modeType}\n{Manager.onlineType}\n{Manager.onlineId}\n");
                SceneManager.LoadScene("Game");
                break;

            case "BRAWL":
                //Debug.Log($"{Manager.modeType}\n{Manager.onlineType}\n{Manager.onlineId}\n");
                SceneManager.LoadScene("Room");
                break;

            case "ONLINE":
                Debug.Log($"{Manager.modeType}\n{Manager.onlineType}\n{Manager.onlineId}\n");
                SceneManager.LoadScene("Room");
                break;
        }
    }

    public void ModePanel(bool action)
    {
        IntercButtons(!action);
        selectMode.SetActive(action);
    }

    public void OnlineClose()
    {
        onlineMode.SetActive(false);
    }

    public void SelectModeButtons(string modeType)
    {
        switch (modeType)
        {
            case "SURVIVAL":
                Manager.modeType = modeType;
                Manager.onlineType = null;
                Manager.onlineId = null;
                modeText.text = modeType;
                modeImage.sprite = modeLogos[0];
                ModePanel(false);
                break;

            case "BRAWL":
            case "ONLINE":
                onlineMode.SetActive(true);
                lastType = modeType;
                break;
        }
    }

    public void SelectOnlineButtons(string onlineType)
    {
        Manager.modeType = lastType;
        Manager.onlineType = onlineType;
        modeText.text = lastType;
        switch (onlineType)
        {
            case "CREATE":
                Manager.onlineId = null;
                modeImage.sprite = modeLogos[1];
                idText.text = onlineType;
                break;

            case "JOIN":
                Manager.onlineId = idInput.text;
                modeImage.sprite = modeLogos[2];
                idText.text = $"ID: {Manager.onlineId}";
                idInput.text = "";
                break;
        }
        OnlineClose();
        ModePanel(false);
    }

    private void IntercButtons(bool interac)
    {
        startButton.interactable = interac;
        modeButton.interactable = interac;
        menuButton.interactable = interac;
    }
}
