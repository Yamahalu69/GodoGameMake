using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // プレイヤーのTransform
    public float smoothSpeed = 0.125f; // カメラのスムーズな追従速度
    public Vector3 offset;            // カメラのオフセット（プレイヤーとの相対位置）

    private Rigidbody rb;             // プレイヤーのRigidbody
    private bool isJumping = false;   // プレイヤーがジャンプ中かどうかを管理するフラグ

    void Start()
    {
        rb = player.GetComponent<Rigidbody>(); // プレイヤーのRigidbodyを取得
    }

    void Update()
    {
        // プレイヤーがジャンプ中かどうかを判定（y軸の速度を使う）
        isJumping = Mathf.Abs(rb.velocity.y) > 0.1f;

        // ジャンプしていない場合にのみカメラがプレイヤーを追従
        if (!isJumping)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // プレイヤーの位置にオフセットを加えた目標位置を計算
        Vector3 desiredPosition = player.position + offset;

        // Y軸の位置は固定して、X軸のみ追従させる（ジャンプしてもY軸は変わらない）
        desiredPosition.y = transform.position.y;

        // カメラがスムーズに目標位置に移動する
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // カメラの位置を更新
        transform.position = smoothedPosition;
    }
}
