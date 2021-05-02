using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] mPlaylist;
    public AudioSource mAudioSource;
    private int mMusicIndex = 0;

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
}
