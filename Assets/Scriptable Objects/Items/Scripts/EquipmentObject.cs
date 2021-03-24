using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float attackMultiplier;
    public float defenceMultiplier;

    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
