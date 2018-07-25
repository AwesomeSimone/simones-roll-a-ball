using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    public GameObject scoreText;
    int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        //it makes the screen say "score: 0"
        scoreText.GetComponent<Text>().text = "Score: 0";
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore(5);
        }
    }

    public void IncreaseScore(int amount)
    {
        score = score + amount;
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
    }


}

   


