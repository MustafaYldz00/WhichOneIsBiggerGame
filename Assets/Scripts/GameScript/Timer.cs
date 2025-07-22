using DG.Tweening;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _geriSay�mObje;
    [SerializeField] private TMP_Text _geriSay�mText;
    
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(GariSayim());
    }
    
    IEnumerator GariSayim()
    {
        string[] sayilar = { "3", "2", "1", "GO" };

        foreach (string say in sayilar)
        {
            _geriSay�mText.text = say;

            yield return new WaitForSeconds(0.3f);
            _geriSay�mObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);

            yield return new WaitForSeconds(0.3f);
            _geriSay�mObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
            
            yield return new WaitForSeconds(0.3f);
            _geriSay�mObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.OutBack);

            yield return new WaitForSeconds(0.3f);
            _geriSay�mObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.OutBack);

        }
            StopAllCoroutines();

            GameManager.Instance.OyunaBasla();
    }
   
}
