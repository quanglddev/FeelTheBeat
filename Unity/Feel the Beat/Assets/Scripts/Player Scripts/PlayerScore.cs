using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{

    public bool isAlive;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "")
        {
            //SampleSceneController.instance.IncrementScore();
        }

        if (collision.tag == "spike")
        {
            isAlive = false;

            print(SampleSceneController.instance.score);
            print("Restart");
            SceneManager.LoadScene("FinishScene");
        }
    }
}
