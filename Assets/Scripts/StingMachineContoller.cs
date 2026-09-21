using UnityEngine;

public class StingMachineContoller : MonoBehaviour
{
     public StingController stingPrefab;

     public void FireSting()
     {
        StingController newSting = Instantiate(stingPrefab, transform.position, Quaternion.identity);
     }

}
