using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class ChangeAbilityController : CharacterAbility
{
    public enum AbilityType
    {
        Normal,
        DoubleJump,
        Climb
    }

    public CharacterJump jumpCom = null;
    public CharacterHorizontalMovement runCom = null;
    public CharacterWallClinging clingingCom = null;

    public AbilityType currentAbility = AbilityType.Normal;
    public int maxAbility = 1;
    protected override void HandleInput()
    {
        base.HandleInput();
        
        if (_inputManager.ChangeAbilityButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
        {
            ControlStart();
        }
        if (_inputManager.ChangeAbilityButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
        {
            ControlStop();
        }
    }

    public override void Reset()
    {
        base.Reset();
        currentAbility = AbilityType.Normal;
        ChangeAbility(currentAbility);
    }

    public void ControlStart()
    {
        XLogger.Log("Change Ability Key was press : currentAbility " + currentAbility);
//        if (currentAbility == AbilityType.Normal)
//        {
//            currentAbility = AbilityType.DoubleJump;
//        }else if (currentAbility == AbilityType.DoubleJump)
//        {
//            currentAbility = AbilityType.Climb;
//        }
//        else
//        {
//            currentAbility = AbilityType.Normal;
//            
//        }

        int currentValue = (int) currentAbility;
        currentAbility = (AbilityType)(currentValue >= maxAbility ? 0 : currentAbility + 1);
        XLogger.Log("Change Ability Key was press : currentAbility --- end " + currentAbility);
        ChangeAbility(currentAbility);
        Time.timeScale = 0.3f;
    }

    void ChangeAbility(AbilityType currentAbility)
    {
        jumpCom.NumberOfJumps =  currentAbility == AbilityType.DoubleJump ? 2 : 1;
        jumpCom.JumpHeight = currentAbility == AbilityType.Climb ? 2.03f : 3.03f;
        jumpCom.ResetNumberOfJumps();
        
        runCom.WalkSpeed = currentAbility == AbilityType.Normal ? StaticData.Instance.normalSpeed : StaticData.Instance.otherSpeed;
        runCom.ResetHorizontalSpeed();
        clingingCom.enabled = currentAbility == AbilityType.Climb;;
        
        int index = (int)currentAbility;
        _character.CharacterAnimator.runtimeAnimatorController = StaticData.Instance.GetLegAnim(index);
        
        
    }

    public void ControlStop()
    {
        XLogger.Log("Change Ability Key was release");

        Time.timeScale = 1;
    }

    protected override void Initialization()
    {
        base.Initialization();
        
        DelegateUtils.addListener("OnNewAbility", () =>
        {
            maxAbility++;
            
        });
    }
}
