using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (AudioSource))]
public class SampleSceneController : MonoBehaviour
{

    public static SampleSceneController instance;

    public int score = 0;
    private Text scoreText;
    public AudioSource _audioSource;

    private static float[] samples = new float[128];

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "x" + score;
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "x" + score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
         
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void Update()
    {
        GetSpectrumAudioSource();
    }
}
