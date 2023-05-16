using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Setting : MonoBehaviour
{
    public Text LeftKaText;
    public Text LeftDonText;
    public Text RightDonText;
    public Text RightKaText;
    void Start()
    {
        LeftKaText.text = FindObjectOfType<Player>().GetComponent<Player>().leftKa;
        LeftDonText.text = FindObjectOfType<Player>().GetComponent<Player>().leftDon;
        RightDonText.text = FindObjectOfType<Player>().GetComponent<Player>().rightDon;
        RightKaText.text = FindObjectOfType<Player>().GetComponent<Player>().rightKa;
    }
    public void CallGoToModeSelect()
    {
        FindObjectOfType<Player>().GetComponent<Player>().GoToModeSelect();
        Destroy(gameObject);
    }
    public void CallRebindingLeftKa()
    {
        FindObjectOfType<Player>().GetComponent<Player>().RebindingLeftKa();
    }
    public void CallRebindingLeftDon()
    {
        FindObjectOfType<Player>().GetComponent<Player>().RebindingLeftDon();
    }
    public void CallRebindingRightDon()
    {
        FindObjectOfType<Player>().GetComponent<Player>().RebindingRightDon();
    }
    public void CallRebindingRightKa()
    {
        FindObjectOfType<Player>().GetComponent<Player>().RebindingRightKa();
    }
}
