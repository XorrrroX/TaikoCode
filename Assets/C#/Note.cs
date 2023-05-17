using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] GameObject[] effects;

    [SerializeField] float timer = 0f;
    [SerializeField] float wantTime;
    LNGame _LNGame;
    LNGame _LNGameCode;
    Rail _Rail;
    private float noteSpeed;
    private bool clicked = false;
    private float missTime = 90;
    private float goodTime = 60;
    private float pertectTime = 30;
    void Start()
    {
        _LNGame = FindObjectOfType<LNGame>();
        _LNGameCode = _LNGame.GetComponent<LNGame>();
        _Rail = transform.parent.GetComponent<Rail>();
        noteSpeed = _LNGameCode.noteSpeed;
        timer = 0;
        wantTime = (_Rail.distanceFromStartToDestnation) / noteSpeed;
    }
    void Update()
    {
        timer += Time.deltaTime;
        float msAfterWantTime = (timer - wantTime)*1000;
        if (msAfterWantTime > 90)
        {
            _LNGameCode.Miss();
            Destroy(gameObject);
        }
        Vector3 v3 = new Vector3(-1*noteSpeed*Time.deltaTime, 0f);
        transform.Translate(v3);
    }
    public void Click()
    {
        float msAfterWantTime = (timer - wantTime)*1000;
        if(clicked == true)
        {
            transform.GetChild(1).GetComponent<Note>().Click();
        }
        if (InTheRangeOf(msAfterWantTime, missTime))
        {
            DetermineNote(msAfterWantTime);
            Destroy(gameObject);
        }

    }
    private bool InTheRangeOf(float msAfterWantTime , float time)
    {
        if (-1 * time <= msAfterWantTime && msAfterWantTime <= time)
            return true;
        else
            return false;
    }
    private void DetermineNote(float msAfterWantTime)
    {
        if (InTheRangeOf(msAfterWantTime, pertectTime))
            Perfect();
        else if (InTheRangeOf(msAfterWantTime, goodTime))
            Good();
        else
            Miss();
    }
    private void Perfect()
    {
        _LNGameCode.Perfect();
        Instantiate(effects[0]);
    }
    private void Good()
    {
        _LNGameCode.Good();
        Instantiate(effects[1]);
    }
    private void Miss()
    {
        _LNGameCode.Miss();
        Instantiate(effects[2]);
    }
}
