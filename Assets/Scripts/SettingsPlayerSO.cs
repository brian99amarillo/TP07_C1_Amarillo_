using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsPlayer", menuName = "Settings/GameSettingsPlayer")]
public class SettingsPlayerSO : ScriptableObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float life = 100f;

    public float Speed { get { return speed; } }
    public float JumpForce { get { return jumpForce; } }
    public float Life { get { return life; } }


}
