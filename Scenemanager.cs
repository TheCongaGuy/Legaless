using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
	GameObject levelSelectSettings;

	private void Awake()
	{
		levelSelectSettings = GameObject.FindGameObjectWithTag("Bullshit");
	}

	public void NextLevel()
	{
		if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
			SceneManager.LoadScene(0);
		else
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Level1()
	{
		SceneManager.LoadScene("Level 1");
	}

	public void Level2()
	{
		SceneManager.LoadScene("Level 2");
	}

	public void Level3()
	{
		SceneManager.LoadScene("Level 3");
	}

	public void Level4()
	{
		SceneManager.LoadScene("Level 4");
	}

	public void Level5()
	{
		SceneManager.LoadScene("Level 5");
	}

	public void Level6()
	{
		SceneManager.LoadScene("Level 6");
	}

	public void Level7()
	{
		SceneManager.LoadScene("Level 7");
	}

	public void Level8()
	{
		SceneManager.LoadScene("Level 8");
	}

	public void Level9()
	{
		SceneManager.LoadScene("Level 9");
	}

	public void Level10()
	{
		SceneManager.LoadScene("Level 10");
	}

	public void Level11()
	{
		SceneManager.LoadScene("Level 11");
	}


}
