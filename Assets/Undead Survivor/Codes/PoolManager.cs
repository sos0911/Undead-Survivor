//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename PoolManager.cs                                                                                             //////////////////////////////////////////////////////
/// comment  몬스터 풀 매니저 클래스                                                                                        //////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public  GameObject[]         Prefabs; // 풀에 사용되는 프리팹 배열
    private List< GameObject >[] Pools;   // 풀 리스트

    private void Awake()
    {
        Pools = new List< GameObject >[ Prefabs.Length ];

        for ( int index = 0; index < Pools.Length; ++index )
        {
            Pools[ index ] = new List< GameObject >();
        }
    }

    // 풀에서 사용 가능한 element를 꺼내서 반환한다.
    public GameObject Get( int index )
    {
        GameObject selectedElement = null;

        if ( Pools.Length <= index || Prefabs.Length <= index ) return selectedElement;

        foreach ( var item in Pools[ index ] )
        {
            if ( !item.activeSelf )
            {
                selectedElement = item;
                selectedElement.SetActive( true );
                break;
            }
        }

        // 비활성화된 GameObject가 없다면 새로 생성하되 Scene 내 PoolManager를 부모로 삼게 하이라키 구조를 설정한다.
        if ( !selectedElement )
        {
            selectedElement = Instantiate( Prefabs[ index ], transform );
            Pools[ index ].Add( selectedElement );
        }

        return selectedElement;
    }
    
    // 풀 리스트 사이즈를 반환한다.
    public int GetPoolsSize()
    {
        return Pools.Length;
    }
}
