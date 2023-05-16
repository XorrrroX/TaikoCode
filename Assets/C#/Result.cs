using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text perfectCountText;
    public Text goodCountText;
    public Text missCountText;
    private Player Player;
    void Start()
    {
        Player = FindObjectOfType<Player>();
        perfectCountText.text = Player.perfectCount.ToString();
        goodCountText.text = FindObjectOfType<Player>().GetComponent<Player>().goodCount.ToString();
        missCountText.text = FindObjectOfType<Player>().GetComponent<Player>().missCount.ToString();
    }
    public void ResetGame()
    {
        FindObjectOfType<Player>().GetComponent<Player>().ResetScore();
        FindObjectOfType<Player>().GetComponent<Player>().GoToModeSelect();
        Destroy(gameObject);
    }
    public void Retry()
    {
        FindObjectOfType<Player>().GetComponent<Player>().ResetScore();
        FindObjectOfType<Player>().GetComponent<Player>().GoToLNMode();
        Destroy(gameObject);
    }
}
