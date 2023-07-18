using UnityEngine;
public class MoveWithCursor : MonoBehaviour
{
    [Header("Camera")]
    public Vector2 turn;
    public float sensibility = 3;
    [Header("UI")]
    public RectTransform canvas;
    public Vector2 previousTurn;
    [Range(0f, 1f)] public float smoothFactor;
    public float deltaMultiplier;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update() {
        turn.x += Input.GetAxis("Mouse X") * sensibility;
        turn.y += Input.GetAxis("Mouse Y") * sensibility;
        transform.parent.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        //transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        canvas.anchoredPosition = Vector3.Lerp(canvas.anchoredPosition, -(turn - previousTurn) * deltaMultiplier, smoothFactor * Time.deltaTime);
        //Debug.Log($"Delta: {turn - previousTurn}");
        previousTurn = new(turn.x, turn.y);
    }
}
