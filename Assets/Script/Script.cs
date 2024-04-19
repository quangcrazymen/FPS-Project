using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [Header("Status")]
    public bool mIsActivated = false;
    public bool Activated { 
        set
        {
            mIsActivated = value;
            if(mPopupAnimation != null) { mPopupAnimation.Play(); }
        }
    }
    [SerializeField]
    public Animation mPopupAnimation;
    private float mCurrentAngle = 0.0f;
    public bool isAlreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mIsActivated && !isAlreadyPlayed)
        {
            mPopupAnimation.Play("TargetPopup");
            isAlreadyPlayed = true;
        }
    }
}
