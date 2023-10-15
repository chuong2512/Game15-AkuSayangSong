using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GunManager : MonoBehaviour
{
    [FormerlySerializedAs("guns")] public Gun[] songs;

    public int currentID;

    public TextMeshProUGUI _remainBullets;
    public TextMeshProUGUI nameGun;

    private void Start()
    {
        ShowGun(0);
        SetTextBullets();
        GameManager.OnChangeBullet += ChangeBullet;
    }

    private void ChangeBullet(int a)
    {
        SetTextBullets();
    }

    private void SetTextBullets()
    {
        _remainBullets.SetText( "Coin :" +GameDataManager.Instance.playerData.coin.ToString() + "<sprite=0>");
    }

    private void ShowGun(int id)
    {
        currentID = id;

        for (int i = 0; i < songs.Length; i++)
        {
            songs[i].SetActive(id == i);
        }
        
        SetName();
    }

    public void SetName()
    {
        nameGun.SetText(songs[currentID].Name);
    }

    public void Next()
    {
        currentID++;
        if (currentID >= songs.Length)
        {
            currentID = songs.Length - 1;
        }

        ShowGun(currentID);
        AudioManager.Instance.ClickSound();
    }

    public void Previous()
    {
        currentID--;
        if (currentID < 0)
        {
            currentID = 0;
        }

        ShowGun(currentID);
        AudioManager.Instance.ClickSound();
    }

    public void Shoot()
    {
        songs[currentID].Play();
    }
}