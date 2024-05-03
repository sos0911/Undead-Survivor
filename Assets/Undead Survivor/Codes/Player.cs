//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename Player.cs                                                                                                  //////////////////////////////////////////////////////
/// comment  플레이어 클래스                                                                                               //////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    public  Vector2        InputVec;
    public  float          Speed;

    private Rigidbody2D    Rigid;
    private SpriteRenderer SpRenderer;
    private Animator       PlayerAnimator;
    
    // 시작 타이밍 ( Start() 전에 호출됨 ) 에 호출된다.
    void Awake()
    {
        Rigid          = GetComponent< Rigidbody2D    >();
        SpRenderer     = GetComponent< SpriteRenderer >();
        PlayerAnimator = GetComponent< Animator       >();
    }

    // 고정된 시간 간격으로 갱신한다.
    void FixedUpdate()
    {
        Vector2 diffPosition = InputVec * ( Speed * Time.fixedDeltaTime );
        Rigid.MovePosition( Rigid.position + diffPosition );
    }
    
    // Unity Input System 이동 이벤트를 처리한다.
    void OnMove( InputValue Value )
    {
        InputVec = Value.Get< Vector2 >();
    }

    // 매 프레임 Update() 시행 후 갱신한다.
    void LateUpdate()
    {
        PlayerAnimator.SetFloat( "Speed", InputVec.magnitude );
        
        if ( Math.Abs( InputVec.x ) > 0.0f ) SpRenderer.flipX = ( InputVec.x < 0.0f );
    }
}
