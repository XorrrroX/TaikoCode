using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LNGame : MonoBehaviour
{
    float timer = 0f;
    float coldTime;
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
    void Start()
    {
        coldTime = 1f / (FindObjectOfType<Player>().GetComponent<Player>().BPM / 60f) / 4f;
        InvokeRepeating("Spawn",0f,coldTime);
    }
    void Update()
    {
        timer += Time.deltaTime;
        Combo.text = FindObjectOfType<Player>().GetComponent<Player>().combo.ToString();
    }
    void AllDonSpawn()
    {
        if (nowTimes < FindObjectOfType<Player>().GetComponent<Player>().times)
        {
            if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                CallEndGame();
            }
        }
    }
    void AllKaSpawn()
    {
        if (nowTimes < FindObjectOfType<Player>().GetComponent<Player>().times)
        {
            if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                CallEndGame();
            }
        }
    }
    void AllDonOrAllKaSpawn()
    {
        if (nowTimes < FindObjectOfType<Player>().GetComponent<Player>().times)
        {

            if (noteCount == 0)
            {
                random = Random.Range(0, 2);
            }
            switch (random)
            {
                case 0:
                    if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                    if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                CallEndGame();
            }
        }
    }
    void TwoTwoSpawn()
    {
        if (nowTimes < FindObjectOfType<Player>().GetComponent<Player>().times)
        {
            if (noteCount == 0 || twotwo == 2)
            {
                random = Random.Range(0, 2);
                twotwo = 0;
            }
            if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                CallEndGame();
            }
        }
    }
    void FreeSpawn()
    {
        if (nowTimes < FindObjectOfType<Player>().GetComponent<Player>().times)
        {
            if (noteCount < FindObjectOfType<Player>().GetComponent<Player>().length)
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
                CallEndGame();
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
    void CallEndGame()
    {
        FindObjectOfType<Player>().GetComponent<Player>().EndGame();
        Destroy(gameObject);
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
                switch(FindObjectOfType<Player>().GetComponent<Player>().spawnMode)
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
                switch(FindObjectOfType<Player>().GetComponent<Player>().spawnMode)
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
}
