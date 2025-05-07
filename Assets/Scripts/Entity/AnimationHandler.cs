using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void Damage()
    {
        animator.SetBool(IsDamage, true);   
    }
    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }
    public void InvincibilityEnd()
    {
        //DontDestroyOnLoad();씬 이동되도 캐릭터 남아있음

        animator.SetBool(IsDamage, false);
    }

}