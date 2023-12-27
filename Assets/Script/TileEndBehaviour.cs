using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �÷��̾ ���� �ٴٶ�����
/// ���ο� Ÿ�� ������ �ش� Ÿ���� ���� ����Ѵ�
/// </summary>
public class TileEndBehaviour : MonoBehaviour
{
    [Tooltip("���� �ٴٶ��� �� �����ϱ� �� " + "�󸶵��� ��ٸ��°�")]
    public float destroyTime = 1.5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //���� �÷��̾�� �浹�ߴ��� üũ
        if (other.gameObject.GetComponent<PlayerBehaviour>());
        {
            //�浹�ߴٸ� ���ο� Ÿ���� �����Ѵ�
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            //���� ��ٸ� �� ���� Ÿ�� ��ü�� �����Ѵ�.
            Destroy(transform.parent.gameObject,destroyTime);
        }
    }
}
