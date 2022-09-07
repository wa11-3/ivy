using RiptideNetworking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageClient : MonoBehaviour
{
    public static MessageClient current;

    public static GameObject infopanel;

    private static string[] charNames = {"FeAd","FePe","MaAd","MaPe","Robot","Zombie"};

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
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.name);
        message.AddString(charNames[Manager.numberCharac]);
        NetworkClient.Singleton.Client.Send(message);
    }
    #endregion

    #region Recive
    [MessageHandler((ushort)ServerToClientId.confirmname)]
    public static void ConfirmName(ushort fromClientId, Message message)
    {
        bool confirmation = message.GetBool();

        if (confirmation)
        {
            Instantiate(infopanel, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }

    [MessageHandler((ushort)ServerToClientId.newname)]
    public static void NewName(ushort fromClientId, Message message)
    {

    }
    #endregion
}
