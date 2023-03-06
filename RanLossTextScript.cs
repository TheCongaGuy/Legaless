using UnityEngine;
using UnityEngine.UI;

public class RanLossTextScript : MonoBehaviour
{
	string[] LostText =
	{
		"Well that was... underwhelming.",
		"This is a warm up, right?",
		"You Lost...",
		"And I thought this guy was the one...",
		"Y'know, maybe you shouldn't die? Just a thought.",
		"All you had- If you just would've- I mean- UUGH!",
		"I mean... at least you tried?"
	};

	int RanText;

	private void Start()
	{
		RanText = Random.Range(0, 7);
		gameObject.GetComponent<Text>().text = LostText[RanText];
	}
}
