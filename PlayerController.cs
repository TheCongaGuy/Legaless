using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gM;
    SoundManager sM;
    public ParticleSystem Death;

    public Vector2 SpeedClamp;
    public float HardSpeedWall;
    public Vector2 Speed;

    public float Jump;

    public bool Left;

    bool jumpCount = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gM = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        sM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Math.Abs(rb.velocity.x) < SpeedClamp.x && !gM.dead)
        {
            if (Math.Abs(rb.velocity.x) == rb.velocity.x)
            {
                rb.velocity += Speed * Time.deltaTime;
                Left = false;
            }
            else
            {
                rb.velocity -= Speed * Time.deltaTime;
                Left = true;
            }
        }
        else if (!gM.dead)
            if (Math.Abs(rb.velocity.x) == rb.velocity.x)
            {
                rb.velocity -= Speed * Time.deltaTime;
                Left = false;
            }
            else
            {
                rb.velocity += Speed * Time.deltaTime;
                Left = true;
            }

        if (Input.GetMouseButton(0) && jumpCount && !gM.dead && !gM.win)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
            jumpCount = false;
            if (sM == null)
                return;
            sM.PitchRandom("Jump Sound");
            sM.Play("Jump Sound");
        }

        if (Math.Abs(rb.velocity.y) >= 45)
            if (Math.Abs(rb.velocity.y) == rb.velocity.y)
                rb.velocity = new Vector2(rb.velocity.x, 45);
            else
                rb.velocity = new Vector2(rb.velocity.x, -45);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        jumpCount = true;

        switch (collision.collider.tag)
		{
            //case "Wall":
               // rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
              //  break;
            case "Enem":
                if (!gM.win)
                {
                    gM.dead = true;
                    Destroy(gameObject);
                    Instantiate(Death, transform.position, transform.rotation);
                    sM.PitchRandom("Spike Death");
                    sM.Play("Spike Death");
                }
                break;
            case "Bounce":
                if (rb.velocity.y > 0.5)
                {
                    sM.PitchRandom("Bounce Pad");
                    sM.Play("Bounce Pad");
                }
                break;
            case "Speed Boost":
                sM.PitchRandom("Speed Boost");
                sM.Play("Speed Boost");
                break;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Speed Boost"))
		{
            if (!Left)
                rb.velocity += Speed;
            else
                rb.velocity -= Speed;

            if (Math.Abs(rb.velocity.x) >= Math.Abs(HardSpeedWall) && !gM.dead)
            {
                if (!Left)
                    rb.velocity = new Vector2(HardSpeedWall, rb.velocity.y);
                else
                    rb.velocity = new Vector2(-HardSpeedWall, rb.velocity.y);
            }
        }
	}
}
