using RiptideNetworking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MessageServer : MonoBehaviour
{
    public static MessageServer current;

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
        Message message = Message.Create(MessageSendMode.reliable, (ushort)NetworkMessages.confirmname);
        message.AddBool(confirmation);
        NetworkServer.Singleton.Server.Send(message, idClient);
    }

    public static void NewName()
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)NetworkMessages.newname);
        string[] name = { Manager.charNames[Manager.numberCharac] };
        string[] names = new string[6];
        Array.Copy(name, names, 1);
        Array.Copy(Manager.list.Values.ToArray(), 0, names, 1, Manager.list.Values.ToArray().Length);
        message.AddStrings(names);
        NetworkServer.Singleton.Server.SendToAll(message);
    }
    #endregion

    #region Recive
    [MessageHandler((ushort)NetworkMessages.name)]
    private static void Name(ushort fromClientId, Message message)
    {
        string name = message.GetString();

        if (name == Manager.charNames[Manager.numberCharac] || Manager.list.ContainsValue(name))
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
