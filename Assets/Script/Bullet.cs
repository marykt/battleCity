using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;
    public bool isPlayerBullect=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Heart":
                other.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Wall":
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Barriar":
                Destroy(gameObject);
                other.SendMessage("PlayAudio");
                break;
            case "AirBarriar":
                Destroy(gameObject);
                break;
            //case "Bullet":
            //    Destroy(gameObject);
            //    Destroy(other.gameObject);
            //    break;
            default:
                break;
        }
    }
}
