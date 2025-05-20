using UnityEngine;

public class Gema : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameManager.Instance.RecogerGema(this.gameObject);
        }
    }
}
