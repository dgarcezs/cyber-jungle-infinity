using UnityEngine;

public class StingMachineContoller : MonoBehaviour
{
     public StingController stingPrefab;

     public void FireSting()
    {
        StingController newString = Instantiate(stingPrefab, transform.position, Quaternion.identity);
    }

}
