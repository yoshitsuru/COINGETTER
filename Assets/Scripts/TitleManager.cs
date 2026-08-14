using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // サウンドマネージャーの変数
    public SoundManager soundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void OnClickPlayButton()
    {
        int isTutorealFlg = PlayerPrefs.GetInt("TutorealScene",1);
        if (isTutorealFlg == 1)
        {
            SceneManager.LoadScene("TutorealScene");
        }
        else
        {
            SceneManager.LoadScene("StageSelectScene");
        }
        soundManager.SoundClip4();
    }
}
