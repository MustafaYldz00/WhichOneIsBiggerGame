using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _SayacText;

    public float _toplamSure;
    public float _GuncelSure {  get; private set; }
    private bool _isPlaying;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        _GuncelSure = _toplamSure;
        _isPlaying = true;
        
    }

    public void StartTimer()
    {
        StartCoroutine(SayacBasla());
    }

    public void PauseTimer()
    {
        _isPlaying = false;
    }
    public void ResumeTimer()
    {
        if (_GuncelSure > 0 && !_isPlaying)
        {
            _isPlaying = true;
            StartCoroutine(SayacBasla());
        }
    }

    IEnumerator SayacBasla()
    {
        yield return new WaitForSeconds(0.001f);
        
        while (_isPlaying)
        {
          if (_GuncelSure > 0)
          {
            _GuncelSure -= Time.deltaTime;
            if (_GuncelSure <= 9)
                {
                    _SayacText.text = "0"+ Mathf.CeilToInt(_GuncelSure).ToString();
                }
            else
                {
                    _SayacText.text = Mathf.CeilToInt(_GuncelSure).ToString();
                }
            }
          else
            {
                _isPlaying = false;
                _SayacText.text = "00";
                OyunuBitir();
            }
            yield return null;
        }
    }

    private void OyunuBitir()
    {
        Debug.Log("Doðru Sayýsý = " +_gameManager._dogruSayisi);
        Debug.Log("Yanlýþ Sayýsý = " +_gameManager._yanlisSayisi);
        
        GameObject ustButon = GameObject.Find("UstButon");
        GameObject altButon = GameObject.Find("AltButon");

        if (ustButon != null)
        {
            ustButon.GetComponent<Button>().interactable = false;
        }
        if (altButon != null)
        {
            altButon.GetComponent<Button>().interactable = false;
        }
    }
   
}
