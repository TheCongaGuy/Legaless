using UnityEngine;
using UnityEngine.UI;

public class MusicSettingSetter : MonoBehaviour
{
    SoundManager sM;

    static MusicSettingSetter instance;

    // Start is called before the first frame update
    void Awake()
    {
        sM = FindObjectOfType<SoundManager>();
        
    }

    private void Start()
	{
        foreach (AudioSource s in sM.GetComponents<AudioSource>())
            if (s.clip.name == "Legaless")
                gameObject.GetComponent<Slider>().value = s.volume;
    }

	// Update is called once per frame
	void Update()
    {
        foreach (AudioSource s in sM.GetComponents<AudioSource>())
            if (s.clip.name == "Legaless")
		        if (s.volume != gameObject.GetComponent<Slider>().value)
		            sM.AdjustVolume("Music", gameObject.GetComponent<Slider>().value);
    }
}
