using UnityEngine;
using System.Collections;

public class MobileControl : MonoBehaviour {
    public float maxDistance = 1;

    public float currentRightDistance = 0;
    public float currentLeftDistance = 0;

    public Side lastUsedFoot = Side.left;

    public Vector3 _rightBeginning;
    public Vector3 _leftBeginning;

    void Update () {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                _SetupBeginning(touch);
            } else if (touch.phase == TouchPhase.Ended) {
                _SetupEnd(touch);
            }
        }
    }

    public void Fall () {
        Debug.Log("FALL!!!!" + Time.time);
    }

    private void _SetupEnd (Touch touch) {
        lastUsedFoot = lastUsedFoot == Side.right? Side.left : Side.right;
    }

    private void _SetupBeginning (Touch touch) {
        if (lastUsedFoot == Side.right) {
            _leftBeginning = touch.position;
        } else {
            _rightBeginning = touch.position;
        }
    }
}