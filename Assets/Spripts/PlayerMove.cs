using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float jumpForce = 7f; // �W�����v��
    public LayerMask groundLayer; // �n�ʂ̃��C���[

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
        // D�L�[�ŉE�Ɉړ�
        float moveInput = Input.GetKey(KeyCode.D) ? 1f : 0f;
        Vector3 move = new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }

    void Jump()
    {
        // �n�ʂɐڐG���Ă����Ԃ�Space�L�[�������ꂽ��W�����v
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // �n�ʂɐڐG�����Ƃ��̃R���W��������
    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂɐڐG�����Ƃ�
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = true;
        }
    }

    // �n�ʂ��痣�ꂽ�Ƃ��̏���
    private void OnCollisionExit(Collision collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = false;
        }
    }
}
