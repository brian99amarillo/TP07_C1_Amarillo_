using UnityEngine;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "Scriptable Objects/SoundsSO")]
public class SoundsSO : ScriptableObject
{

   [SerializeField] private float master = 0.5f;
   [SerializeField] private float background = 0.5f;
   [SerializeField] private float sfx = 1f;
   [SerializeField] private float ui = 1f;

    public float Master { get { return master; }}
    public float Background { get { return background; } }
    public float Sfx { get { return sfx; } }
    public float Ui { get { return ui; } }


}




