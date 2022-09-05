using RiptideNetworking;
using System.Collections.Generic;
using UnityEngine;

public class MessageClient : MonoBehaviour
{
    public static MessageClient current;

    public static Dictionary<ushort, string> list = new Dictionary<ushort, string>();

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



    #region Send
    public static void SendName()
    {
        Message message = Message.Create();
        message.AddString(charNames[Manager.numberCharac]);
        NetworkClient.Singleton.Client.Send(message);
    }
    #endregion

    #region Recive
    #endregion
}
