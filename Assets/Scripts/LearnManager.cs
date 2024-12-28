using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnManager : MonoBehaviour
{
    [SerializeField] private List<AnimalCardData> animalsDataList;
    [SerializeField] private List<LearnCard> animalsCardsList;

    private void Start()
    {
        ChooseAnimalsVariant();
    }

    private void ChooseAnimalsVariant()
    {
        for (int i = 0; i < animalsCardsList.Count; i++)
        {
            animalsCardsList[i].Data = animalsDataList[i];
            animalsCardsList[i].SetData();
        }
    }
}
