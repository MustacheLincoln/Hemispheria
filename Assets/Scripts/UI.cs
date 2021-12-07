using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public Faction playerFaction;
    public TMP_Text happinessText;
    public TMP_Text foodText;
    public TMP_Text timeToNextCitizenText;

    private void Update()
    {
        happinessText.text = "Happiness: " + playerFaction.happiness;

        if (playerFaction.foodChange >= 0)
            foodText.text = "Food: " + playerFaction.food + " +" + playerFaction.foodChange;
        else
            foodText.text = "Food: " + playerFaction.food + " " + playerFaction.foodChange;

        timeToNextCitizenText.text = "Time to Next Citizen: " + (int) playerFaction.timeToNextCitizen + "/" +  (int) playerFaction.timeToNextCitizenMax;
    }
}
