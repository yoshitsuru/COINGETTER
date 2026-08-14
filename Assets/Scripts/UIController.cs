using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // インプットアクションの変数
    public PlayerController playerController;
    // サウンドマネージャーの変数
    public SoundManager soundManager;
    /// 現在アクティブなシーン
    public string sceneName;
    /// 次のステージ名
    private string _nextSceneName;
    // ポーズ画面
    public GameObject result;
    // ゲームオーバー画面
    public TextMeshProUGUI resultText;
    // ポーズフラグ
    public bool pauseFlg;
    // ポーズボタン
    //private GameObject _pauseButton;
    public GameObject nextButton;
    public GameObject nextText;
    void Start(){
        /// アクティブシーンを取得
        sceneName = SceneManager.GetActiveScene().name;
        //_pauseButton = GameObject.Find("PauseButton");
        pauseFlg = false;
        Time.timeScale = 1.0f;
        NextSceneNameCheck(sceneName);
    }

    public void OnClickNextButton()
    {
        SceneManager.LoadScene(_nextSceneName);
        soundManager.SoundClip4();
        InputActionIsDisable();
    }

    public void OnClickRetryButton(){
	    SceneManager.LoadScene (sceneName);
        soundManager.SoundClip4();
        InputActionIsDisable();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
        soundManager.SoundClip4();
    }

    public void OnClickEndButton()
    {
        SceneManager.LoadScene("TitleScene");
        soundManager.SoundClip4();
        InputActionIsDisable();
    }

    public void OnClickPauseButton()
    {
        if(!pauseFlg){
            result.SetActive(true);
            resultText.text = "PAUSE";
            Time.timeScale = 0.0f;
            pauseFlg =true;
        }
        else{
            result.SetActive(false);
            Time.timeScale = 1.0f;
            pauseFlg =false;
        }
        nextButton.SetActive(false);
        nextText.SetActive(false);
        soundManager.SoundClip4();
    }
    public void ActiveGameOver()
    {
        result.SetActive(true);
        resultText.text = "GAME OVER";
        //_pauseButton.SetActive(false);
        nextButton.SetActive(false);
        nextText.SetActive(false);
        Time.timeScale = 0.0f;
        soundManager.SoundClip3();
    }
    public void ActiveGameClear()
    {
        result.SetActive(true);
        resultText.text = "GAME CLEAR!!";
        //_pauseButton.SetActive(false);
        if (_nextSceneName != "")
        {
            nextButton.SetActive(true);
            nextText.SetActive(true);
        }else
        {
            nextButton.SetActive(false);
            nextText.SetActive(false);
        }
        Time.timeScale = 0.0f;
        soundManager.SoundClip2();

        // クリア状況を保存
        PlayerPrefs.SetInt(sceneName, 0);
        PlayerPrefs.Save();
    }
    public void InputActionIsDisable()
    {
        playerController._inputActions.Disable();
    }
    void NextSceneNameCheck(string sceneName)
    {
        if (sceneName == "TutorealScene")
        {
            _nextSceneName = "STAGE1Scene";
        }
        else if (sceneName == "STAGE1Scene")
        {
            _nextSceneName = "STAGE2Scene";
        }
        else if (sceneName == "STAGE2Scene")
        {
            _nextSceneName = "STAGE3Scene";
        }
        else if (sceneName == "STAGE3Scene")
        {
            _nextSceneName = "STAGE4Scene";
        }
        else if (sceneName == "STAGE4Scene")
        {
            _nextSceneName = "STAGE5Scene";
        }
        else if (sceneName == "STAGE5Scene")
        {
            _nextSceneName = "STAGE6Scene";
        }
        else if (sceneName == "STAGE6Scene")
        {
            _nextSceneName = "STAGE7Scene";
        }
        else if (sceneName == "STAGE7Scene")
        {
            _nextSceneName = "STAGE8Scene";
        }
        else if (sceneName == "STAGE8Scene")
        {
            _nextSceneName = "STAGE9Scene";
        }
        else
        {
            _nextSceneName = "";
        }
    }
}
