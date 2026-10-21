using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class CS_Start_Hide_Video : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] GameObject videoObject;
    void Start()
    {
        videoPlayer.isLooping = true;
        videoPlayer.loopPointReached += OnloopPointReached;
    }

    private void OnloopPointReached(VideoPlayer source)
    {
        Debug.Log("Loop finished, Hide Video");
        source.Stop();
        videoObject.SetActive(false);
    }
}
