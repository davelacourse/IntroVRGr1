using System;
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

    // Attributs
    [SerializeField] private int _pointage;
    [SerializeField] private int _pointsParAnneau = 10;
    [SerializeField] private GameObject[] _tableauAnneaux = default;
    private Vector3[] _positionAnneauxDepart;
    private Quaternion[] _rotationAnneauxDepart;

    public event Action<int> EventUpdatePointage;

    private void Start()
    {
        _pointage = 0;
        _positionAnneauxDepart = new Vector3[_tableauAnneaux.Length];
        _rotationAnneauxDepart = new Quaternion[_tableauAnneaux.Length];

        for (int i = 0; i< _tableauAnneaux.Length; i++)
        {
            _positionAnneauxDepart[i] = _tableauAnneaux[i].transform.position;
            _rotationAnneauxDepart[i] = _tableauAnneaux[i].transform.rotation;
        }
    }

    public void AugmenterPointage()
    {
        _pointage += _pointsParAnneau;
        EventUpdatePointage?.Invoke(_pointage);
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        for (int i = 0; i < _tableauAnneaux.Length; i++)
        {
            _tableauAnneaux[i].transform.SetPositionAndRotation(_positionAnneauxDepart[i], _rotationAnneauxDepart[i]);
        }
        _pointage = 0;
        EventUpdatePointage?.Invoke(_pointage);
    }
}
