using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reposition : MonoBehaviour
{
    public  int        EnemyRepositionScale = 20;
    private Collider2D Collider;

    void Awake()
    {
        Collider = GetComponent< Collider2D >();
    }
    
    private void OnTriggerExit2D( Collider2D Other )
    {
        if ( !Other.CompareTag( "Area" ) ) return;

        Vector3 playerPos  = GameManager.Instance.GlobalPlayer.transform.position;
        Vector3 tileMapPos = transform.position;
        
        float diffX = Mathf.Abs( playerPos.x - tileMapPos.x );
        float diffY = Mathf.Abs( playerPos.y - tileMapPos.y );

        Vector3 playerDir = GameManager.Instance.GlobalPlayer.InputVec;

        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch ( transform.tag )
        {
            case "Ground":
                BoxCollider2D areaCollider =
                    GameManager.Instance.GlobalPlayer.GetComponentInChildren< BoxCollider2D >();
                if ( areaCollider == null ) break;
                
                // 현 시점에서 타일맵 사이즈는 정사각형이다. 
                float tileMapSizeX = areaCollider.size.x;
                float tileMapSizeY = areaCollider.size.y;
                
                if ( diffX > diffY ) transform.Translate( Vector3.right * dirX * tileMapSizeX * 2 );
                else if ( diffX < diffY ) transform.Translate( Vector3.up * dirY * tileMapSizeY * 2 );

                break;
            case "Enemy":
                if ( Collider.enabled )
                {
                    transform.Translate( playerDir * EnemyRepositionScale + new Vector3( Random.Range( -3.0f, 3.0f ), Random.Range( -3.0f, 3.0f ), 0.0f ) );
                }
                break;
        }
    }
}
