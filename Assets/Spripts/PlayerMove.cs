using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 7f; // ジャンプ力
    public LayerMask groundLayer; // 地面のレイヤー

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Dキーで右に移動
        float moveInput = Input.GetKey(KeyCode.D) ? 1f : 0f;
        Vector3 move = new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }

    void Jump()
    {
        // 地面に接触している状態でSpaceキーが押されたらジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // 地面に接触したときのコリジョン処理
    private void OnCollisionEnter(Collision collision)
    {
        // 地面に接触したとき
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = true;
        }
    }

    // 地面から離れたときの処理
    private void OnCollisionExit(Collision collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = false;
        }
    }
}
