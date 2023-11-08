using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, PickUpObject
{
    [SerializeField] int amount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
