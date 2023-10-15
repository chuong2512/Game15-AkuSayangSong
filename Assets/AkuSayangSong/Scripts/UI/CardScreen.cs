using System;
using ABCBoard.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardScreen : BaseScreenWithModel<SongModel>
{
    private int _bookID;

    [SerializeField] private Image _name;
    [SerializeField] private Button _buttonPlay;

    void Start()
    {
        _buttonPlay?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        AudioManager.Instance.ClickSound();
        AudioManager.Instance.PlaySong(_bookID);
    }

    public override void BindData(SongModel model)
    {
        _bookID = model.songID;
        SetImage();
    }

    private void SetImage()
    {
        var songSo = GameDataManager.Instance.cardSo;
        _name.sprite = songSo.GetBookWithID(_bookID).icon;
    }

    public override ScreenType GetID() => ScreenType.BookScreen;
}

public class SongModel
{
    public int songID;
}