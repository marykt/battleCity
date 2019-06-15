using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;
    private float timeVal=0;
    private bool isDefended=true;
    private float defendTimeVal=3;
    // Start is called before the first frame update
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//↑→↓←
    public GameObject bullectPrefab;
    public GameObject boomPrefab;
    public GameObject defendEffectPrefab;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //defended
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal < 0) {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }

        //attack
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else {
            timeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (PlayerManager.Instance.isDefeat) {
            return;
        }

        Move(); 
       
    }
    //tank fire
    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bullectEulerAngles));
            timeVal = 0;
        }
    }

    //tank move
    private void Move() {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
        if (h != 0)
        {
            return;
        }


        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }



    }

    //tank die
    private void Die()
    {
        if (isDefended) {
            return;
        }
        PlayerManager.Instance.isDied = true;
        //boom
        Instantiate(boomPrefab, transform.position, transform.rotation);
        //die
        Destroy(gameObject);
    }
}
