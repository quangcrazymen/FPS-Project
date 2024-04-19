using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Status")]
    public bool isActivated = false;
    private float mCurrentAngle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if(transform.rotation.z < 90)
            {
                mCurrentAngle += 12.0f * Time.deltaTime;
                transform.Rotate(0, 0, mCurrentAngle);
            }
            else
            {
                mCurrentAngle = 90;
            }
        } 
    }
}
