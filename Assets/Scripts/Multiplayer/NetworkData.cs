using UnityEngine;
using RiptideNetworking;
using RiptideNetworking.Utils;

public enum ServerToClientId : ushort
{
    playerSpawned = 1,
}

public enum ClientToServerId : ushort
{
    name = 1,
}

public class NetworkData : MonoBehaviour
{
}