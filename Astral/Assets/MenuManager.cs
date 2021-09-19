using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject backButton;

    private void Start()
    {
        SetActiveButonOn();
    }

    public void MainToStart()
    {
        anim.SetBool("StartGame", true);
        SetActiveButtonOff();
    }

    public void StartToMain()
    {
        anim.SetBool("StartGame", false);
        SetActiveButonOn();
    }

    private void SetActiveButonOn()
    {
        startButton.SetActive(true);
        backButton.SetActive(false);
    }

    private void SetActiveButtonOff()
    {
        startButton.SetActive(false);
        backButton.SetActive(true);
    }
}
