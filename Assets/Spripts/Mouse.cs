using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;          // プレイヤーのTransform
    public float moveSpeed = 2f;      // 敵の移動速度
    public float detectionRange = 10f; // プレイヤーを検出する範囲

    private bool isInScreen = false;  // 敵が画面内にいるかどうか

    void Update()
    {
        // 敵が画面内にいるかチェック
        if (IsEnemyInScreen())
        {
            isInScreen = true;
        }

        // 画面内にいる場合、プレイヤーに向かって移動
        if (isInScreen)
        {
            MoveTowardsPlayer();
        }
    }

    // 敵が画面内にいるかどうかを判定するメソッド
    bool IsEnemyInScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height;
    }

    // プレイヤーに向かって移動するメソッド
    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // プレイヤーの方向に向かって進む
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
