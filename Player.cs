using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player instance;

    public override CharCamp GetCharCamp
    {
        get
        {
            return CharCamp.Player;
        }
    }

    public override void Awake()
    {
        base.Awake();

        instance = this;
    }
}
