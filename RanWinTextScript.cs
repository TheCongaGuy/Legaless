using UnityEngine;
using UnityEngine.UI;

public class RanWinTextScript : MonoBehaviour
{
	string[] winText =
	{
		"Hooray! You made it to that green thing!",
		"Woo!... What did you do again?",
		"You Won!",
		"That was pretty cool, ngl.",
		"If you could go even faster, that'd be pretty cool",
		"A winner is you!",
		"Error: No Loser Found!"
	};

	int RanText;

	private void Start()
	{
		RanText = Random.Range(0, 7);
		gameObject.GetComponent<Text>().text = winText[RanText];
	}
}
