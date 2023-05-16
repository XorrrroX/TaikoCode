using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    //prefabs
    [SerializeField] GameObject modeSelect;
    [SerializeField] GameObject setting;
    [SerializeField] GameObject LNModeSetting;
    [SerializeField] GameObject lnGame;
    [SerializeField] GameObject result;

    //action
    private PlayerInput playerInput;
    [SerializeField] InputActionReference leftKaActionRef;
    [SerializeField] InputActionReference leftDonActionRef;
    [SerializeField] InputActionReference rightDonActionRef;
    [SerializeField] InputActionReference rightKaActionRef;


    public int BPM = 180;
    public int length = 5;
    public int times = 5;
    public float HS = 1f;
    public string spawnMode = "AllDon" ;
    public float noteSpeed;

    public int perfectCount = 0;
    public int goodCount = 0;
    public int missCount = 0;
    public int combo = 0;

    //sounds
    public AudioClip kaSound;
    public AudioClip donSound;
    private AudioSource LKSource;


    public string leftKa = "E";
    public string leftDon = "D";
    public string rightDon = "K";
    public string rightKa = "O";

    void Start()
    {
        playerInput = this.transform.GetComponent<PlayerInput>();
        LKSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    public void GoToLNMode()
    {
        Instantiate(LNModeSetting);
    }
    public void GoToSetting()
    {
        Instantiate(setting);
    }
    public void GoToModeSelect()
    {
        Instantiate(modeSelect);
    }
    public void GoToLNGame()
    {
        noteSpeed = HS / (60f / (BPM * 4f));
        Instantiate(lnGame);
        playerInput.SwitchCurrentActionMap("PlayerPlaying");
    }
    public void EndGame()
    {
        Instantiate(result);
    }
    public void RebindingLeftKa()
    {
        playerInput.SwitchCurrentActionMap("PlayerRebinding");
        FindObjectOfType<Setting>().GetComponent<Setting>().LeftKaText.text = "";
        leftKaActionRef.action.PerformInteractiveRebinding()
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(operation =>
        {
            var p = operation.action.bindings[0].effectivePath;
            FindObjectOfType<Setting>().GetComponent<Setting>().LeftKaText.text = InputControlPath.ToHumanReadableString(p,InputControlPath.HumanReadableStringOptions.OmitDevice);
            leftKa = FindObjectOfType<Setting>().GetComponent<Setting>().LeftKaText.text;
            operation.Dispose();
            playerInput.SwitchCurrentActionMap("PlayerNormal");
        })
        .Start();
    }
    public void RebindingLeftDon()
    {
        playerInput.SwitchCurrentActionMap("PlayerRebinding");
        FindObjectOfType<Setting>().GetComponent<Setting>().LeftDonText.text = "";
        leftDonActionRef.action.PerformInteractiveRebinding()
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(operation =>
        {
            var p = operation.action.bindings[0].effectivePath;
            FindObjectOfType<Setting>().GetComponent<Setting>().LeftDonText.text = InputControlPath.ToHumanReadableString(p,InputControlPath.HumanReadableStringOptions.OmitDevice);
            leftDon = FindObjectOfType<Setting>().GetComponent<Setting>().LeftDonText.text;
            operation.Dispose();
            playerInput.SwitchCurrentActionMap("PlayerNormal");
        })
        .Start();
    }
    public void RebindingRightDon()
    {
        playerInput.SwitchCurrentActionMap("PlayerRebinding");
        FindObjectOfType<Setting>().GetComponent<Setting>().RightDonText.text = "";
        rightDonActionRef.action.PerformInteractiveRebinding()
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(operation =>
        {
            var p = operation.action.bindings[0].effectivePath;
            FindObjectOfType<Setting>().GetComponent<Setting>().RightDonText.text = InputControlPath.ToHumanReadableString(p,InputControlPath.HumanReadableStringOptions.OmitDevice);
            rightDon = FindObjectOfType<Setting>().GetComponent<Setting>().RightDonText.text;
            operation.Dispose();
            playerInput.SwitchCurrentActionMap("PlayerNormal");
        })
        .Start();
    }
    public void RebindingRightKa()
    {
        playerInput.SwitchCurrentActionMap("PlayerRebinding");
        FindObjectOfType<Setting>().GetComponent<Setting>().RightKaText.text = "";
        rightKaActionRef.action.PerformInteractiveRebinding()
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(operation =>
        {
            var p = operation.action.bindings[0].effectivePath;
            FindObjectOfType<Setting>().GetComponent<Setting>().RightKaText.text = InputControlPath.ToHumanReadableString(p,InputControlPath.HumanReadableStringOptions.OmitDevice);
            rightKa = FindObjectOfType<Setting>().GetComponent<Setting>().RightKaText.text;
            operation.Dispose();
            playerInput.SwitchCurrentActionMap("PlayerNormal");
        })
        .Start();
    }
    public void ResetScore()
    {
        perfectCount = 0;
        goodCount = 0;
        missCount = 0;
        combo = 0;
    }
    public void CallLeftKa(InputAction.CallbackContext ctx)
    {
        if (FindObjectOfType<LNGame>())
        {
            if (ctx.started)
            {
                FindObjectOfType<LNGame>().GetComponent<LNGame>().LeftKa(ctx);
                LKSource.clip = kaSound;
                LKSource.Play();
            }
        }
    }
    public void CallLeftDon(InputAction.CallbackContext ctx)
    {
        if (FindObjectOfType<LNGame>())
        {
            if (ctx.started)
            {
                FindObjectOfType<LNGame>().GetComponent<LNGame>().LeftDon(ctx);
                LKSource.clip = donSound;
                LKSource.Play();
            }
        }
    }
    public void CallRightKa(InputAction.CallbackContext ctx)
    {
        if (FindObjectOfType<LNGame>())
        {
            if (ctx.started)
            {
                FindObjectOfType<LNGame>().GetComponent<LNGame>().RightKa(ctx);
                LKSource.clip = kaSound;
                LKSource.Play();
            }
        }
    }
    public void CallRightDon(InputAction.CallbackContext ctx)
    {
        if (FindObjectOfType<LNGame>())
        {
            if (ctx.started)
            {
                FindObjectOfType<LNGame>().GetComponent<LNGame>().RightDon(ctx);
                LKSource.clip = donSound;
                LKSource.Play();
            }
        }
    }
}
