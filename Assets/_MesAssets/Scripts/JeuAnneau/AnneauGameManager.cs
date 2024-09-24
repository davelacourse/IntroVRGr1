using Unity.VisualScripting;
using UnityEngine;

public class AnneauGameManager : MonoBehaviour
{
    // création singleton
    public static AnneauGameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private int _pointage;
    [SerializeField] private int _pointsParAnneau = 10;

    public void AugmenterPointage()
    {
        _pointage += _pointsParAnneau;
    }
}
