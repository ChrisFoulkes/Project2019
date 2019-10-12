using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public abstract class EventInfo
{
    public string EventDescription = "unset descrption!";

}
public class ButtonPress : EventInfo
{

    public KeyCode Key;

    public ButtonPress(KeyCode key)
    {
        Key = key;
    }

}


public class StatChange : EventInfo
{
    public Stat Stat;

    public StatChange(Stat stat) {
        Stat = stat;
    }

}


public class ItemEquipped : EventInfo
{
    public Equipment equipment;

    public ItemEquipped(Equipment item)
    {
        equipment = item;
    }

}

public class ItemUnequipped : EventInfo
{
    public Equipment equipment;

    public ItemUnequipped(Equipment item)
    {
        equipment = item;
    }

}