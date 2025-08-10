using System.CodeDom.Compiler;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // ===== [������ ����� ����] =====
    // �� ĳ���� ������
    public GameObject BossPrefab;
    public GameObject EnemyAPrefab;
    public GameObject EnemyBPrefab;
    public GameObject EnemyCPrefab;

    // ������ ������
    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;

    // �Ѿ� ������
    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletFollowerPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;

    // ===== [������Ʈ Ǯ �迭] =====
    // �� ������Ʈ
    GameObject[] EnemyA;
    GameObject[] EnemyB;
    GameObject[] EnemyC;
    GameObject[] Boss;

    // ������ ������Ʈ
    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    // �Ѿ� ������Ʈ
    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;
    GameObject[] bulletFollower;
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;

    GameObject[] targetPool;

    void Awake()
    {
        // �� ������Ʈ �迭 ũ�� �ʱ�ȭ
        EnemyA = new GameObject[10];
        EnemyB = new GameObject[10];
        EnemyC = new GameObject[10];
        Boss = new GameObject[1];

        itemCoin = new GameObject[10];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[100];
        bulletPlayerB = new GameObject[100];
        bulletEnemyA = new GameObject[100];
        bulletEnemyB = new GameObject[100];
        bulletFollower = new GameObject[100];
        bulletBossA = new GameObject[50];
        bulletBossB = new GameObject[1000];

        // ������Ʈ Ǯ ����
        Generate();
    }

    void Generate()
    {
        // �� ������Ʈ ����
        for (int index = 0; index < EnemyA.Length; index++)
        {
            EnemyA[index] = Instantiate(EnemyAPrefab);
            EnemyA[index].SetActive(false);
        }
        for (int index = 0; index < EnemyB.Length; index++)
        {
            EnemyB[index] = Instantiate(EnemyBPrefab);
            EnemyB[index].SetActive(false);
        }
        for (int index = 0; index < EnemyC.Length; index++)
        {
            EnemyC[index] = Instantiate(EnemyCPrefab);
            EnemyC[index].SetActive(false);
        }
        for (int index = 0; index < Boss.Length; index++)
        {
            Boss[index] = Instantiate(BossPrefab);
            Boss[index].SetActive(false);
        }

        // ������ ������Ʈ ����
        for (int index = 0; index < itemCoin.Length; index++)
        {
            itemCoin[index] = Instantiate(itemCoinPrefab);
            itemCoin[index].SetActive(false);
        }
        for (int index = 0; index < itemPower.Length; index++)
        {
            itemPower[index] = Instantiate(itemPowerPrefab);
            itemPower[index].SetActive(false);
        }
        for (int index = 0; index < itemBoom.Length; index++)
        {
            itemBoom[index] = Instantiate(itemBoomPrefab);
            itemBoom[index].SetActive(false);
        }

        // �÷��̾� �Ѿ� ����
        for (int index = 0; index < bulletPlayerA.Length; index++)
        {
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab);
            bulletPlayerA[index].SetActive(false);
        }
        for (int index = 0; index < bulletPlayerB.Length; index++)
        {
            bulletPlayerB[index] = Instantiate(bulletPlayerBPrefab);
            bulletPlayerB[index].SetActive(false);
        }
        for (int index = 0; index < bulletFollower.Length; index++)
        {
            bulletFollower[index] = Instantiate(bulletFollowerPrefab);
            bulletFollower[index].SetActive(false);
        }

        // �� �Ѿ� ����
        for (int index = 0; index < bulletEnemyA.Length; index++)
        {
            bulletEnemyA[index] = Instantiate(bulletEnemyAPrefab);
            bulletEnemyA[index].SetActive(false);
        }
        for (int index = 0; index < bulletEnemyB.Length; index++)
        {
            bulletEnemyB[index] = Instantiate(bulletEnemyBPrefab);
            bulletEnemyB[index].SetActive(false);
        }
        for (int index = 0; index < bulletBossA.Length; index++)
        {
            bulletBossA[index] = Instantiate(bulletBossAPrefab);
            bulletBossA[index].SetActive(false);
        }
        for (int index = 0; index < bulletBossB.Length; index++)
        {
            bulletBossB[index] = Instantiate(bulletBossBPrefab);
            bulletBossB[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "EnemyA":
                targetPool = EnemyA;
                break;
            case "EnemyB":
                targetPool = EnemyB;
                break;
            case "EnemyC":
                targetPool = EnemyC;
                break;
            case "Boss":
                targetPool = Boss;
                break;

            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemPower":
                targetPool = itemPower;
                break;
            case "itemBoom":
                targetPool = itemBoom;
                break;

            case "bulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "bulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "bulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "bulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "bulletFollower":
                targetPool = bulletFollower;
                break;
            case "bulletBossA":
                targetPool = bulletBossA;
                break;
            case "bulletBossB":
                targetPool = bulletBossB;
                break;
        }
        

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "EnemyA":
                targetPool = EnemyA;
                break;
            case "EnemyB":
                targetPool = EnemyB;
                break;
            case "EnemyC":
                targetPool = EnemyC;
                break;
            case "Boss":
                targetPool = Boss;
                break;

            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemPower":
                targetPool = itemPower;
                break;
            case "itemBoom":
                targetPool = itemBoom;
                break;

            case "bulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "bulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "bulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "bulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "bulletFollower":
                targetPool = bulletFollower;
                break;
            case "bulletBossA":
                targetPool = bulletBossA;
                break;
            case "bulletBossB":
                targetPool = bulletBossB;
                break;
        }
        return targetPool;
    }
}
