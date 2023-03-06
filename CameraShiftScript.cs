using UnityEngine;

public class CameraShiftScript : MonoBehaviour
{
	public GameObject mainMenuCam;

	bool levelSelect;
	bool Options;

	private void Start()
	{
		Time.timeScale = 1;
	}

	public void Update()
	{
		if (levelSelect)
			mainMenuCam.transform.position = new Vector3(Mathf.Lerp(mainMenuCam.transform.position.x, 36.65f, 5 * Time.deltaTime), 0, -10);
		else if (Options) 
			mainMenuCam.transform.position = new Vector3(Mathf.Lerp(mainMenuCam.transform.position.x, -36.65f, 5 * Time.deltaTime), 0, -10);
		else if (mainMenuCam.transform.position != new Vector3(0, 0, -10))
			mainMenuCam.transform.position = new Vector3(Mathf.Lerp(mainMenuCam.transform.position.x, 0, 5 * Time.deltaTime), 0, -10);
	}

	public void LevelSelect()
	{
		levelSelect = true;
	}

	public void Back()
	{
		levelSelect = false;
		Options = false;
	}

	public void options()
	{
		Options = true;
	}
}
