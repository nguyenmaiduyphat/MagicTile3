using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI accuracyText;
    public int score;
    private int combo;
    private Coroutine hideCoroutine;

    public void ScoreUpdate(int value, string accuracy)
    {
        if (accuracy == "Miss")
        {
            combo = 0;
            accuracyText.text = "MISS!";
        }
        else
        {
            combo++;
            score += value;
            accuracyText.text = accuracy;
        }

        switch(accuracyText.text)
        {
            case "Perfect":
                accuracyText.color = Color.green;
                break;
            case "Great":
                accuracyText.color = Color.cyan;
                break;
            case "Good":
                accuracyText.color = Color.yellow;
                break;
            case "MISS!":
                accuracyText.color = Color.red;
                break;
        }

        scoreText.text = score.ToString("0");
        comboText.text = combo.ToString() + "x";
        // Make sure text is visible
        accuracyText.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 1);
        comboText.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 1);

        // Restart hide timer
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(HideTextAfterDelay());
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        accuracyText.GetComponent<RectTransform>().localScale = Vector3.zero;
        comboText.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
