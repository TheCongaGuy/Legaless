using System;
using UnityEngine;
using UnityEngine.UI;

public class DummyPlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    SoundManager sM;

    public GameObject ImFree;

    public Vector2 SpeedClamp;
    public float HardSpeedWall;
    float SpeedWall = 25;
    public Vector2 Speed;

    public float Jump;

    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Math.Abs(rb.velocity.x) < SpeedClamp.x)
            rb.velocity += Speed * Time.deltaTime;
        else
            rb.velocity -= Speed * Time.deltaTime;

        if (Math.Abs(rb.velocity.y) > Math.Abs(SpeedWall))
        {
            if (Math.Abs(rb.velocity.y) != rb.velocity.y)
                SpeedWall = -25;
            else
                SpeedWall = 25;

            rb.velocity = new Vector2(rb.velocity.x, SpeedWall);
        }

        if (Input.GetMouseButton(0) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
            jumpCount--;
        }

        if (sM.Freed)
        {
            Destroy(gameObject);
            if (ImFree != null)
                ImFree.SetActive(true);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount++;

        switch (collision.collider.tag)
        {
            case "Wall":
                Speed *= -1;
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Speed Boost"))
        {
            rb.velocity += Speed;

            if (Speed.x != Math.Abs(Speed.x))
                HardSpeedWall = -25;
            else
                HardSpeedWall = 25;

            if (Math.Abs(rb.velocity.x) >= Math.Abs(HardSpeedWall))
                rb.velocity = new Vector2(HardSpeedWall, rb.velocity.y);
        }
    }
}
