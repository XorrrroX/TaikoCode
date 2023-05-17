using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject modeSelect;
    [SerializeField] GameObject LNModeSetting;
    public Text perfectCountText;
    public Text goodCountText;
    public Text missCountText;
    private int perfectCount;
    private int goodCount;
    private int missCount;
    void Start()
    {
        LoadResultData();
        perfectCountText.text = perfectCount.ToString();
        goodCountText.text = goodCount.ToString();
        missCountText.text = missCount.ToString();
    }
    private void LoadResultData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/resultData.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        perfectCount = int.Parse(sr.ReadLine());
        goodCount = int.Parse(sr.ReadLine());
        missCount = int.Parse(sr.ReadLine());
        sr.Close();
        fs.Close();
    }
    public void BackToModeSelect()
    {
        SwitchModeSelect();
    }
    public void SwitchModeSelect()
    {
        Instantiate(modeSelect);
        Destroy(gameObject);
    }
    public void Retry()
    {
        SwitchToLNModeSetting();
    }
    public void SwitchToLNModeSetting()
    {
        Instantiate(LNModeSetting);
        Destroy(gameObject);
    }
}
