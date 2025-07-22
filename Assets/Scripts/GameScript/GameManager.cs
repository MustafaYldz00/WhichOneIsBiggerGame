using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [Header("References")]
    [SerializeField] private GameObject _puanSurePanel;
    [SerializeField] private GameObject _ac�kDaireler;
    [SerializeField] private GameObject _koyuDaiereler;
    [SerializeField] private GameObject _textImage;
    [SerializeField] private Image _Alt;
    [SerializeField] private Image _Ust;
    [SerializeField] private TMP_Text _ustText, _altText;


    private TimerManager _timerManager;
    private void Awake()
    {
        Instance = this;
        _timerManager = Object.FindAnyObjectByType<TimerManager>();
    }

    void Start()
    {
        _ustText.text = "";
        _altText.text = "";
        SahneEkran�n�Guncelle();
    }

    private void SahneEkran�n�Guncelle()
    {
        _puanSurePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _koyuDaiereler.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _ac�kDaireler.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _textImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _Alt.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        _Ust.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla()
    {
        Debug.Log("Oyun Ba�lad�");
        _timerManager.StartTimer();
    }
  
}
