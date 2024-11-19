using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;          // �v���C���[��Transform
    public float moveSpeed = 2f;      // �G�̈ړ����x
    public float detectionRange = 10f; // �v���C���[�����o����͈�

    private bool isInScreen = false;  // �G����ʓ��ɂ��邩�ǂ���

    void Update()
    {
        // �G����ʓ��ɂ��邩�`�F�b�N
        if (IsEnemyInScreen())
        {
            isInScreen = true;
        }

        // ��ʓ��ɂ���ꍇ�A�v���C���[�Ɍ������Ĉړ�
        if (isInScreen)
        {
            MoveTowardsPlayer();
        }
    }

    // �G����ʓ��ɂ��邩�ǂ����𔻒肷�郁�\�b�h
    bool IsEnemyInScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height;
    }

    // �v���C���[�Ɍ������Ĉړ����郁�\�b�h
    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // �v���C���[�̕����Ɍ������Đi��
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
