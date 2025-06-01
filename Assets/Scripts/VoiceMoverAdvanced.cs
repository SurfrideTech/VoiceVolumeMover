using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class VoiceMoverAdvanced : MonoBehaviour {
    public MicrophoneInput micInput;
    public float walkThreshold = 0.05f;
    public float runThreshold = 0.1f;
    public float jumpThreshold = 0.2f;

    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 300f;

    public Slider volumeSlider;
    public Text statusText;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float vol = micInput.volume;

        if (volumeSlider != null)
            volumeSlider.value = vol;

        if (vol > jumpThreshold && Mathf.Abs(rb.linearVelocity.y) < 0.1f) {
            rb.AddForce(Vector3.up * jumpForce);
            if (statusText != null) statusText.text = "ジャンプ！";
        } else if (vol > runThreshold) {
            rb.AddForce(transform.forward * runSpeed);
            if (statusText != null) statusText.text = "走行中";
        } else if (vol > walkThreshold) {
            rb.AddForce(transform.forward * walkSpeed);
            if (statusText != null) statusText.text = "声でUnityちゃんを吹き飛ばせ！！";
        } else {
            if (statusText != null) statusText.text = "声でUnityちゃんを吹き飛ばせ！！";
        }
    }
}
