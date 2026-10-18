using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource ui;
    [SerializeField] private AudioClip playerShoot;
    [SerializeField] private AudioClip coinPick;
    [SerializeField] private AudioClip playerJump;
    [SerializeField] private AudioClip healt;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip playerDamage;
    [SerializeField] private AudioClip enemyDie;
    
    private void Awake()
    {
        Instance = this; 
    }
    public void PlayerShoot()=>sfx.PlayOneShot(playerShoot);
    public void PickCoin()=>sfx.PlayOneShot(coinPick);
    public void PlayerJump()=>sfx.PlayOneShot(playerJump);
    public void PlayerHealt() => sfx.PlayOneShot(healt);
    public void PlayerDamege() => sfx.PlayOneShot(playerDamage);
    public void EnemyDie() => sfx.PlayOneShot(enemyDie);
    public void GameOver() => ui.PlayOneShot(gameOver);




}
