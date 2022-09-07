using RiptideNetworking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageClient : MonoBehaviour
{
    public static MessageClient current;

    public static GameObject infopanel;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        infopanel = GameObject.FindGameObjectWithTag("InfoPanel");
    }


    #region Send
    public static void SendName()
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)NetworkMessages.name);
        message.AddString(Manager.charNames[Manager.numberCharac]);
        NetworkClient.Singleton.Client.Send(message);
    }
    #endregion

    #region Recive
    [MessageHandler((ushort)NetworkMessages.confirmname)]
    public static void ConfirmName(ushort fromClientId, Message message)
    {
        Manager.confirmname = message.GetBool();

        if (Manager.confirmname)
        {
            Instantiate(infopanel, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }

    [MessageHandler((ushort)NetworkMessages.newname)]
    public static void NewName(ushort fromClientId, Message message)
    {
        string[] playersName = message.GetStrings();

        foreach (var val in playersName)
        {
            Debug.Log(val);
        }
    }
    #endregion
}
