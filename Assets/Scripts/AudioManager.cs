using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] mPlaylist;
    public AudioSource mAudioSource;
    public AudioMixerGroup mSoundEffetMixer;

    private int mMusicIndex = 0;

    public static  AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'AudioManager dans la scène.");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mAudioSource.clip = mPlaylist[0];
        mAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mAudioSource.isPlaying)
        {            
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        mMusicIndex = (mMusicIndex + 1) % mPlaylist.Length;

        mAudioSource.clip = mPlaylist[mMusicIndex];

        mAudioSource.Play();
    }

    public AudioSource PlayClickAt (AudioClip pClip, Vector3 pPos)
    {
        GameObject lTempGO = new GameObject("TempAudio");
        lTempGO.transform.position = pPos;

        AudioSource lAudioSource = lTempGO.AddComponent<AudioSource>();
        lAudioSource.clip = pClip;
        lAudioSource.outputAudioMixerGroup = mSoundEffetMixer;

        lAudioSource.Play();
        Destroy(lTempGO, pClip.length);
        return lAudioSource;
    }
}
