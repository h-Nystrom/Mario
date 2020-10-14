using UnityEngine;

public class TargetFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothingSpeed;
    public bool follow;

    void LateUpdate () {
        if (target == null)
            return;
        if (follow)
            FollowTarget ();
        else
            CheckDistanceBeforeFollow ();
    }
    void FollowTarget () {
        Vector3 targetPosition = Vector3.Lerp (transform.position, target.position + offset, smoothingSpeed * Time.deltaTime);
        transform.position = targetPosition;

        if (Vector2.Distance (transform.position, target.position + offset) < 0.1f)
            follow = false;
    }
    void CheckDistanceBeforeFollow () {
        if (Vector2.Distance (transform.position, target.position) > 5) {
            follow = true;
        }

    }
}