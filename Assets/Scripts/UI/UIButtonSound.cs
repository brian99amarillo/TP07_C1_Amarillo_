using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Start() => GetComponent<Button>().onClick.AddListener(PlayClickSound);

    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}