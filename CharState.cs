using UnityEngine;
using System.Collections;
using System;


public interface IStateChar : IState
{
    CharState GetState { get; }
}

public class CharAttrEventArgs : AttrEventArgs<CharState>
{
    public CharAttrEventArgs(CharState _Obj, Attr _Attr, AttrType _AttrChange, float _Value) : base(_Obj, _Attr, _AttrChange, _Value)
    {
    }
}

[System.Serializable]
public class CharState : BaseState
{
    public Character m_Character;

    public bool CharacterDead
    {
        get
        {
            return mAttr.Hp <= 0;
        }
    }


    public CharState() { }

    public CharState(Character _Character) : base(_Character)
    {
        m_Character = _Character;
    }

    public override void OnChangeState(AttrType ChangeAttrType, float Value)
    {
        m_Character.WhenAttrChange(GetAttr, ChangeAttrType, Value);
    }
}

