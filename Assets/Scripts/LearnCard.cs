using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnCard : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private Button buttonComponent;
    [SerializeField] private AudioSource animalAudioSource;

    private AnimalCardData animalData;

    private Sprite cardAnimalImage;
    private AudioClip cardAudio;

    public AnimalCardData Data { set => animalData = value; }
    public Sprite AnimalImage { get => cardAnimalImage; }
    public AudioClip Audio { get => cardAudio; }

    public void SetData()
    {
        imageComponent.sprite = animalData.AnimalImage;
        cardAudio = animalData.Audio;
    }

    public void SoundPlay()
    {
        animalAudioSource.clip = cardAudio;
        animalAudioSource.Play();
    }
}
