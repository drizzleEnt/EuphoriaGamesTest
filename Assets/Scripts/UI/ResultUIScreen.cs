using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUIScreen : UIScreen
{
    [SerializeField] private TMP_Text _cubeText;
    [SerializeField] private TMP_Text _sphereText;
    [SerializeField] private TMP_Text _culinderText;
    [SerializeField] private Button _restartButon;

    /*private void Start()
    {
        _restartButon.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0));
    }*/

    public override void Init(int cubeCount, int sphereCount, int culinderCount)
    {
        _restartButon.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0));
        _cubeText.text = cubeCount.ToString();
        _sphereText.text = sphereCount.ToString();
        _culinderText.text = culinderCount.ToString();
    }
}
