using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeScript : MonoBehaviour
{
    public GameObject applePrefab;

    public float appleDropTime = 1f;

    public float edgeDistance = 10f;

    public float changeDirectionPercentage = 0.1f;

    public float speed = 1.0f;

    void DropApple()
    {
        GameObject Apple = Instantiate<GameObject>(applePrefab);
        Apple.transform.position = transform.position;
        Invoke("DropApple", appleDropTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", appleDropTime);
    }

    // Update is called once per frame
    void Update()
    {
     
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        if (pos.x < -edgeDistance && speed < 0 || pos.x > edgeDistance && speed > 0)
        {
            speed *= -1f;
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (-edgeDistance <= pos.x && pos.x <= edgeDistance && UnityEngine.Random.value < changeDirectionPercentage)
        {
            speed *= -1f;
        }
    }
}
