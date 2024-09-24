
using System.Collections;
using UnityEngine;

public class LancerAnneau : MonoBehaviour
{
    private bool _marquerPoint = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bouteille"))
        {
            _marquerPoint = true;
            StopAllCoroutines(); 
            StartCoroutine(Delai());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bouteille"))
        {
            _marquerPoint = false;
        }
    }

    private IEnumerator Delai()
    {
        yield return new WaitForSeconds(2f);
        if (_marquerPoint )
        {
            AnneauGameManager.Instance.AugmenterPointage();
        }
    }
}
