using System;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    // ステージ名
    public Text stageLeftText;
    public Text stageCenterText;
    public Text stageRightText;

    // ステージクリアテキスト
    public Text stageLeftClearText;
    public Text stageCenterClearText;
    public Text stageRightClearText;

    private int stageCount = 1;

    public SoundManager soundManager;

    void Start()
    {
        stageLeftText.text = "STAGE" + Convert.ToString(stageCount);
        stageCenterText.text = "STAGE" + Convert.ToString(stageCount + 1);
        stageRightText.text = "STAGE" + Convert.ToString(stageCount + 2);
        StageLeftClearCheck(stageLeftText.text);
        StageCenterClearCheck(stageCenterText.text);
        StageRightClearCheck(stageRightText.text);
        Time.timeScale = 1.0f;
    }
    public void OnClickTutorealButton()
    {
        SceneManager.LoadScene("TutorealScene");
        soundManager.SoundClip4();
    }
    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("TitleScene");
        soundManager.SoundClip4();
    }

    public void OnClickStageLeftButton()
    {
        SceneManager.LoadScene(stageLeftText.text + "Scene");
        soundManager.SoundClip4();
    }
    public void OnClickStageCenterButton()
    {
        SceneManager.LoadScene(stageCenterText.text + "Scene");
        soundManager.SoundClip4();
    }
    public void OnClickStageRightButton()
    {
        SceneManager.LoadScene(stageRightText.text + "Scene");
        soundManager.SoundClip4();
    }

    public void OnClickStageSelectLeftButton()
    {
        if(1 < stageCount)
        {
            stageCount = stageCount - 3;
            stageLeftText.text = "STAGE" + Convert.ToString(stageCount);
            stageCenterText.text = "STAGE" + Convert.ToString(stageCount + 1);
            stageRightText.text = "STAGE" + Convert.ToString(stageCount + 2);
            StageLeftClearCheck(stageLeftText.text);
            StageCenterClearCheck(stageCenterText.text);
            StageRightClearCheck(stageRightText.text);
            soundManager.SoundClip4();
        }
    }

    public void OnClickStageSelectRightButton()
    {
        if (4 >= stageCount)
        {
            stageCount = stageCount + 3;
            stageLeftText.text = "STAGE" + Convert.ToString(stageCount);
            stageCenterText.text = "STAGE" + Convert.ToString(stageCount + 1);
            stageRightText.text = "STAGE" + Convert.ToString(stageCount + 2);
            StageLeftClearCheck(stageLeftText.text);
            StageCenterClearCheck(stageCenterText.text);
            StageRightClearCheck(stageRightText.text);
            soundManager.SoundClip4();
        }
    }
    void StageLeftClearCheck(string stageName)
    {
        int stageClear = PlayerPrefs.GetInt(stageName + "Scene", 1);
        if (stageClear == 1)
        {
            stageLeftClearText.text = "";
        }
        else
        {
            stageLeftClearText.text = "CLEAR!!";
        }
    }
    void StageCenterClearCheck(string stageName)
    {
        int stageClear = PlayerPrefs.GetInt(stageName + "Scene", 1);
        if (stageClear == 1)
        {
            stageCenterClearText.text = "";
        }
        else
        {
            stageCenterClearText.text = "CLEAR!!";
        }
    }
    void StageRightClearCheck(string stageName)
    {
        int stageClear = PlayerPrefs.GetInt(stageName + "Scene", 1);
        if (stageClear == 1)
        {
            stageRightClearText.text = "";
        }
        else
        {
            stageRightClearText.text = "CLEAR!!";
        }
    }
}
