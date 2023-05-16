using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LNSetting : MonoBehaviour
{
    public Text BPMText;
    public Text lengthText;
    public Text timesText;
    public Text HSText;
    void Start()
    {
        
        BPMText.text = FindObjectOfType<Player>().GetComponent<Player>().BPM.ToString();
        lengthText.text = FindObjectOfType<Player>().GetComponent<Player>().length.ToString();
        timesText.text = FindObjectOfType<Player>().GetComponent<Player>().times.ToString();
        HSText.text = FindObjectOfType<Player>().GetComponent<Player>().HS.ToString();
    }
    public void CallGoToModeSelect()
    {
        FindObjectOfType<Player>().GetComponent<Player>().GoToModeSelect();
        Destroy(gameObject);
    }
    public void CallGoToLNGame()
    {
        FindObjectOfType<Player>().GetComponent<Player>().GoToLNGame();
        Destroy(gameObject);
    }
    public void BPMMinus5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().BPM = FindObjectOfType<Player>().GetComponent<Player>().BPM - 5;
        if (FindObjectOfType<Player>().GetComponent<Player>().BPM <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().BPM = 1;
        }
        BPMText.text = FindObjectOfType<Player>().GetComponent<Player>().BPM.ToString();
    }
    public void BPMMinus1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().BPM = FindObjectOfType<Player>().GetComponent<Player>().BPM - 1;
        if (FindObjectOfType<Player>().GetComponent<Player>().BPM <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().BPM = 1;
        }
        BPMText.text = FindObjectOfType<Player>().GetComponent<Player>().BPM.ToString();
    }
    public void BPMAdd1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().BPM = FindObjectOfType<Player>().GetComponent<Player>().BPM + 1;
        BPMText.text = FindObjectOfType<Player>().GetComponent<Player>().BPM.ToString();
    }
    public void BPMAdd5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().BPM = FindObjectOfType<Player>().GetComponent<Player>().BPM + 5;
        BPMText.text = FindObjectOfType<Player>().GetComponent<Player>().BPM.ToString();
    }
    public void LengthMinus5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().length = FindObjectOfType<Player>().GetComponent<Player>().length - 5;
        if (FindObjectOfType<Player>().GetComponent<Player>().length <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().length = 1;
        }
        lengthText.text = FindObjectOfType<Player>().GetComponent<Player>().length.ToString();
    }
    public void LengthMinus1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().length = FindObjectOfType<Player>().GetComponent<Player>().length - 1;
        if (FindObjectOfType<Player>().GetComponent<Player>().length <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().length = 1;
        }
        lengthText.text = FindObjectOfType<Player>().GetComponent<Player>().length.ToString();
    }
    public void LengthAdd1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().length = FindObjectOfType<Player>().GetComponent<Player>().length + 1;
        lengthText.text = FindObjectOfType<Player>().GetComponent<Player>().length.ToString();
    }
    public void LengthAdd5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().length = FindObjectOfType<Player>().GetComponent<Player>().length + 5;
        lengthText.text = FindObjectOfType<Player>().GetComponent<Player>().length.ToString();
    }
    public void TimesMinus5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().times = FindObjectOfType<Player>().GetComponent<Player>().times - 5;
        if (FindObjectOfType<Player>().GetComponent<Player>().times <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().times = 1;
        }
        timesText.text = FindObjectOfType<Player>().GetComponent<Player>().times.ToString();
    }
    public void TimesMinus1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().times = FindObjectOfType<Player>().GetComponent<Player>().times - 1;
        if (FindObjectOfType<Player>().GetComponent<Player>().times <= 0)
        {
            FindObjectOfType<Player>().GetComponent<Player>().times = 1;
        }
        timesText.text = FindObjectOfType<Player>().GetComponent<Player>().times.ToString();
    }
    public void TimesAdd1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().times = FindObjectOfType<Player>().GetComponent<Player>().times + 1;
        timesText.text = FindObjectOfType<Player>().GetComponent<Player>().times.ToString();
    }
    public void TimesAdd5()
    {
        FindObjectOfType<Player>().GetComponent<Player>().times = FindObjectOfType<Player>().GetComponent<Player>().times + 5;
        timesText.text = FindObjectOfType<Player>().GetComponent<Player>().times.ToString();
    }
    public void HSMinus1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().HS = FindObjectOfType<Player>().GetComponent<Player>().HS - 1f;
        if(FindObjectOfType<Player>().GetComponent<Player>().HS <= 0f)
        {
            FindObjectOfType<Player>().GetComponent<Player>().HS = 0.1f;
        }
        HSText.text = FindObjectOfType<Player>().GetComponent<Player>().HS.ToString();
    }
    public void HSMinus0()
    {
        FindObjectOfType<Player>().GetComponent<Player>().HS = FindObjectOfType<Player>().GetComponent<Player>().HS - 0.1f;
        if(FindObjectOfType<Player>().GetComponent<Player>().HS <= 0f)
        {
            FindObjectOfType<Player>().GetComponent<Player>().HS = 0.1f;
        }
        HSText.text = FindObjectOfType<Player>().GetComponent<Player>().HS.ToString();
    }
    public void HSAdd0()
    {
        FindObjectOfType<Player>().GetComponent<Player>().HS = FindObjectOfType<Player>().GetComponent<Player>().HS + 0.1f;
        HSText.text = FindObjectOfType<Player>().GetComponent<Player>().HS.ToString();
    }
    public void HSAdd1()
    {
        FindObjectOfType<Player>().GetComponent<Player>().HS = FindObjectOfType<Player>().GetComponent<Player>().HS + 1f;
        HSText.text = FindObjectOfType<Player>().GetComponent<Player>().HS.ToString();
    }
    public void spawnModeAllDon()
    {
        FindObjectOfType<Player>().GetComponent<Player>().spawnMode = "AllDon";
    }
    public void spawnModeAllKa()
    {
        FindObjectOfType<Player>().GetComponent<Player>().spawnMode = "AllKa";
    }
    public void spawnModeAllDonOrAllKa()
    {
        FindObjectOfType<Player>().GetComponent<Player>().spawnMode = "AllDonOrAllKa";
    }
    public void spawnModeTwoTwo()
    {
        FindObjectOfType<Player>().GetComponent<Player>().spawnMode = "TwoTwo";
    }
    public void spawnModeFree()
    {
        FindObjectOfType<Player>().GetComponent<Player>().spawnMode = "Free";
    }
}
