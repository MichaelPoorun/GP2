using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float Speed = 5;

    public Rigidbody2D RB;

    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(0.1f, 0, 0);
        //transform.Translate(1f * Time.deltaTime, 0, 0);



        //This is some pretty standard movement code
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x = Speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            vel.x = -Speed;
        if (Input.GetKey(KeyCode.UpArrow))
            vel.y = Speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            vel.y = -Speed;
        RB.velocity = vel;

        //But we're missing a step.
        //How do we find the Rigidbody so we can tell it its velocity?
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      //other.gameObject.SendMessage("Unlock");
        LockBoxScript box = other.gameObject.GetComponent<LockBoxScript>();
        if (box != null) 
        {
            box.Unlock();
        }
    }

}
