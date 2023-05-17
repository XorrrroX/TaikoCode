using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    [SerializeField] GameObject LNModeSetting;
    [SerializeField] GameObject setting;
    public void SwitchToLNModeSetting()
    {
        Instantiate(LNModeSetting);
        Destroy(gameObject);
    }
    public void SwitchToSetting()
    {
        Instantiate(setting);
        Destroy(gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
