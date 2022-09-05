using RiptideNetworking;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageServer : MonoBehaviour
{
    public static MessageServer current;

    public static Dictionary<ushort, string> list = new Dictionary<ushort, string>();

    private static string[] charNames = { "FeAd", "FePe", "MaAd", "MaPe", "Robot", "Zombie" };

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

    #region Send
    public static void ConfirmName()
    {
        Message message = Message.Create();
        message.AddString(charNames[Manager.numberCharac]);
        //NetworkServer.Singleton.Server.Send(message, 0);
    }
    #endregion

    #region Recive
    [MessageHandler((ushort)ClientToServerId.name)]
    private static void Name(ushort fromClientId, Message message)
    {
        string name = message.GetString();

        if (name != charNames[Manager.numberCharac] && Array.IndexOf(charNames, name) == -1)
        {
            Debug.Log("No Esta");
            list.Add(fromClientId, name);
        }
        else
        {
            ConfirmName();
            Debug.Log("Esta");
        }
    }
    #endregion
}
