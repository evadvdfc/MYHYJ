using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("���� ����� �� ��� �ð�")]
    public float waitTime = 2.0f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //���� ���� �÷��̾�� �浹�ߴ��� üũ
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        { 
            //�÷��̾� ����
            Destroy(collision.gameObject);
            //��� �ð��� ������ ResetGame �Լ� ȣ��
            Invoke("ResetGame", waitTime);
        }
    }

    private void Reset()
    {
        // ���� ������ �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
