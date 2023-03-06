using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWinZone : MonoBehaviour
{
	SoundManager sM;

	private void Awake()
	{
		sM = FindObjectOfType<SoundManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		sM.FreeHim();
	}
}
