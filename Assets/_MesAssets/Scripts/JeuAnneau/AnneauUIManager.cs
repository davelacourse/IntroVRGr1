using TMPro;
using UnityEngine;

public class AnneauUIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtPointage = default;

    void Start()
    {
        AnneauGameManager.Instance.EventUpdatePointage += OnEventUpdatePointage;
    }


private void OnEventUpdatePointage(int nouveauPointage)
    {
        _txtPointage.text = "Score : " + nouveauPointage.ToString();
    }
}
