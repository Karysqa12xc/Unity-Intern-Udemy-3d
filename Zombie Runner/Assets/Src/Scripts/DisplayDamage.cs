using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        impactCanvas.enabled = false;
    }
    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplash());
    }
    public IEnumerator ShowSplash()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
