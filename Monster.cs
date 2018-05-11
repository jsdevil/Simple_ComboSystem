using UnityEngine;
using System.Collections;
using System;

public class Monster : Character
{
    /*AIController m_AIController;
    public AIController GetAIController
    {
        get
        {
            if (m_AIController == null)
                m_AIController = GetComponent<AIController>();

            return m_AIController;
        }
    }*/

    public override CharCamp GetCharCamp
    {
        get
        {
            return CharCamp.Monster;
        }
    }

    public override void Deadly()
    {
        base.Deadly();

        //Call GameController to calculate the score
        //LevelControl.MonsterDead(this);
    }
}
