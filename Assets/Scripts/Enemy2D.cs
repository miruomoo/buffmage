using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement to restart the scene
using System.Collections;

public class Enemy2D : MonoBehaviour
{
    public int health = 3;
    [SerializeField] private GameObject frozenEffect;

    private IEnumerator UnfreezeAfterDelay(SlimeMove slime, float delay)
    {
        yield return new WaitForSeconds(delay);
        slime.unfreeze();
    }

    private IEnumerator DeactivateFrozenEffect(GameObject frozenEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (frozenEffect != null)
        {
            frozenEffect.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
            if (health <= 0)
            {
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Iceball"))
        {
            // Check if THIS enemy has SlimeMove component
            SlimeMove slimeMove = GetComponent<SlimeMove>();
            if (slimeMove != null)
            {
                slimeMove.freeze();
                StartCoroutine(UnfreezeAfterDelay(slimeMove, 6f));
                
                // Simply activate/deactivate the referenced effect
                if (frozenEffect != null)
                {
                    frozenEffect.SetActive(true);
                    StartCoroutine(DeactivateFrozenEffect(frozenEffect, 6f));
                }
            }
            other.gameObject.SetActive(false);
        }
    }

}