using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // �v���C���[��Transform
    public float smoothSpeed = 0.125f; // �J�����̃X���[�Y�ȒǏ]���x
    public Vector3 offset;            // �J�����̃I�t�Z�b�g�i�v���C���[�Ƃ̑��Έʒu�j

    private Rigidbody rb;             // �v���C���[��Rigidbody
    private bool isJumping = false;   // �v���C���[���W�����v�����ǂ������Ǘ�����t���O

    void Start()
    {
        rb = player.GetComponent<Rigidbody>(); // �v���C���[��Rigidbody���擾
    }

    void Update()
    {
        // �v���C���[���W�����v�����ǂ����𔻒�iy���̑��x���g���j
        isJumping = Mathf.Abs(rb.velocity.y) > 0.1f;

        // �W�����v���Ă��Ȃ��ꍇ�ɂ̂݃J�������v���C���[��Ǐ]
        if (!isJumping)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // �v���C���[�̈ʒu�ɃI�t�Z�b�g���������ڕW�ʒu���v�Z
        Vector3 desiredPosition = player.position + offset;

        // Y���̈ʒu�͌Œ肵�āAX���̂ݒǏ]������i�W�����v���Ă�Y���͕ς��Ȃ��j
        desiredPosition.y = transform.position.y;

        // �J�������X���[�Y�ɖڕW�ʒu�Ɉړ�����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // �J�����̈ʒu���X�V
        transform.position = smoothedPosition;
    }
}
