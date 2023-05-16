using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rail : MonoBehaviour
{
    [SerializeField] GameObject note;
    public float P;
    public float distanceFromStartToDestnation;
    public void SpawnNote()
    {
        P = FindObjectOfType<Player>().GetComponent<Player>().noteSpeed * FindObjectOfType<LNGame>().GetComponent<LNGame>().D;
        distanceFromStartToDestnation = 16f - P;
        Vector3 place = new( (-5f) + distanceFromStartToDestnation , 1f, 0f);
        Instantiate(note, place, Quaternion.identity, transform);
        transform.GetChild(transform.childCount - 1).GetComponent<SpriteRenderer>().sortingOrder = FindObjectOfType<LNGame>().GetComponent<LNGame>().floor;
    }
}
