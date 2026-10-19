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
    [SerializeField] private AudioClip musicGameplay;
    [SerializeField] private AudioClip musicPause;
    [SerializeField] private AudioClip win;
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
    public void Win() => ui.PlayOneShot(win);

    public void ActiveMusicGameplay()
    {
        background.clip = musicGameplay;
        background.Play();
    }
    public void ActiveMusicMenuPause()
    {
        background.clip = musicPause;
        background.Play();
       
    }
    public void PauseMusicGameplay()
    {
        background.Pause();
    }

    public void StopMusicMenuPause()
    {
        background.Stop();
    }


    private void Start()
    {
        ActiveMusicGameplay();
    }
}
