using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public GameObject settings;
    public int click;
    public Text scoreText;
    public GameObject shop;
    public int updateTenges = 0;
    public Text wordTenge;
    public int shoptengeupdate = 10;

    void Start()
    {
        click = 0;
        click = PlayerPrefs.GetInt("Tenge+", click);
        shoptengeupdate=PlayerPrefs.GetInt("word+", shoptengeupdate);
    }

    void Update() 
    {
        scoreText.text = click + " tenge";
    }

    public void updateTenge()
    {
        if (click >= 10)
        {
            if (updateTenges == 0)
            {
                shoptengeupdate = 20 + shoptengeupdate;
                wordTenge.text = shoptengeupdate + " tenge Update Tenge";
                PlayerPrefs.SetInt("word+", shoptengeupdate);
                updateTenges = updateTenges + 1;
                click = click - 10;
            }
            else if (updateTenges == 1)
            {
                shoptengeupdate = 20 + shoptengeupdate;
                wordTenge.text = shoptengeupdate + " tenge Update Tenge";
                PlayerPrefs.SetInt("word+", shoptengeupdate);
                updateTenges = updateTenges + 1;
                click = click - 30;
            }
        }
    }

    public void boooster()
    {
        if (click >= 1000)
        {
            shoptengeupdate = 300 + shoptengeupdate;
            updateTenges -= updateTenges;
            click = click - 200;
        }
    }

    public void achive()
    {
        click = click - 1000000;
        updateTenges -= 1000000;
    }

    public void openSettings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void openShop()
    {
        shop.SetActive(!shop.activeSelf);
    }

    public void onCLick()
    {
        click+=updateTenges+1;
        PlayerPrefs.SetInt("Tenge+", click);
    }

    public void Reset()
    {
        wordTenge.text = "100 tenge Update Tenge";
        updateTenges = 0;
        click = 0;
        shoptengeupdate = 100;
        PlayerPrefs.DeleteAll();
    }
}
