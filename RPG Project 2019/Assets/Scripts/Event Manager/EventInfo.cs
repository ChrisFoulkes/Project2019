﻿using System.Collections;
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
