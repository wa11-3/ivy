using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{
    string roomId;

    public GameObject[] networks;
    public GameObject[] players;

    public TextMeshProUGUI modeText;
    public TextMeshProUGUI idText;

    public Image modeImage;

    public Sprite[] characters;
    public Sprite[] modeLogos;

    GameObject network;

    private void Awake()
    {
        modeText.text = Manager.onlineType;
        switch (Manager.onlineType)
        {
            case "CREATE":
                roomId = Manager.GetRoomID(true);
                modeImage.sprite = modeLogos[0];
                idText.text = $"ID: {roomId}";
                Manager.onlineId = roomId;
                players[0].SetActive(true);
                players[0].GetComponentsInChildren<Image>()[1].sprite = characters[Manager.numberCharac];
                Instantiate(networks[0]);
                //network = Instantiate(networks[0], new Vector3(0,0,0), Quaternion.identity);
                break;

            case "JOIN":
                modeImage.sprite = modeLogos[1];
                idText.text = $"ID: {Manager.onlineId}";
                Instantiate(networks[1]);
                break;
        }
    }

    private void Start()
    {
    }

    void SetPlayerImage()
    {

    }
}