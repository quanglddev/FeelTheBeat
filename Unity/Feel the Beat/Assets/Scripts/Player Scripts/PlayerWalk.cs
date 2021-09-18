using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float speed = 50f;
    public float maxVelocity = 6f;

    private float jumpForce = 600f;
    private bool isStandingOnGround = false;

    public Rigidbody2D myBody;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyboard();
        Jump();
    }

    private void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        //if (h > 0)
        //{
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            anim.SetBool("Walk", true);

            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
        //}
        //else if (h < 0)
        //{
        //    if (vel < maxVelocity)
        //    {
        //        forceX = -speed;
        //    }
        //    anim.SetBool("Walk", true);

        //    Vector3 temp = transform.localScale;
        //    temp.x = -1f;
        //    transform.localScale = temp;
        //}
        //else
        //{
            //anim.SetBool("Walk", false);
        //}

        myBody.AddForce(new Vector2(forceX, 0));
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isStandingOnGround)
            {
                myBody.AddForce(new Vector2(0, jumpForce));
                isStandingOnGround = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isStandingOnGround = true;
        }

        if (collision.tag == "coin")
        {
            SampleSceneController.instance.IncrementScore();
            collision.gameObject.SetActive(false);
        }
    }
}
