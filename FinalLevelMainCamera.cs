using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelMainCamera : MonoBehaviour
{
    Transform player;

	private void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update()
    {
        if (player == null)
            return;

        if (player.position.x >= (36.65f/2f))
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 36.65f, 5 * Time.deltaTime), 0, -10);
        else if (player.position.x <= (-36.65f/2f))
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, -36.65f, 5 * Time.deltaTime), 0, -10);
        else
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0, 5 * Time.deltaTime), 0, -10);
    }
}
