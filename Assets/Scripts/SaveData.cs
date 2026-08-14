using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // データの初期値設定
        PlayerPrefs.GetInt("TutorealScene", 1);
        PlayerPrefs.GetInt("STAGE1Scene", 1);
        PlayerPrefs.GetInt("STAGE2Scene", 1);
        PlayerPrefs.GetInt("STAGE3Scene", 1);
        PlayerPrefs.GetInt("STAGE4Scene", 1);
        PlayerPrefs.GetInt("STAGE5Scene", 1);
        PlayerPrefs.GetInt("STAGE6Scene", 1);
        PlayerPrefs.GetInt("STAGE7Scene", 1);
        PlayerPrefs.GetInt("STAGE8Scene", 1);
        PlayerPrefs.GetInt("STAGE9Scene", 1);
    }

    public void SaveClearScene(string sceneName)
    {
        PlayerPrefs.SetInt(sceneName, 0);
        PlayerPrefs.Save(); // 即時保存
    }
}
