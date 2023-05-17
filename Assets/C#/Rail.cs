using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rail : MonoBehaviour
{
    [SerializeField] GameObject note;
    public float P;
    public float distanceFromStartToDestnation;
    LNGame _LNGame;
    LNGame _LNGameCode;
    private void Start()
    {
        _LNGame = FindObjectOfType<LNGame>();
        _LNGameCode = _LNGame.GetComponent<LNGame>();
    }
    public void SpawnNote()
    {
        P = _LNGameCode.noteSpeed * _LNGameCode.D;
        distanceFromStartToDestnation = 16f - P;
        Vector3 place = new( (-5f) + distanceFromStartToDestnation , 1f, 0f);
        Instantiate(note, place, Quaternion.identity, transform);
        transform.GetChild(transform.childCount - 1).GetComponent<SpriteRenderer>().sortingOrder = _LNGameCode.floor;
    }
}
