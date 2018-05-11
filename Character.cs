using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharCamp
{
    Player = 0,
    Monster = 1,
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BattleControl))]
[RequireComponent(typeof(MoveController))]
public abstract class Character : BaseObject, IStateChar
{
    public abstract CharCamp GetCharCamp { get; }

    #region Component

    Animator m_Animator;

    /// <summary>
    /// Animator of Character
    /// </summary>
    public Animator GetAnimator
    {
        get
        {
            if (m_Animator == null)
                m_Animator = GetComponent<Animator>();

            return m_Animator;
        }
    }

    BattleControl m_BattleControl;

    /// <summary>
    /// Control Skill and Combo System
    /// </summary>
    public BattleControl GetBattleControl
    {
        get
        {
            if (m_BattleControl == null)
                m_BattleControl = GetComponent<BattleControl>();

            return m_BattleControl;
        }
    }

    MoveController m_MoveController;

    /// <summary>
    /// MoveController of Character
    /// </summary>
    public MoveController GetMoveController
    {
        get
        {
            if (m_MoveController == null)
                m_MoveController = GetComponent<MoveController>();

            return m_MoveController;
        }
    }

    #endregion

    #region State

    [SerializeField,Header("角色狀態")]
    protected CharState CharacterState = new CharState();

    public CharState GetState { get { return CharacterState; } }

    /// <summary>
    /// State Event Changed
    /// </summary>
    public event EventHandler<CharAttrEventArgs> OnCharAttrEventArgs;

    #endregion

    public virtual void Awake()
    {
        CharacterState = new CharState(this);
    }

    public void WhenAttrChange(Attr Attr,AttrType AttrChange, float Value)
    {
        if(OnCharAttrEventArgs != null)
        {
            OnCharAttrEventArgs(this, new CharAttrEventArgs(GetState,Attr,AttrChange,Value));
        }
    }

    public override BaseObjectEnum GetBaseObjectEnum()
    {
        return BaseObjectEnum.Character;
    }

    /// <summary>
    /// 角色是否死亡
    /// </summary>
    public bool IsCharacterDead
    {
        get
        {
            return CharacterState.CharacterDead;
        }
        set
        {
            if (!CharacterState.CharacterDead)
                Deadly();
        }
    }

   
    public virtual void Deadly()
    {
        if (CharacterState.CharacterDead)
            return;

        CharacterState.GetAttr.Hp = 0;


        Debug.Log("Character Dead");
    }

    private void Start()
    {
        //Test Function
        OnCharAttrEventArgs += Character_CharAttrEventArgs;
        CharacterState.GetAttr.Hp += 10;
    }

    //Test if HpChange Value
    private void Character_CharAttrEventArgs(object sender, CharAttrEventArgs e)
    {
        Debug.LogFormat("Character:{0} Change {1} to {2}", sender, e.AttrChange, e.Value);

        if (e.AttrChange == AttrType.Hp && e.Value == 0)
        {
            Debug.Log("Character Dead");
        }
    }

}
