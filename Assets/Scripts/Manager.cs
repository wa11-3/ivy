using System.Net;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Manager : MonoBehaviour
{
    public static Manager current;

    public static Dictionary<ushort, string> list = new Dictionary<ushort, string>();

    public static int numberCharac = 0;

    public static string modeType = "SURVIVAL";
    public static string onlineType = null;
    public static string onlineId = null;
    public static string onlineServer = null;

    public static float enviVelocity = 0.001f;

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
        //onlineServer = GetIP() + onlineId;
    }

    public static string GetIP()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return null;
    }

    public static string GetRoomID(bool opt)
    {
        string ipRoom = GetIP();
        Regex rx = new Regex(@"(\d{1,3}.\d{1,3}.\d{1,3}.)(\d{1,3})");
        MatchCollection matches = rx.Matches(ipRoom);
        if (opt)
        {
            return matches[0].Groups[2].Value;
        }
        else
        {
            return matches[0].Groups[1].Value;
        }
    }
}
