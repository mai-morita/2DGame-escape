
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使用可能にする
using UnityEngine.SceneManagement;

//フェードインとフェードアウトに関するスクリプト

public class FadeCanvas : MonoBehaviour {

    public bool fadeIn = false;
    private bool fadeOut = false;
    public bool keepWhite = false;

    public float fadeSpeed;
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
        string nextScene = null;
        if (SceneManager.GetActiveScene().name == "1stScene") {
            nextScene = "2ndScene";
        } else if (SceneManager.GetActiveScene().name == "2ndScene") {
            nextScene = "3rdScene";
        }
        if(nextScene != null) {
            SceneManager.LoadScene(nextScene);
        }
        if(count >= 1) {
            count = 0;
            keepWhite = false;
        }
    }

    void FadeIn() {
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
}
