using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TutorealManager : MonoBehaviour
{
    public UIController Controller;

    public SoundManager soundManager;

    // ƒpƒlƒ‹–¼
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public GameObject resultCanvas;

    public GameObject nextButton;
    public GameObject nextText;

    private bool _isTutorealPanelFlg = false;

    void Start()
    {
        panel1.SetActive(true);
        Time.timeScale = 0.0f;

    }
    void Update()
    {
        if (_isTutorealPanelFlg)
        {
            Time.timeScale = 1.0f;
        } else
        {
            Time.timeScale = 0.0f;
        }
        if (resultCanvas.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
    }
    public void OnClickTutorealpanelLeftButton()
    {
        if (panel2.activeInHierarchy)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
        }
        else if (panel3.activeInHierarchy) 
        {
            panel2.SetActive(true);
            panel3.SetActive(false);
        }
        else if (panel4.activeInHierarchy)
        {
            panel3.SetActive(true);
            panel4.SetActive(false);
        }
        soundManager.SoundClip4();
    }

    public void OnClickTutorealpanelRightButton()
    {
        if (panel1.activeInHierarchy)
        {
            panel2.SetActive(true);
            panel1.SetActive(false);
        }
        else if (panel2.activeInHierarchy)
        {
            panel3.SetActive(true);
            panel2.SetActive(false);
        }
        else if (panel3.activeInHierarchy)
        {
            panel4.SetActive(true);
            panel3.SetActive(false);
        }
        soundManager.SoundClip4();
    }
    public void OnClickTutorealpanelPlayButton()
    {
        panel3.SetActive(false);
        //panel4.SetActive(false);
        _isTutorealPanelFlg = true;
        soundManager.SoundClip4();
    }

    public void OnClickTutorealPorseButton()
    {
        if (!Controller.pauseFlg)
        {
            Controller.result.SetActive(true);
            Controller.resultText.text = "PAUSE";
            _isTutorealPanelFlg = true;
            Controller.pauseFlg = true;
        }
        else
        {
            Controller.result.SetActive(false);
            _isTutorealPanelFlg = true;
            Controller.pauseFlg = false;
        }
        nextButton.SetActive(false);
        nextText.SetActive(false);
        soundManager.SoundClip4();
    }
}
