using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrueFalse : MonoBehaviour
{

    [SerializeField] private Image _trueImage;
    [SerializeField] private Image _falseImage;


    public void activeTrue()
    {
        StartCoroutine(trueIcon());
    }

    public void activeFalse()
    {
        StartCoroutine (falseIcon());
    }
    
    IEnumerator trueIcon()
    {
        _trueImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        _trueImage.gameObject.SetActive(false);
    }

    IEnumerator falseIcon()
    {
        _falseImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        _falseImage.gameObject.SetActive(false);
    }
}
