using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform _kafa;
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _kafa.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);
        _startButton.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);
        baslaButon();
    }

    private void baslaButon()
    {
        _startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameLevel");
        });

    }
}
