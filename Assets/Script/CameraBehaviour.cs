using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ī�޶� ��ǥ�� �ٶ󺸸鼭 ���� �ٴϰ� �ϱ�
/// </summary>
public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("ī�޶� �ٶ󺸴� ������Ʈ")]
    public Transform target;

    [Tooltip("ī�޶�� ��ǥ������ �Ÿ�")]
    public Vector3 offset = new Vector3 (0, 3, -6);
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        { 
            //��ǥ���� �Ÿ��� �ΰ� ī�޶� ��ġ ����
            transform.position = target.position + offset;
            // ��ǥ�� �ٶ󺸵��� ȸ�� ����
            transform.LookAt(target);
        }
    }
}
