using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Start()
    {
        score.text = "Score:\n" + Manager.score.ToString("f0");
    }

    public void GoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
