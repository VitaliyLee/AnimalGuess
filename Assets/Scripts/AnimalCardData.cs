using UnityEngine;

[CreateAssetMenu(fileName = "New AnimalCard", menuName = "Animal card", order = 51)]
public class AnimalCardData : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private Sprite cardAnimalImage;
    [SerializeField] private AudioClip cardAudio;

    public string Name { get => cardName; }
    public Sprite AnimalImage { get => cardAnimalImage; }
    public AudioClip Audio { get => cardAudio; }
}
