using UnityEngine;
using UnityEngine.UI;

public class SFXSetter : MonoBehaviour
{
	SoundManager sM;

	// Start is called before the first frame update
	void Awake()
	{
		sM = FindObjectOfType<SoundManager>();
	}

	private void Start()
	{
		foreach (AudioSource s in sM.GetComponents<AudioSource>())
			if (s.clip.name == "Speed Boost")
				gameObject.GetComponent<Slider>().value = s.volume;
	}

	// Update is called once per frame
	void Update()
	{
		foreach (AudioSource s in sM.GetComponents<AudioSource>())
		{
			if (s.clip.name == "Jump")
				if (s.volume != gameObject.GetComponent<Slider>().value)
					sM.AdjustVolume("Jump Sound", gameObject.GetComponent<Slider>().value);

			if (s.clip.name == "Spike Death")
				if (s.volume != gameObject.GetComponent<Slider>().value)
					sM.AdjustVolume("Spike Death", gameObject.GetComponent<Slider>().value);

			if (s.clip.name == "Lava Death")
				if (s.volume != gameObject.GetComponent<Slider>().value)
					sM.AdjustVolume("Lava Death", gameObject.GetComponent<Slider>().value);

			if (s.clip.name == "Bounce Pad")
				if (s.volume != gameObject.GetComponent<Slider>().value)
					sM.AdjustVolume("Bounce Pad", gameObject.GetComponent<Slider>().value);

			if (s.clip.name == "Speed Boost")
				if (s.volume != gameObject.GetComponent<Slider>().value)
				{
					sM.AdjustVolume("Speed Boost", gameObject.GetComponent<Slider>().value);
					sM.AdjustVolume("Select Tick", gameObject.GetComponent<Slider>().value);
				}
		}
	}

	public void SampleSound()
	{
		sM.Play("Select Tick");
	}
}
