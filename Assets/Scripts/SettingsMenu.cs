using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mAudioMixer;
    public Dropdown mResolutionDropDown;
    public Slider mMusicSlider;
    public Slider mSoundSlider;

    Resolution[] mResolutions;



    public void Start()
    {

        mAudioMixer.GetFloat("Music", out float lMusicValueForSlider);
        mMusicSlider.value = lMusicValueForSlider;

        mAudioMixer.GetFloat("Sound", out float lSoundValueForSlider);
        mSoundSlider.value = lSoundValueForSlider;

        mResolutions = Screen.resolutions.Select(resol => new Resolution { width = resol.width, height = resol.height }).Distinct().ToArray();
        mResolutionDropDown.ClearOptions();

        AddDataSourceDropDown();
        DefineDefaultValueDropDrown();

        Screen.fullScreen = true;
        
    }


    public void SetMusic(float pVolume)
    {
        mAudioMixer.SetFloat("Music", pVolume);
    }

    public void SetSound(float pVolume)
    {
        mAudioMixer.SetFloat("Sound", pVolume);
    }

    public void SetFullScreen(bool pIsFullScreen)
    {
        Screen.fullScreen = pIsFullScreen;
    }

    private void AddDataSourceDropDown()
    {
        List<string> lResolution = new List<string>();

        for (int i = 0; i < mResolutions.Length; i++)
        {
            string lOption = mResolutions[i].width.ToString() + " x " + mResolutions[i].height.ToString();
            lResolution.Add(lOption);
                    }

        mResolutionDropDown.AddOptions(lResolution);
    }

    private void DefineDefaultValueDropDrown()
    {
        int lCurrentResolutionIndex = 0;

        for (int i = 0; i < mResolutions.Length; i++)
        {
            if (mResolutions[i].width == Screen.width && mResolutions[i].height == Screen.height)
            {
                lCurrentResolutionIndex = i;
            }
        }

        mResolutionDropDown.value = lCurrentResolutionIndex;
        mResolutionDropDown.RefreshShownValue();
       
    }

    public void SetResolution(int pResolutionIndex)
    {
        Resolution lResolution = mResolutions[pResolutionIndex];
        Screen.SetResolution(lResolution.width, lResolution.height, Screen.fullScreen);
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
