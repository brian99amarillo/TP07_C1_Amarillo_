using UnityEngine;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "Scriptable Objects/SoundsSO")]
public class SoundsSO : ScriptableObject
{

    private float master = 1f;
    private float background = 0.8f;
    private float sfx = 1f;
    private float ui = 1f;

    public float Master { get { return master; }}
    public float Background { get { return background; } }
    public float Sfx { get { return sfx; } }
    public float Ui { get { return ui; } }


}




