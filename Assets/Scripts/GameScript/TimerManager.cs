using System.Collections;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _SayacText;

    public float _toplamSure;
    private float _GuncelSure;
    private bool _isPlaying;

    void Start()
    {
        _GuncelSure = _toplamSure;
        _isPlaying = true;
        
    }

    public void StartTimer()
    {
        StartCoroutine(SayacBasla());
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
            }
            yield return null;
        }
    }
   
}
