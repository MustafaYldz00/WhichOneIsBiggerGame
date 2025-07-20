using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _puanSurePanel;
    [SerializeField] private GameObject _textImage;
    [SerializeField] private Image _Alt;
    [SerializeField] private Image _Ust;
    void Start()
    {
        SahneEkran�n�Guncelle();
    }

    private void SahneEkran�n�Guncelle()
    {
        _puanSurePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _textImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _Alt.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        _Ust.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
    }
  
}
