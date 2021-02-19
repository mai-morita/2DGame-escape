using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuestionSet : MonoBehaviour {

    GameObject[] nextQuestionitems;
    GameObject[] finishedQuestionitems;

    void Start() {
        nextQuestionitems = GameObject.FindGameObjectsWithTag("nextQuestionitems");
        finishedQuestionitems = GameObject.FindGameObjectsWithTag("finishedQuestionitems");

        foreach (GameObject nextQuestions in nextQuestionitems) {
            nextQuestions.SetActive(false);
        }
    }

    public void ChangeQuestionPanel() {
        foreach (GameObject finishedQuestions in finishedQuestionitems) {
            finishedQuestions.SetActive(false);
        }
        foreach (GameObject nextQuestions in nextQuestionitems) {
            nextQuestions.SetActive(true);
        }
    }

    public void AllDeleteQuestion() {
        foreach (GameObject nextQuestions in nextQuestionitems) {
            nextQuestions.SetActive(false);
        }
    }
}
