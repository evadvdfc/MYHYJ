using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic; //List
/// <summary>
/// 메인 게임플레이를 관리한다
/// </summary>
public class GameController : MonoBehaviour
{
    [Tooltip("생성하고자 하는 타일 참조")]
    public Transform tile;

    [Tooltip("생성하고자 하는 장애물 참조")]
    public Transform obstacle;

    [Tooltip("처 번쨰 타일이 생성되는 곳")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("사전에 몇 개의 타일이 생성돼야 하는가")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("장애물 없이 생성되는 초반 타일들의 숫자")]
    public int initNoObstacles = 4;

    /// <summary>
    /// 다음 타일이 생성되는곳
    /// </summary>
    private Vector3 nextTileLocation;

    /// <summary>
    /// 다음 타일의 회전은?
    /// </summary>
    private Quaternion nextTileRotation;

    // Start is called before the first frame update
    void Start()
    {
        //시작 포인트 설정
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; i++)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }
    /// <summary>
    /// 특정 위치에 타일을 생성하고 다음 위치를 설정한다
    /// </summary>
    /// <param name="spawnObstacles">장애물을 생성해야 하는가</param>
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, Quaternion.identity);

        //다음 아이템을 생성할 위치와 회전 값을 알아낸다
        var nextTile = newTile.Find("Next Spawn Point");// Find는 () 안에 있는 애를 찾는 것을 한다
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;


        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        // 장애물을 생성할 수 있는 모든 위치가 필요
        var obstacleSpawnPoints = new List<GameObject>();

        // 타일의 모든 자식 게임 오브젝트를 확인
        foreach (Transform child in newTile)
        {
            // ObstacleSpawn 태그가 있는 경우
            if (child.CompareTag("ObstacleSpawn"))
            {
                // 장애물 생성이 가능한 곳으로 추가
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }
        // 적어도 한 군데는 있는지 확인
        if (obstacleSpawnPoints.Count > 0) 
        {
            // 확보한 곳들 중 하나를 무작위로 선택
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count )];

            // 해당 위치를 사용할 수 있도록 저장
            var spawnPos = spawnPoint.transform.position;
            
            // 장애물 생성
            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

            // 타일을 부모로 지정
            newObstacle.SetParent(spawnPoint.transform);
        }

    }
}
