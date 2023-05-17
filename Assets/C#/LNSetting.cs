using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LNSetting : MonoBehaviour
{
    [SerializeField] GameObject modeSelect;
    [SerializeField] GameObject LNGame;
    private int BPM = 180;
    private int length = 5;
    private int times = 3;
    private float HS = 1;
    private string spawnMode = "AllDon";
    public Text BPMText;
    public Text lengthText;
    public Text timesText;
    public Text HSText;
    void Start()
    {
        LoadLNSettingData();
        UpdateTexts();
    }
    private void LoadLNSettingData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/LNSettingData.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string test = sr.ReadLine();
        if (test != null)
        {
            BPM = int.Parse(test);
            length = int.Parse(sr.ReadLine());
            times = int.Parse(sr.ReadLine());
            HS = float.Parse(sr.ReadLine());
            spawnMode = sr.ReadLine();
        }
        sr.Close();
        fs.Close();
    }
    private void UpdateTexts()
    {
        BPMText.text = BPM.ToString();
        lengthText.text = length.ToString();
        timesText.text = times.ToString();
        HSText.text = HS.ToString();
    }
    public void SwitchToModeSelect()
    {
        Instantiate(modeSelect);
        Destroy(gameObject);
    }
    public void StartGame()
    {
        SaveLNSettingData();
        Instantiate(LNGame);
        Destroy(gameObject);
    }
    private void SaveLNSettingData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/LNSettingData.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(BPM);
        sw.WriteLine(length);
        sw.WriteLine(times);
        sw.WriteLine(HS);
        sw.WriteLine(spawnMode);
        sw.Close();
        fs.Close();
        Debug.Log("Àx¦s");
    }
    public void BPMMinus5()
    {
        BPM = BPM - 5;
        if (BPM <= 0)
        {
            BPM = 1;
        }
        BPMText.text = BPM.ToString();
    }
    public void BPMMinus1()
    {
        BPM = BPM - 1;
        if (BPM <= 0)
        {
            BPM = 1;
        }
        BPMText.text = BPM.ToString();
    }
    public void BPMAdd1()
    {
        BPM = BPM + 1;
        BPMText.text = BPM.ToString();
    }
    public void BPMAdd5()
    {
        BPM = BPM + 5;
        BPMText.text = BPM.ToString();
    }
    public void LengthMinus5()
    {
        length = length - 5;
        if (length <= 0)
        {
            length = 1;
        }
        lengthText.text = length.ToString();
    }
    public void LengthMinus1()
    {
        length = length - 1;
        if (length <= 0)
        {
            length = 1;
        }
        lengthText.text = length.ToString();
    }
    public void LengthAdd1()
    {
        length = length + 1;
        lengthText.text = length.ToString();
    }
    public void LengthAdd5()
    {
        length = length + 5;
        lengthText.text = length.ToString();
    }
    public void TimesMinus5()
    {
        times = times - 5;
        if (times <= 0)
        {
            times = 1;
        }
        timesText.text = times.ToString();
    }
    public void TimesMinus1()
    {
        times = times - 1;
        if (times <= 0)
        {
            times = 1;
        }
        timesText.text = times.ToString();
    }
    public void TimesAdd1()
    {
        times = times + 1;
        timesText.text = times.ToString();
    }
    public void TimesAdd5()
    {
        times = times + 5;
        timesText.text = times.ToString();
    }
    public void HSMinus1()
    {
        HS = HS - 1f;
        if(HS <= 0f)
        {
            HS = 0.1f;
        }
        //RoundHS();
        HSText.text = HS.ToString();
    }
    public void HSMinusPointOne()
    {
        HS = HS - 0.1f;
        if(HS <= 0f)
        {
            HS = 0.1f;
        }
        //RoundHS();
        HSText.text = HS.ToString();
    }
    public void HSAddPointOne()
    {
        HS = HS + 0.1f;
        //RoundHS();
        HSText.text = HS.ToString();
    }
    public void HSAdd1()
    {
        HS = HS + 1f;
        //RoundHS();
        HS.ToString();
    }
    private void RoundHS()
    {
        HS = Mathf.Round(HS * 10f) / 10f;
    }
    public void spawnModeAllDon()
    {
        spawnMode = "AllDon";
    }
    public void spawnModeAllKa()
    {
        spawnMode = "AllKa";
    }
    public void spawnModeAllDonOrAllKa()
    {
        spawnMode = "AllDonOrAllKa";
    }
    public void spawnModeTwoTwo()
    {
        spawnMode = "TwoTwo";
    }
    public void spawnModeFree()
    {
        spawnMode = "Free";
    }
}
