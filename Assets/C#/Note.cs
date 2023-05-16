using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] GameObject[] effects;

    [SerializeField] float timer = 0f;
    [SerializeField] float wantTime;
    Player _PlayerObj;
    Player _PlayerCode;
    Rail _Rail;
    float noteSpeed;
    bool clicked = false;
    float missTime = 90;
    float goodTime = 60;
    float pertectTime = 30;
    void Start()
    {
        _PlayerObj = FindObjectOfType<Player>();
        _PlayerCode = _PlayerObj.GetComponent<Player>();
        _Rail = transform.parent.GetComponent<Rail>();
        noteSpeed = _PlayerCode.noteSpeed;
        timer = 0;
        wantTime = (_Rail.distanceFromStartToDestnation) / noteSpeed;
    }
    void Update()
    {
        timer += Time.deltaTime;
        float ms = (timer - wantTime)*1000;
        if (ms > 90)
        {
            _PlayerCode.missCount++;
            _PlayerCode.combo = 0;
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
        _PlayerCode.perfectCount++;
        _PlayerCode.combo++;
        Instantiate(effects[0]);
    }
    private void Good()
    {
        _PlayerCode.goodCount++;
        _PlayerCode.combo++;
        Instantiate(effects[1]);
    }
    private void Miss()
    {
        _PlayerCode.missCount++;
        _PlayerCode.combo = 0;
        Instantiate(effects[2]);
    }
}
