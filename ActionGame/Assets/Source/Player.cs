using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Range(1, 300)]
    public float mMoveSpeed = 50f;

    IEnumerator Move() {
        var movePos = Vector3.zero;

        movePos.x = Input.GetAxis("Horizontal") * mMoveSpeed;
        movePos.z = Input.GetAxis("Vertical") * mMoveSpeed;
        movePos = Vector3.ClampMagnitude(movePos, mMoveSpeed);
        var worldPos = Matrix4x4.Rotate(transform.rotation).MultiplyVector(movePos);
        transform.position += worldPos;

        yield return null;
    }

    IEnumerator Rotate() {
        var vecRotate = Vector3.zero;

        vecRotate.x = Input.GetAxis("Horizontal");
        vecRotate.z = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(vecRotate);

        yield return null;
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update() {
        
    }
}
