﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使用可能にする
using UnityEngine.SceneManagement;

//フェードインとフェードアウトに関するスクリプト

public class FadeCanvas : MonoBehaviour {

    private bool fadeIn = false;
    private bool fadeOut = false;
    public bool keepWhite = false;

    float fadeSpeed = 0.005f;
    float red, green, blue, alpha;
    float count = 0;
    Image fadeImage;  

    void Start() {
        fadeImage = GetComponent<Image> ();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
        fadeImage.enabled = false;
    }

    public void FadeFlag() {
        fadeOut = true;
        Debug.Log("222");
    }  

    void Update () {
        if (fadeOut) {
            FadeOut();
        }
        if(fadeIn) {
            FadeIn();
        }
        if(keepWhite) {
           KeepWhite();
        }
    }

    void FadeOut() {
        fadeImage.enabled = true;
        alpha += fadeSpeed;
        SetAlpha();
        if(alpha >= 1) {
            fadeOut = false;
            keepWhite = true;
        }
    }

    void KeepWhite() {
        fadeImage.enabled = true;
        count += fadeSpeed;
        Debug.Log(alpha);
        Debug.Log(keepWhite);
        if (SceneManager.GetActiveScene().name == "MainScene") {
            ChangeScene();
        }
        if(count >= 1) {
            count = 0;
            keepWhite = false;
        }
    }

    void FadeIn() {
        Debug.Log("aa");
        fadeImage.enabled = true;
        alpha -= fadeSpeed;
        SetAlpha();
        if(alpha <= 0) {
            fadeIn = false;
            fadeImage.enabled = false;
        }
    }

    public void StartFadeIn() {
        fadeIn = true;
    }

    void SetAlpha() {
       fadeImage.color = new Color(red, green, blue, alpha);
    }

    void ChangeScene()　{
        SceneManager.LoadScene("NextScene");
    }
}