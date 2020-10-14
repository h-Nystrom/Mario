using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Transform leftBoundary, rightBoundary, bottomBoundary, topBoundary;
    public Vector3 offset;
    public float smoothingSpeed;
    GameMaster gameMaster;
    bool follow;

    void Start () {
        gameMaster = GetComponent<GameMaster> ();
    }
    void LateUpdate () {
        if (target == null)
            return;
        if (follow)
            FollowTarget ();
        else
            CheckDistanceBeforeFollow ();

        ResetPlayerOutOfBounds ();
    }
    void FollowTarget () {
        Vector3 targetPosition = Vector3.Lerp (transform.position, target.position + offset, smoothingSpeed * Time.deltaTime);
        Vector3 LevelBoundaries = new Vector3 (Mathf.Clamp (targetPosition.x, leftBoundary.position.x, rightBoundary.position.x),
            Mathf.Clamp (targetPosition.y, bottomBoundary.position.y, topBoundary.position.y), targetPosition.z);
        transform.position = LevelBoundaries;

        if (Vector2.Distance (transform.position, target.position + offset) < 0.1f)
            follow = false;
    }
    void CheckDistanceBeforeFollow () {
        if (Vector2.Distance (transform.position, target.position) > 5) {
            follow = true;
        }

    }
    void ResetPlayerOutOfBounds () {
        if (target.position.y < bottomBoundary.position.y) {
            //Call GM here
            target.GetComponent<PlayerController> ().OutOfBounds ();
        }
    }
}