using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsEnemies", menuName = "Settings/GameSettingsEnemies")]
public class SetttingsEnemySO : ScriptableObject
{
    [SerializeField] private float maxLife = 100f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float speed = 5f;


    public float MaxLife { get { return maxLife; } }
    public float Damage { get { return damage; } }
    public float Speed { get { return speed; } }

}
