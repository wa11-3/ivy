using System;
using UnityEngine;
using RiptideNetworking;
using RiptideNetworking.Utils;

public class NetworkClient : MonoBehaviour
{
    private static NetworkClient _singleton;
    public static NetworkClient Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(NetworkClient)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    public Client Client { get; private set; }

    private string ip;
    [SerializeField] private ushort port;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);

        ip = Manager.GetRoomID(false) + Manager.onlineId.ToString();

        Client = new Client();
        Client.Connect($"{ip}:{port}");
    }

    private void FixedUpdate()
    {
        Client.Tick();
    }

    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }
}
