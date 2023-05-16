using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    public void CallGOToLNMode()
    {
        FindObjectOfType<Player>().GetComponent<Player>().GoToLNMode();
        Destroy(gameObject);
    }
    public void CallGOToSetting()
    {
        FindObjectOfType<Player>().GetComponent<Player>().GoToSetting();
        Destroy(gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
