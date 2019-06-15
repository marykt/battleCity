using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    //wall heart barriar  grass  airBarriar
    public GameObject[] MapItems;
    public GameObject[] Tanks;
    public GameObject[] Players;
    private List<Vector3> ItemPostionList = new List<Vector3>();
    private List<Vector3> ItemEnemyPostionList = new List<Vector3> { new Vector3(-16, 8, 0), new Vector3(0, 8, 0), new Vector3(16, 8, 0), };
    private void Awake()
    {
        InitMap();
    }
    private void InitMap()
    {
        //实例化家
        CreateItem(MapItems[1], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(MapItems[0], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(MapItems[0], new Vector3(-1, -8, 0), Quaternion.identity);


        for (int i = -1; i < 2; i++)
        {
            CreateItem(MapItems[0], new Vector3(i, -7, 0), Quaternion.identity);
        }
        //生成玩家
        GameObject gameobj = CreateItem(Players[0], new Vector3(-2, -8, 0), Quaternion.identity);
        gameobj.GetComponent<Born>().createPlayer = true;

        //生成敌人
        GameObject gameobj1 = CreateItem(Tanks[0], new Vector3(-16, 8, 0), Quaternion.identity);
        GameObject gameobj2 = CreateItem(Tanks[0], new Vector3(0, 8, 0), Quaternion.identity);
        GameObject gameobj3 = CreateItem(Tanks[0], new Vector3(16, 8, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemy", 4, 5);
        //实例化外围墙
        for (int i = -17; i < 18; i++)
        {
            CreateItem(MapItems[4], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -17; i < 18; i++)
        {
            CreateItem(MapItems[4], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(MapItems[4], new Vector3(17, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(MapItems[4], new Vector3(-17, i, 0), Quaternion.identity);
        }
        //create MAP
        CreateGameObjectInRange(MapItems[0], 20, -16, 8, 16, -8);
        CreateGameObjectInRange(MapItems[2], 40, -15, 7, 15, -7);
        CreateGameObjectInRange(MapItems[3], 20, -16, 8, 16, -8);
        CreateGameObjectInRange(MapItems[5], 20, -16, 8, 16, -8);
    }
    private GameObject CreateItem(GameObject gameObj,Vector3 pos,Quaternion quaternion)
    {
        GameObject item= Instantiate(gameObj, pos, quaternion);
        item.transform.SetParent(gameObject.transform);
        ItemPostionList.Add(pos);
        return item;

    }
    private void CreateGameObjectInRange(GameObject gameobj,int num,int x1, int y1, int x2, int y2)
    {
        for (int i = 0; i < num; i++) {
            CreateItem(gameobj, CreateRandomPosInRange(x1, y1, x2, y2), Quaternion.identity);
        }
    }
    //create random pos
    //map -16  16   8  -8
    //-16,8     16,-8
    private Vector3 CreateRandomPosInRange(int x1, int y1, int  x2, int y2) 
    {

        while (true)
        {
        next:
            Vector3 newPos = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0);
            for(int i=0;i< ItemPostionList.Count; i++)
            {
                if(ItemPostionList[i]== newPos)
                {
                    goto next;
                }
            }
            return newPos;
        }
    }
    private void CreateEnemy()
    {
       int num = Random.Range(0, 3);
       CreateItem(Tanks[0], ItemEnemyPostionList[num], Quaternion.identity);
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
