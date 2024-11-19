using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpForce = 3f;  // ジャンプの力
    public float minJumpInterval = 1f;  // 最小ジャンプ間隔
    public float maxJumpInterval = 3f;  // 最大ジャンプ間隔

    private Rigidbody rb;  // Rigidbody（3D用）
    private float jumpTimer;  // ジャンプのタイマー

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbodyコンポーネントの取得
        SetRandomJumpInterval();  // ランダムなジャンプ間隔を設定
    }

    void Update()
    {
        // タイマーを減少させる
        jumpTimer -= Time.deltaTime;

        // タイマーが0以下になったらジャンプ
        if (jumpTimer <= 0f)
        {
            Jump();
            SetRandomJumpInterval();  // 次のジャンプ間隔をランダムに設定
        }
    }

    void Jump()
    {
        // Rigidbodyのy軸方向に力を加えてジャンプ
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void SetRandomJumpInterval()
    {
        // ランダムなジャンプ間隔を設定
        jumpTimer = Random.Range(minJumpInterval, maxJumpInterval);
    }
}
