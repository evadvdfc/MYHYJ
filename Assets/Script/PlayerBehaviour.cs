using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 플레이어 이동과 입력 감지 처리
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Rigidbody 컴포넌트 참조
    /// </summary>
    private Rigidbody rb;

    
    [Tooltip("공이 왼쪽/오른쪽으로 얼마나 빠르게 움직이는지")]
    [Range(0,10)]
    public float dodgeSpeed = 5;

    
    [Tooltip("공이 자동으로 얼마나 빠르게 앞으로 움직이는지")]
    [Range(0, 10)]
    public float rollSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Pigidbody 컴포넌트에 접근한다
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixdUpdate는 일정한 프레임레이트에 호출되며
    /// 시간에 기반하는 기능들을 넣기 좋다
    /// </summary>
    private void FixedUpdate()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }
}
