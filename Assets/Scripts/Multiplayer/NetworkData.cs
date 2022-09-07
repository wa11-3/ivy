using UnityEngine;
using RiptideNetworking;
using RiptideNetworking.Utils;

public enum ServerToClientId : ushort
{
    confirmname = 1,
    newname = 2
}

public enum ClientToServerId : ushort
{
    name = 1,
}

public class NetworkData : MonoBehaviour
{
}
