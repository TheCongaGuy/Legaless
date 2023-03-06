using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    GameObject player;
    GameManager gM;
	SoundManager sM;
	public ParticleSystem Death;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (GameObject.FindGameObjectWithTag("Game Manager") == null)
			return;
		gM = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
		sM = FindObjectOfType<SoundManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Instantiate(Death, player.transform.position, transform.rotation);
		if (player.GetComponent<PlayerController>().Left)
			player.GetComponent<Rigidbody2D>().angularVelocity = -150;
		else
			player.GetComponent<Rigidbody2D>().angularVelocity = 150;
		player.GetComponent<Rigidbody2D>().angularDrag = 5f;
		player.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x * 0.1f, 0);
		player.GetComponent<PlayerController>().SpeedClamp.x = 0.25f;
		gM.dead = true;
		sM.PitchRandom("Lava Death");
		sM.Play("Lava Death");
	}
}
