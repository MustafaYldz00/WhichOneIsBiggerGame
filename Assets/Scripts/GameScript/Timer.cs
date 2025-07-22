using DG.Tweening;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _geriSayýmObje;
    [SerializeField] private TMP_Text _geriSayýmText;
    
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
            _geriSayýmText.text = say;

            yield return new WaitForSeconds(0.3f);
            _geriSayýmObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);

            yield return new WaitForSeconds(0.3f);
            _geriSayýmObje.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
            
            yield return new WaitForSeconds(0.3f);
            _geriSayýmObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.OutBack);

            yield return new WaitForSeconds(0.3f);
            _geriSayýmObje.GetComponent<RectTransform>().DOScale(0, 0.1f).SetEase(Ease.OutBack);

        }
            StopAllCoroutines();

            GameManager.Instance.OyunaBasla();
    }
   
}
