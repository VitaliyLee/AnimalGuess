using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<Image> soundBTNImages;
    [SerializeField] private Sprite onImage;
    [SerializeField] private Sprite offImage;

    private bool audioStatus = true;

    public void OnOffAudio()
    {

        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            audioStatus = false;

            for (int i = 0; i < soundBTNImages.Count; i++)
                soundBTNImages[i].sprite = offImage;
        }

        else
        {
            AudioListener.volume = 1f;
            audioStatus = true;

            for (int i = 0;i < soundBTNImages.Count; i++)
                soundBTNImages[i].sprite = onImage;
        }
    }

    public void audioPauseOnAdd()
    {
        if (!audioStatus)
            return;

        if (AudioListener.pause)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
    }
}
