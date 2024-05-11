using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public  float       Speed;
    private Rigidbody2D ChaseTarget;

    private bool           IsLive = true;
    private Rigidbody2D    Rigid;
    private SpriteRenderer Spriter;

    private void Awake()
    {
        Rigid   = GetComponent< Rigidbody2D    >();
        Spriter = GetComponent< SpriteRenderer >();
    }

    private void FixedUpdate()
    {
        if ( !IsLive      ) return;
        if ( !ChaseTarget ) return;
        
        Vector2 dirVec = ChaseTarget.position - Rigid.position;
        Vector2 nextVec = dirVec.normalized * ( Speed * Time.fixedDeltaTime );
        
        Rigid.MovePosition( Rigid.position + nextVec );
        // 아래 방식이 좋은 방식인지는 잘 모르겠다. 추후 수정 예정.
        Rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if ( !ChaseTarget ) return;
        
        Spriter.flipX = ChaseTarget.position.x < Rigid.position.x;
    }

    private void OnEnable()
    {
        ChaseTarget = GameManager.Instance.GlobalPlayer.GetComponent< Rigidbody2D >();
    }
}
