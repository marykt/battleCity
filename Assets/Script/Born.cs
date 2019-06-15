using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    public GameObject[] EnemyPrefabList;
    public bool createPlayer;
    void Start()
    {
        Invoke("BornTank", 1.0f);
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BornTank()
    {
        if (createPlayer)
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        else
            Instantiate(EnemyPrefabList[(int)(Random.Range(0,2))], transform.position, Quaternion.identity);
    }
}
