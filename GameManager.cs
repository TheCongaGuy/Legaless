using UnityEngine;
public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool win = false;
    public bool dead = false;
    bool winState = false;
    bool deadState = false;

    public GameObject WinScreen;
    public GameObject LostScreen;

	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

	// Update is called once per frame
	void Update()
    {
        if (!deadState)
        {
            if (win)
            {
                if (!winState)
                {
                    Cursor.lockState = CursorLockMode.None;
                    WinScreen.SetActive(true);
                    winState = true;
                }
                Time.timeScale -= 3 * Time.deltaTime;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
            if (dead)
            {
                Cursor.lockState = CursorLockMode.None;
                LostScreen.SetActive(true);
                deadState = true;
            }
        }
    }
}
