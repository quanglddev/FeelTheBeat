using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishSceneController : MonoBehaviour
{

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("YourScore").GetComponent<Text>();
        scoreText.text = "Your score is " + SampleSceneController.instance.score;
        SampleSceneController.instance.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
