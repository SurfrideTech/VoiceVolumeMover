using UnityEngine;

public class MicrophoneInput : MonoBehaviour {
    AudioClip micRecord;
    string device;
    public float volume;

    void Start() {
        device = Microphone.devices[0];
        micRecord = Microphone.Start(device, true, 10, 44100);
    }

    void Update() {
        float[] samples = new float[256];
        int micPos = Microphone.GetPosition(device) - samples.Length;
        if (micPos < 0) return;
        micRecord.GetData(samples, micPos);
        float sum = 0f;
        foreach (float s in samples) sum += s * s;
        volume = Mathf.Sqrt(sum / samples.Length);
    }
}
