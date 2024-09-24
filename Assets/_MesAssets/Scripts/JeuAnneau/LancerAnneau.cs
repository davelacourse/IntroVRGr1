
using UnityEngine;

public class LancerAnneau : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bouteille"))
        {
            AnneauGameManager.Instance.AugmenterPointage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bouteille"))
        {
            // Enlever Points
        }
    }
}
