using System.Collections;
using UnityEngine;

public class DistanceTraveledManager : MonoBehaviour
{

    [SerializeField]
    private float targetDistance = 2f;

    private void OnBecameVisible()
    {
        StartCoroutine(ManageDistanceCoroutine());
    }


    private IEnumerator ManageDistanceCoroutine()
    {
        float distanceTraveled = 0f;

        while(distanceTraveled < targetDistance)
        {
            float currentPositionY = transform.position.y;
            yield return null;
            distanceTraveled += Mathf.Abs(currentPositionY - transform.position.y);
        }

        SendMessage("OnDistanceReached", SendMessageOptions.DontRequireReceiver);
    }
}
