using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    private int currentScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }
    private void HandleScore()
    {
        scoreText.text = "" + currentScore;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "People")
        {
            currentScore++;
            HandleScore();
            Destroy(col.gameObject);

        }
    }
}

