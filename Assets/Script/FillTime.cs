using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillTime : MonoBehaviour
{
    public Image fillImage;
    public float fillSpeed = 0.2f;
    private float fillAmount = 0f;
    

  

    private void Start()
    {
      StartCoroutine(FillImageCoroutine());
    }

    private IEnumerator FillImageCoroutine()
    {

        while (true)
        {
            float fillAmount = 1.0f;
            while (fillAmount > 0f)
            {
                fillAmount -= fillSpeed * Time.deltaTime;
                fillImage.fillAmount = fillAmount;
                yield return null;
         
            }

            fillImage.fillAmount = 0f;
            yield return new WaitForSeconds(1f);
        }
    }
}
