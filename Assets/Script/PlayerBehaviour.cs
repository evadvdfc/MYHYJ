using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �÷��̾� �̵��� �Է� ���� ó��
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Rigidbody ������Ʈ ����
    /// </summary>
    private Rigidbody rb;

    
    [Tooltip("���� ����/���������� �󸶳� ������ �����̴���")]
    [Range(0,10)]
    public float dodgeSpeed = 5;

    
    [Tooltip("���� �ڵ����� �󸶳� ������ ������ �����̴���")]
    [Range(0, 10)]
    public float rollSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Pigidbody ������Ʈ�� �����Ѵ�
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixdUpdate�� ������ �����ӷ���Ʈ�� ȣ��Ǹ�
    /// �ð��� ����ϴ� ��ɵ��� �ֱ� ����
    /// </summary>
    private void FixedUpdate()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }
}
