using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using GamePush;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<AnimalCardData> animalsDataList;
    [SerializeField] private List <AnimalCard> animalsCardsList;

    [SerializeField] private List<Sprite> backgroundsList;
    [SerializeField] private Image backgroundsImage;

    [SerializeField] private SoundController soundController;
    [SerializeField] private AudioSource animaleSound;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Image WinImage;

    private int animalsVariantsCount;
    private AnimalCard trueCard;
    private int levelCount;

    private bool canShowAdd = false;

    private void Awake()
    {
        OnPluginReady();
    }

    private void OnPluginReady()
    {
        levelCount = 1;
        animalsVariantsCount = animalsDataList.Count;
        NewAnswer();
    }

    //private void Update()
    //{
    //    if (Mathf.FloorToInt(Time.time) % 60 == 0) 
    //        canShowAdd = true;
    //}

    private void ChooseAnimalsVariant()
    {
        int rndNum;
        AnimalCardData tmpObject;

        //Если количество вариантов меньше 4 - все по новой 
        if (animalsVariantsCount < animalsCardsList.Count)
            animalsVariantsCount = animalsDataList.Count;

        for (int i = 0; i < animalsCardsList.Count; i++)
        {
            rndNum = Random.Range(0, animalsVariantsCount);
            
            animalsCardsList[i].Data = animalsDataList[rndNum];
            animalsCardsList[i].SetData();

            //Добавил выбраный элемент в конец списка, что бы избежать повторения карточек и не хранить копию списка (если бы я дропал элементы)
            tmpObject = animalsDataList[rndNum];
            animalsDataList.RemoveAt(rndNum);
            animalsDataList.Add(tmpObject);

            //Уменьшаю количество вариантов, что бы максимально избежать повторений
            animalsVariantsCount--;
        }
    }

    private void ChooseTrueCard()
    {
        int rndNum;

        rndNum = Random.Range(0, animalsCardsList.Count);

        trueCard = animalsCardsList[rndNum];
    }

    private void ChangeBackground()
    {
        if (levelCount > 16) 
            levelCount = 1;

        if (levelCount % 4 == 0)
        {
            backgroundsImage.sprite = backgroundsList[levelCount / 4 - 1];

            if(GP_Ads.IsFullscreenAvailable())
            {
                //canShowAdd = false;
                
                ShowFullscreen();
            }
        }
        levelCount++;
    }

    public void RepeatAnswer()
    {
        animaleSound.Play();
    }

    public void NewAnswer()
    {
        animaleSound.Stop();

        ChangeBackground();
        ChooseAnimalsVariant();
        ChooseTrueCard();

        animaleSound.clip = trueCard.Audio;

        animaleSound.Play();
    }

    public void CheckAnswer(AnimalCard SelectedCard)
    {
        if (SelectedCard != trueCard) SelectedCard.BacklightChange(false);
        else
        {
            SelectedCard.BacklightChange(true);
            WinImage.sprite = SelectedCard.AnimalImage;
            winPanel.SetActive(true);
        }
    }

    //SDK Реклама
    // Показать fullscreen
    public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);

    // Начался показ
    private void OnFullscreenStart() => soundController.audioPauseOnAdd();
    // Закончился показ
    private void OnFullscreenClose(bool success) => soundController.audioPauseOnAdd();
}
