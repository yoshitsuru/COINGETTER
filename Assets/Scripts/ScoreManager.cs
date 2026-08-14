using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private int _coinCount = 0; // 得点の初期値
    private int _targetCoinCount = 30;

    public TextMeshProUGUI coinCountText;

    public UIController uIController;

    public SoundManager soundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCountText.text = "コイン数：" + _targetCoinCount + "/0";
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = "コイン数：" + _targetCoinCount + "/" + _coinCount;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            _coinCount += 1; // コイン取得で10点加算
            Destroy(other.gameObject); // コインを削除
            soundManager.SoundClip1();
            if (_targetCoinCount == _coinCount)
            {
                uIController.ActiveGameClear();
            }
        }
    }
}
