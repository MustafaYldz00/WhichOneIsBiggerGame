using DG.Tweening;
using UnityEngine;

public class DaireManager : MonoBehaviour
{
    [SerializeField] GameObject[] _daireler;
    void Start()
    {
        DaireScaleKapat();  
    }

    public void DaireScaleKapat()
    {
        for (int i = 0; i < _daireler.Length; i++)
        {
            _daireler[i].GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
    
    public void DaireScaleAc(int hangiDaire)
    {
        _daireler[hangiDaire].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if (hangiDaire % 5 == 0)
        {
            DaireScaleKapat();
        }
    }
}
