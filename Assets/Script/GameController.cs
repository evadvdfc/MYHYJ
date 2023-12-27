using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic; //List
/// <summary>
/// ���� �����÷��̸� �����Ѵ�
/// </summary>
public class GameController : MonoBehaviour
{
    [Tooltip("�����ϰ��� �ϴ� Ÿ�� ����")]
    public Transform tile;

    [Tooltip("�����ϰ��� �ϴ� ��ֹ� ����")]
    public Transform obstacle;

    [Tooltip("ó ���� Ÿ���� �����Ǵ� ��")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("������ �� ���� Ÿ���� �����ž� �ϴ°�")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("��ֹ� ���� �����Ǵ� �ʹ� Ÿ�ϵ��� ����")]
    public int initNoObstacles = 4;

    /// <summary>
    /// ���� Ÿ���� �����Ǵ°�
    /// </summary>
    private Vector3 nextTileLocation;

    /// <summary>
    /// ���� Ÿ���� ȸ����?
    /// </summary>
    private Quaternion nextTileRotation;

    // Start is called before the first frame update
    void Start()
    {
        //���� ����Ʈ ����
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; i++)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }
    /// <summary>
    /// Ư�� ��ġ�� Ÿ���� �����ϰ� ���� ��ġ�� �����Ѵ�
    /// </summary>
    /// <param name="spawnObstacles">��ֹ��� �����ؾ� �ϴ°�</param>
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, Quaternion.identity);

        //���� �������� ������ ��ġ�� ȸ�� ���� �˾Ƴ���
        var nextTile = newTile.Find("Next Spawn Point");// Find�� () �ȿ� �ִ� �ָ� ã�� ���� �Ѵ�
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;


        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        // ��ֹ��� ������ �� �ִ� ��� ��ġ�� �ʿ�
        var obstacleSpawnPoints = new List<GameObject>();

        // Ÿ���� ��� �ڽ� ���� ������Ʈ�� Ȯ��
        foreach (Transform child in newTile)
        {
            // ObstacleSpawn �±װ� �ִ� ���
            if (child.CompareTag("ObstacleSpawn"))
            {
                // ��ֹ� ������ ������ ������ �߰�
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }
        // ��� �� ������ �ִ��� Ȯ��
        if (obstacleSpawnPoints.Count > 0) 
        {
            // Ȯ���� ���� �� �ϳ��� �������� ����
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count )];

            // �ش� ��ġ�� ����� �� �ֵ��� ����
            var spawnPos = spawnPoint.transform.position;
            
            // ��ֹ� ����
            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

            // Ÿ���� �θ�� ����
            newObstacle.SetParent(spawnPoint.transform);
        }

    }
}
