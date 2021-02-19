using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearFadeOut : MonoBehaviour {

    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool keepWhite = false;

    public float fadeSpeed;
    float red, green, blue, alpha;
    float count = 0;
    Image fadeImage; 
    public GameObject usePanel;

    public void CanUseItem() {
        if(ItemBox.instance.HasKey()){
            StartFadeOut();
        }
    }

    void Start() {
        fadeImage = GetComponent<Image> ();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
        fadeImage.enabled = false;
    }

    public void StartFadeOut() {
        fadeImage.enabled = true;
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
        if (SceneManager.GetActiveScene().name == "2ndScene") {
            SceneManager.LoadScene("1stScene");
        }
        if(count >= 1) {
            count = 0;
            fadeIn = false;
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

    void SetAlpha() {
       fadeImage.color = new Color(red, green, blue, alpha);
    }
}
