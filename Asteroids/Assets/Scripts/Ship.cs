using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rgbd;
    Vector2 thrustDirection;
    const float RotateDegreesPerSecond = 20;
    const float ThrustForce = 5;
    float radiusOfCollider;
    // Start is called before the first frame update
    void Start()
    {   rgbd = GetComponent<Rigidbody2D>();
        radiusOfCollider = gameObject.GetComponent<CircleCollider2D>().radius;
        thrustDirection = new Vector2(1,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   if(Input.GetAxis("Thrust") > 0)
        rgbd.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        Rotate();
    }
    void Rotate()
    {
        float rotationInput = Input.GetAxis("Rotate");
        // calculate rotation amount and apply rotation
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        if (rotationInput != 0)
        rotationAmount *= -1;
        transform.Rotate(Vector3.forward, rotationAmount);
    }
    void OnBecameInvisible()
    {   Vector2 position = transform.position;
        if(position.x > ScreenUtils.ScreenRight)
            position.x = ScreenUtils.ScreenLeft;
        else if(position.x < ScreenUtils.ScreenLeft)
            position.x = ScreenUtils.ScreenRight;
        if(position.y > ScreenUtils.ScreenTop)
            position.y = ScreenUtils.ScreenBottom;
        else if(position.y < ScreenUtils.ScreenBottom)
            position.y = ScreenUtils.ScreenTop;
        transform.position = position;
    }
}
