using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpForce = 3f;  // �W�����v�̗�
    public float minJumpInterval = 1f;  // �ŏ��W�����v�Ԋu
    public float maxJumpInterval = 3f;  // �ő�W�����v�Ԋu

    private Rigidbody rb;  // Rigidbody�i3D�p�j
    private float jumpTimer;  // �W�����v�̃^�C�}�[

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody�R���|�[�l���g�̎擾
        SetRandomJumpInterval();  // �����_���ȃW�����v�Ԋu��ݒ�
    }

    void Update()
    {
        // �^�C�}�[������������
        jumpTimer -= Time.deltaTime;

        // �^�C�}�[��0�ȉ��ɂȂ�����W�����v
        if (jumpTimer <= 0f)
        {
            Jump();
            SetRandomJumpInterval();  // ���̃W�����v�Ԋu�������_���ɐݒ�
        }
    }

    void Jump()
    {
        // Rigidbody��y�������ɗ͂������ăW�����v
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void SetRandomJumpInterval()
    {
        // �����_���ȃW�����v�Ԋu��ݒ�
        jumpTimer = Random.Range(minJumpInterval, maxJumpInterval);
    }
}
