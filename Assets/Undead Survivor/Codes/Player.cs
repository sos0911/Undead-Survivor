//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename Player.cs                                                                                                  //////////////////////////////////////////////////////
/// comment  플레이어 클래스                                                                                               //////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    public  Vector2     InputVec;
    private Rigidbody2D Rigid;
    public  float       Speed;
    
    void Awake()
    {
        Rigid = GetComponent< Rigidbody2D >();
    }
    
    // 시작 시 호출한다.
    void Start()
    {
    }

    // 매 프레임 갱신한다.
    void Update()
    {
        InputVec.x = Input.GetAxisRaw( "Horizontal" );
        InputVec.y = Input.GetAxisRaw( "Vertical"   );
    }

    // 고정된 시간 간격으로 갱신한다.
    void FixedUpdate()
    {
        Vector2 diffPosition = InputVec.normalized * ( Speed * Time.fixedDeltaTime );
        Rigid.MovePosition( Rigid.position + diffPosition );
    }
}
