using UnityEngine;

public class BoatSmoothMotion : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 2f;

    [Header("Wave Motion (X Axis)")]
    public float pitchAmount = 3f;     // شدة الميل فوق وتحت
    public float pitchSpeed = 1.2f;    // سرعة الموج

    [Header("Side Motion (Y Axis)")]
    public float yawAmount = 2f;       // ميل يمين شمال
    public float yawSpeed = 0.8f;

    [Header("Smoothness")]
    public float rotationSmooth = 3f;

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        // الحركة لقدّام
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // حساب الموج
        float pitch = Mathf.Sin(Time.time * pitchSpeed) * pitchAmount;
        float yaw = Mathf.Sin(Time.time * yawSpeed) * yawAmount;

        Quaternion targetRotation =
            startRotation * Quaternion.Euler(pitch, yaw, 0f);

        // سموث روتيشن
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotationSmooth
        );
    }
}
