
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使用可能にする
using UnityEngine.SceneManagement;

//フェードインとフェードアウトに関するスクリプト

public class FadeCanvas : MonoBehaviour
{

    public bool fadeIn = false;
    private bool fadeOut = false;
    private bool keepWhite = false;

    public float fadeSpeed;
    float red, green, blue, alpha;
    float count = 0;
    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
        fadeImage.enabled = false;
    }

    public void StartFadeOut()
    {
        fadeImage.enabled = true;
        fadeOut = true;
    }
    public void StartFadeIn()
    {
        fadeIn = true;
    }

    void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
        if (fadeIn)
        {
            FadeIn();
        }
        if (keepWhite)
        {
            KeepWhite();
        }
    }

    void FadeOut()
    {
        alpha += fadeSpeed;
        SetAlpha();
        if (alpha >= 1)
        {
            fadeOut = false;
            keepWhite = true;
        }
    }

    void KeepWhite()
    {
        fadeImage.enabled = true;
        count += fadeSpeed;
        if (SceneManager.GetActiveScene().name == "1stScene")
        {
            SceneManager.LoadScene("2ndScene");
        }
        if (count >= 1)
        {
            count = 0;
            keepWhite = false;
        }
    }

    void FadeIn()
    {
        fadeImage.enabled = true;
        alpha -= fadeSpeed;
        SetAlpha();
        if (alpha <= 0)
        {
            fadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    public void CanUseItem()
    {
        if (InItemBox.instance.HasKey())
        {
            StartFadeOut();
        }
    }
}
