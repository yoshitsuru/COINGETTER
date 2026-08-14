using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    /// 現在アクティブなシーン
    private string _sceneName;

    //BGM1
    private GameObject _bgm;

    //BGM2
    private GameObject _bgm2;

    // AudioSourceの変数
    private AudioSource _audioSource = null;

    // 効果音1
    public AudioClip sound01;

    // 効果音2
    public AudioClip sound02;

    // 効果音3
    public AudioClip sound03;

    // 効果音4
    public AudioClip sound04;

    // 効果音5
    public AudioClip sound05;

    // 効果音6
    public AudioClip sound06;

    public bool DontDestroyEnabled = true;

    void Start()
    {
        // アクティブシーンを取得
        _sceneName = SceneManager.GetActiveScene().name;

        if (_sceneName == "TitleScene")
        {
            _bgm2 = GameObject.Find("TitleManager");
            DontDestroyEnabled = true;
            _audioSource = _bgm2.GetComponent<AudioSource>();
        }
        else if (_sceneName == "StageSelectScene") 
        {
            _bgm = GameObject.Find("SoundManager");
            DontDestroyEnabled = false;
            _audioSource = _bgm.GetComponent<AudioSource>();
            return;
        }
        else
        {
            _bgm = GameObject.Find("SoundManager");
            DontDestroyEnabled = false;
            _audioSource = _bgm.GetComponent<AudioSource>();
        }
        if (DontDestroyEnabled)
        {
            SceneManager.MoveGameObjectToScene(_bgm2, SceneManager.GetActiveScene());
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(_bgm2);
            _audioSource.Play();
        }
        else
        {
            _bgm2 = GameObject.Find("TitleManager");
            Destroy(_bgm2);
            _audioSource.Play();
        }
    }

    public void SoundBGM()
    {
        _audioSource = _bgm2.GetComponent<AudioSource>();
        _audioSource.Stop();
        _audioSource = _bgm.GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void SoundBGM2()
    {
        _audioSource = _bgm.GetComponent<AudioSource>();
        _audioSource.Stop();
        _audioSource = _bgm2.GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void SoundClip1()
    {
        _audioSource.PlayOneShot(sound01);
    }

    public void SoundClip2()
    {
        _audioSource.PlayOneShot(sound02);
    }

    public void SoundClip3()
    {
        _audioSource.PlayOneShot(sound03);
    }

    public void SoundClip4()
    {
        _audioSource.PlayOneShot(sound04);
    }

    public void SoundClip5()
    {
        _audioSource.PlayOneShot(sound05);
    }

    public void SoundClip6()
    {
        _audioSource.PlayOneShot(sound06);
    }

}
