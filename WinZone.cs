using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
	GameManager gM;

	private void Start()
	{
		gM = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gM.win = true;
	}
}
