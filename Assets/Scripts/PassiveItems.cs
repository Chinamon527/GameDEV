using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Character character;
    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        
    }
    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        Item newItemInstance = ScriptableObject.CreateInstance<Item>();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.stats.Sum(itemToEquip.stats);
        
        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    public void UnEquip(Item itemToEquip)
    {
        
    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgerade = items.Find(id => id.Name == upgradeData.item.name);
        itemToUpgerade.UnEquip(character);
        itemToUpgerade.stats.Sum(upgradeData.ItemStats);
        itemToUpgerade.Equip(character);
    }
}
