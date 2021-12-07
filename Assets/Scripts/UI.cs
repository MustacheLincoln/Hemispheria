using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public Faction playerFaction;
    public TMP_Text happinessText;
    public TMP_Text timeToNextCitizenText;

    private void Update()
    {
        happinessText.text = "Happiness: " + playerFaction.happiness;
        timeToNextCitizenText.text = "Time to Next Citizen: " + (int) playerFaction.timeToNextCitizen + "/" +  (int) playerFaction.timeToNextCitizenMax;
    }
}
