using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public float       Speed;
    public Rigidbody2D ChaseTarget;

    private bool           IsLive = true;
    private Rigidbody2D    Rigid;
    private SpriteRenderer Spriter;

    void Awake()
    {
        Rigid   = GetComponent< Rigidbody2D    >();
        Spriter = GetComponent< SpriteRenderer >();
    }

    void FixedUpdate()
    {
        if ( !IsLive ) return;
        
        Vector2 dirVec = ChaseTarget.position - Rigid.position;
        Vector2 nextVec = dirVec.normalized * ( Speed * Time.fixedDeltaTime );
        
        Rigid.MovePosition( Rigid.position + nextVec );
        // 아래 방식이 좋은 방식인지는 잘 모르겠다. 추후 수정 예정.
        Rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        Spriter.flipX = ChaseTarget.position.x < Rigid.position.x;
    }
}
