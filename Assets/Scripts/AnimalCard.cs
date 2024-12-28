using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCard : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private Button buttonComponent;

    private AnimalCardData animalData;

    private string cardName;
    private Sprite cardAnimalImage;
    private AudioClip cardAudio;

    public AnimalCardData Data { set => animalData = value; }

    public string Name { get => cardName; }
    public Sprite AnimalImage { get => cardAnimalImage; }
    public AudioClip Audio { get => cardAudio;}

    public void SetData()
    {
        cardName = animalData.name;
        cardAnimalImage = animalData.AnimalImage;
        cardAudio= animalData.Audio;

        imageComponent.color = Color.white;
        imageComponent.sprite = cardAnimalImage;

        buttonComponent.enabled = true;
    }

    public void BacklightChange(bool AnswerResult)
    {
        if (AnswerResult)
            imageComponent.color = Color.green;
        else 
            imageComponent.color = Color.red;
    }
}
