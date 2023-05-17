using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LNGame : MonoBehaviour
{
    float timer = 0f;
    float coldTime;
    [SerializeField] GameObject result;
    [SerializeField] GameObject DonRail;
    [SerializeField] GameObject KaRail;
    [SerializeField] Text Combo;
    int StartCount = 0;
    int nowTimes = 0;
    int noteCount = 0;
    int random = 0;
    int twotwo = 0;
    public int floor = 0;
    public float D;
    float wantTime = 0;

    private int BPM;
    private int length;
    private int times;
    private float HS;
    private string spawnMode;
    public float noteSpeed;

    private int combo = 0;
    private int perfectCount = 0;
    private int goodCount = 0;
    private int missCount = 0;
    void Start()
    {
        LoadLNSettingData();
        noteSpeed = HS / (60f / (BPM * 4f));
        coldTime = 1f / (BPM / 60f) / 4f;
        InvokeRepeating("Spawn",0f,coldTime);
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
    void Update()
    {
        timer += Time.deltaTime;
        Combo.text = combo.ToString();
    }
    void AllDonSpawn()
    {
        if (nowTimes < times)
        {
            if (noteCount < length)
            {
                DonSpawn();
                noteCount++;
            }
            else
            {
                noteCount = 0;
                nowTimes++;
            }
        }
        else
        {
            if (DonRail.transform.childCount == 0 && KaRail.transform.childCount == 0)
            {
                EndGame();
            }
        }
    }
    void AllKaSpawn()
    {
        if (nowTimes < times)
        {
            if (noteCount < length)
            {
                KaSpawn();
                noteCount++;
            }
            else
            {
                noteCount = 0;
                nowTimes++;
            }
        }
        else
        {
            if (DonRail.transform.childCount == 0 && KaRail.transform.childCount == 0)
            {
                EndGame();
            }
        }
    }
    void AllDonOrAllKaSpawn()
    {
        if (nowTimes < times)
        {

            if (noteCount == 0)
            {
                random = Random.Range(0, 2);
            }
            switch (random)
            {
                case 0:
                    if (noteCount < length)
                    {
                        DonSpawn();
                        noteCount++;
                    }
                    else
                    {
                        noteCount = 0;
                        nowTimes++;
                    }
                    break;
                case 1:
                    if (noteCount < length)
                    {
                        KaSpawn();
                        noteCount++;
                    }
                    else
                    {
                        noteCount = 0;
                        nowTimes++;
                    }
                    break;
            }

        }
        else
        {
            if (DonRail.transform.childCount == 0 && KaRail.transform.childCount == 0)
            {
                EndGame();
            }
        }
    }
    void TwoTwoSpawn()
    {
        if (nowTimes < times)
        {
            if (noteCount == 0 || twotwo == 2)
            {
                random = Random.Range(0, 2);
                twotwo = 0;
            }
            if (noteCount < length)
            {
                switch (random)
                {
                    case 0:
                        DonSpawn();
                        twotwo++;
                        noteCount++;
                        break;
                    case 1:
                        KaSpawn();
                        twotwo++;
                        noteCount++;
                        break;
                }
            }
            else
            {
                noteCount = 0;
                nowTimes++;
            }
        }
        else
        {
            if (DonRail.transform.childCount == 0 && KaRail.transform.childCount == 0)
            {
                EndGame();
            }
        }
    }
    void FreeSpawn()
    {
        if (nowTimes < times)
        {
            if (noteCount < length)
            {
                random = Random.Range(0, 2);
                switch (random)
                {
                    case 0:
                        DonSpawn();
                        noteCount++;
                        break;
                    case 1:
                        KaSpawn();
                        noteCount++;
                        break;
                }
            }
            else
            {
                noteCount = 0;
                nowTimes++;
            }
        }
        else
        {
            if (DonRail.transform.childCount == 0 && KaRail.transform.childCount == 0)
            {
                EndGame();
            }
        }
    }
    void DonSpawn()
    {
        DonRail.GetComponent<Rail>().SpawnNote();
        floor-=1;
    }
    void KaSpawn()
    {
        KaRail.GetComponent<Rail>().SpawnNote();
        floor-=1;
    }
    public void LeftKa(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (KaRail.transform.childCount > 0)
            {
                KaRail.transform.GetChild(0).GetComponent<Note>().Click();
            }
        }
    }
    public void RightKa(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (KaRail.transform.childCount > 0)
            {
                KaRail.transform.GetChild(0).GetComponent<Note>().Click();
            }
        }
    }
    public void LeftDon(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (DonRail.transform.childCount > 0)
            {
                DonRail.transform.GetChild(0).GetComponent<Note>().Click();
            }
        }
    }
    public void RightDon(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (DonRail.transform.childCount > 0)
            {
                DonRail.transform.GetChild(0).GetComponent<Note>().Click();
            }
        }
    }
    void EndGame()
    {
        SaveResultData();
        Instantiate(result);
        Destroy(gameObject);
    }
    private void SaveResultData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/resultData.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(perfectCount);
        sw.WriteLine(goodCount);
        sw.WriteLine(missCount);
        sw.Close();
        fs.Close();
    }
    void Spawn()
    {
        wantTime += coldTime;
        D = timer - wantTime;
            if(StartCount < 16){
                StartCount++;
            }
            else if(StartCount < 32)
            {
                StartCount++;
                switch(spawnMode)
                {
                    case "AllDon":
                        AllDonSpawn();
                        break;
                    case "AllKa":
                        AllKaSpawn();
                        break;
                    case "AllDonOrAllKa":
                        AllDonOrAllKaSpawn();
                        break;
                    case "TwoTwo":
                        TwoTwoSpawn();
                        break;
                    case "Free":
                        FreeSpawn();
                        break;
                }
            }
            else
            {
                switch(spawnMode)
                {
                    case "AllDon":
                        AllDonSpawn();
                        break;
                    case "AllKa":
                        AllKaSpawn();
                        break;
                    case "AllDonOrAllKa":
                        AllDonOrAllKaSpawn();
                        break;
                    case "TwoTwo":
                        TwoTwoSpawn();
                        break;
                    case "Free":
                        FreeSpawn();
                        break;
                }
            }
    }
    public void Perfect()
    {
        perfectCount++;
        combo++;
    }
    public void Good()
    {
        goodCount++;
        combo++;
    }
    public void Miss()
    {
        missCount++;
        combo = 0;
    }


}
