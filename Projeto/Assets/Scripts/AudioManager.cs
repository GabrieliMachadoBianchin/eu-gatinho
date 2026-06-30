using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sliders (opcional, no painel de audio)")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Fontes de audio")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // mantem o volume entre as cenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SfxVolume", 1f);

        SetMusicVolume(musicVol);
        SetSfxVolume(sfxVol);
    }

    private void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.value = musicSource.volume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxSource.volume;
            sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        }
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSfxVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("SfxVolume", value);
    }
}