using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator mainMenuAnim;
    [SerializeField] Animator optionAnim;
    [Header("Start Canvas")]
    [SerializeField] GameObject mainMenuStartButton;
    [SerializeField] GameObject mainMenuBackButton;
    // Could add sprite and switch gameobjects sprite instead of enable and disable...
    [Header("Option Canvas")]
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject optionBackButton = null;

    private void Start()
    {
        SetActiveButonOn();
    }
    
    public void MainToStart()
    {
        mainMenuAnim.SetBool("StartGame", true);
        SetActiveButtonOff();
    }
    public void StartToMain()
    {
        mainMenuAnim.SetBool("StartGame", false);
        SetActiveButonOn();
    }

    public void OpenOptionPanel()
    {
        optionAnim.SetBool("openOption", true);
        optionButton.SetActive(false);
    }
    public void CloseOptionPanel()
    {
        optionAnim.SetBool("openOption", false);
        optionButton.SetActive(true);
    }

    private void SetActiveButonOn()
    {
        mainMenuStartButton.SetActive(true);
        mainMenuBackButton.SetActive(false);
        optionButton.SetActive(true);
    }

    private void SetActiveButtonOff()
    {
        mainMenuStartButton.SetActive(false);
        mainMenuBackButton.SetActive(true);
    }

    
}
