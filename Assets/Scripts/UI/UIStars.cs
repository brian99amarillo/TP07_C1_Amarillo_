using UnityEngine;

public class UIStars : MonoBehaviour
{
    public static UIStars Instance;

    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    private void Awake()
    {
        Instance = this;
    }

    public void StarsCounter(int counter)
    {
        star1.SetActive(counter >= 1);
        star2.SetActive(counter >= 2);
        star3.SetActive(counter >= 3);
    }
}
