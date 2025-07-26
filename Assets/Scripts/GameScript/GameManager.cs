using DG.Tweening;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private GameObject _puanSurePanel;
    [SerializeField] private GameObject _acýkDaireler;
    [SerializeField] private GameObject _koyuDaiereler;
    [SerializeField] private GameObject _textImage;
    [SerializeField] private GameObject _textImageBuyukSayi;
    [SerializeField] private Image _Alt;
    [SerializeField] private Image _Ust;
    [SerializeField] private TMP_Text _ustText, _altText;
    

    public int _kacincioyun {  get;  set; }
    public int _oyunSayac {  get; private set; }
    private int _altDeger, _ustDeger;
    private int _buyukDeger;
    private int _butonDegeri;
    public int _dogruSayisi {  get; private set; } 
    public int _yanlisSayisi { get; private set; }

    private TimerManager _timerManager;
    private DaireManager _daireManager;
    private TrueFalse _trueFalse;
    private void Awake()
    {
        Instance = this;
        _trueFalse = Object.FindAnyObjectByType<TrueFalse>();
        _timerManager = Object.FindAnyObjectByType<TimerManager>();
        _daireManager = Object.FindAnyObjectByType<DaireManager>();
    }

    void Start()
    {
        _kacincioyun = 0;
        _oyunSayac = 0;
        _dogruSayisi = 0;
        _ustText.text = "";
        _altText.text = "";
        SahneEkranýnýGuncelle();
    }

    private void SahneEkranýnýGuncelle()
    {
        _puanSurePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _koyuDaiereler.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _acýkDaireler.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _textImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _Alt.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        _Ust.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        //OyunaBasla();
    }

    public void OyunaBasla()
    {
        _textImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        _textImageBuyukSayi.GetComponent<CanvasGroup>().DOFade(1, 1f);
        Debug.Log("Oyun Baþladý");
        _timerManager.StartTimer();
        KacinciOyun();
    }


    private void KacinciOyun()
    {
        if (_oyunSayac < 5)
        {
            _kacincioyun = 1;
        }
        else if (_oyunSayac >= 5 && _oyunSayac < 10)
        {
            _kacincioyun = 2;
        }
        else if (_oyunSayac >= 10 && _oyunSayac < 15)
        {
            _kacincioyun = 3;
        }
        else if (_oyunSayac >= 15 && _oyunSayac < 20)
        {
            _kacincioyun = 4;
        }
        else if (_oyunSayac >= 20 && _oyunSayac < 25)
        {
            _kacincioyun = 5;
        }
        else if (_oyunSayac >= 25 && _oyunSayac < 30)
        {
            _kacincioyun = 6;
        }
        else if (_oyunSayac >= 30)
        {
            _kacincioyun = Random.Range(2, 7);
        }
        

        switch (_kacincioyun)
        {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                ikinciFonksiyon();
                break;
            case 3:
                ucuncuFonksiyon();
                break;
            case 4:
                dorduncuFonksiyon();
                break;
            case 5:
                besinciFonksiyon();
                break;
            case 6:
                altinciFonksiyon();
                break;
           
        }
    }


    private void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(0, 50);

        if (rastgeleDeger <= 25)
        {
            _ustDeger = Random.Range(2, 150);
            _altDeger = _ustDeger + Random.Range(1, 60);
        }
        else
        {
            _ustDeger = Random.Range(2, 150);
            _altDeger = Mathf.Abs(_ustDeger - Random.Range(1, 60));
        }

        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        _ustText.text = _ustDeger.ToString();
        _altText.text = _altDeger.ToString();

    }

    private void ikinciFonksiyon()
    {
        int sayi1 = Random.Range(15, 30);
        int sayi2 = Random.Range(15, 30);
        int sayi3 = Random.Range(15, 30);
        int sayi4 = Random.Range(15, 30);
        _ustDeger = sayi1 + sayi2;
        _altDeger = sayi3 + sayi4;
        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            ikinciFonksiyon();
            return;
        }

        _ustText.text = (sayi1 + " + " + sayi2).ToString();
        _altText.text = (sayi3 + " + " + sayi4).ToString();


    }

    private void ucuncuFonksiyon()
    {
        int sayi1 = Random.Range(20, 40);
        int sayi2 = Random.Range(3, 20);
        int sayi3 = Random.Range(20, 40);
        int sayi4 = Random.Range(3, 20);

        _ustDeger = Mathf.Abs(sayi1 - sayi2);
        _altDeger = Mathf.Abs(sayi3 - sayi4);

        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            ucuncuFonksiyon();
            return;
        }
        _ustText.text = (sayi1 + " - " + sayi2).ToString();
        _altText.text = (sayi3 + " - " + sayi4).ToString();

    }
    private void dorduncuFonksiyon()
    {
        int sayi1 = Random.Range(1, 10);
        int sayi2 = Random.Range(1, 10);
        int sayi3 = Random.Range(1, 10);
        int sayi4 = Random.Range(1, 10);

        _ustDeger = Mathf.Abs(sayi1 * sayi2);
        _altDeger = Mathf.Abs(sayi3 * sayi4);

        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            dorduncuFonksiyon();
            return;
        }
        _ustText.text = (sayi1 + " x " + sayi2).ToString();
        _altText.text = (sayi3 + " x " + sayi4).ToString();

    }

    private void besinciFonksiyon()
    {
        int sayi1 = Random.Range(10, 20);
        int sayi2 = sayi1 * Random.Range(2, 8);
        int sayi3 = Random.Range(10, 20);
        int sayi4 = sayi3 * Random.Range(2, 8);

        _ustDeger = Mathf.CeilToInt(sayi2 / sayi1);
        _altDeger = Mathf.CeilToInt(sayi4 / sayi3);



        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            besinciFonksiyon();
            return;
        }
        _ustText.text = (sayi2 + " / " + sayi1).ToString();
        _altText.text = (sayi4 + " / " + sayi3).ToString();
    }

    private void altinciFonksiyon()
    {
        int sayi1 = Random.Range(5, 10);
        int sayi2 = sayi1 * Random.Range(2, 8);
        int sayi3 = sayi1 * Random.Range(2, 8);
        int sayi4 = Random.Range(5, 10);
        int sayi5 = sayi4 * Random.Range(2, 8);
        int sayi6 = sayi4 * Random.Range(2, 8);

        _ustDeger = Mathf.CeilToInt((sayi2 + sayi3) / sayi1);
        _altDeger = Mathf.CeilToInt((sayi5 + sayi6) / sayi4);

        Debug.Log(_ustDeger + "------" + _altDeger);

        if (_ustDeger > _altDeger)
        {
            _buyukDeger = _ustDeger;
        }
        else if (_ustDeger < _altDeger)
        {
            _buyukDeger = _altDeger;
        }
        if (_ustDeger == _altDeger)
        {
            altinciFonksiyon();
            return;
        }
        _ustText.text = ("(" + sayi2 + " + " + sayi3 + ")" + " / " + sayi1).ToString();
        _altText.text = ("(" + sayi5 + " + " + sayi6 + ")" + " / " + sayi4).ToString();
    }


    public void ButonDegeriniBelirle(string ButonAdi)
    {
        if (ButonAdi == "UstButon")
        {
            _butonDegeri = _ustDeger;
        }
        else if (ButonAdi == "AltButon")
        {
            _butonDegeri = _altDeger;
        }
        if (_butonDegeri == _buyukDeger)
        {
            Debug.Log("Doðru");
            _daireManager.DaireScaleAc(_oyunSayac % 5);
            _oyunSayac++;
            _dogruSayisi++;
            _trueFalse.activeTrue();
            KacinciOyun();

        }
        else
        {
            Debug.Log("Yanlýþ");
            _daireManager.DaireScaleAc(_oyunSayac % 5);
            _oyunSayac++;
            _yanlisSayisi++;
            _trueFalse.activeFalse();
            KacinciOyun();
        }

    }
}
