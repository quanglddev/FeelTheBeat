using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    private PlayerScore playerScore;

    private float minX = 0f, maxX = 58f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("soldier");
        playerScore = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        if (playerScore.isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.transform.position.x;

            if (temp.x < minX)
            {
                temp.x = minX;
            }

            //if (temp.x > maxX)
            //{
            //    temp.x = maxX;
            //}

            //temp.y = player.transform.position.y + 3f;
            transform.position = temp;
        }
    }
}
