using RiptideNetworking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MessageServer : MonoBehaviour
{
    public static MessageServer current;

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
    public static void ConfirmName(ushort idClient, bool confirmation)
    {
        Message message = Message.Create();
        message.AddBool(confirmation);
        NetworkServer.Singleton.Server.Send(message, idClient);
    }

    public static void NewName()
    {
        Message message = Message.Create();
        message.AddStrings(Manager.list.Values.ToArray());
        NetworkServer.Singleton.Server.SendToAll(message);
    }
    #endregion

    #region Recive
    [MessageHandler((ushort)ClientToServerId.name)]
    private static void Name(ushort fromClientId, Message message)
    {
        string name = message.GetString();

        if (name == charNames[Manager.numberCharac] || Manager.list.ContainsValue(name))
        {
            ConfirmName(fromClientId, false);
        }
        else
        {
            ConfirmName(fromClientId, true);
            Manager.list.Add(fromClientId, name);
            NewName();
        }
    }
    #endregion
}
