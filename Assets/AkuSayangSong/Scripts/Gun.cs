using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Gun : MonoBehaviour
{
    public int id;
    public string Name;

    public VideoPlayer _video;

    public GameObject _lock;

    private void Start()
    {
        GameManager.OnUnlockSong += OnUnlockSong;
    }

    private void OnUnlockSong(int obj)
    {
        Refresh();
    }

    public void Play()
    {
        if (GameDataManager.Instance.playerData.CheckLock(id))
        {
            PlayVideo();
        }
        else
        {
            UIManager.Instance.OpenScreen<SongModel>(ScreenType.UnlockPopup, new SongModel()
            {
                songID = id
            });
        }
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);

        Refresh();
        _video.Stop();
    }

    private void Refresh()
    {
        _lock.SetActive(!GameDataManager.Instance.playerData.CheckLock(id));
    }

    public void PlayVideo()
    {
        _video.Play();
    }
}