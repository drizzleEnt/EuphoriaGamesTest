using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _cubeText;
    [SerializeField] private TMP_Text _sphereText;
    [SerializeField] private TMP_Text _culinderText;

    private ObjectReceiver[] _receivers;

    private void Start()
    {
        _receivers = FindObjectsOfType<ObjectReceiver>();

        foreach (var receiver in _receivers)
        {
            receiver.CollectedObject += IncreaseValeu;
        }
    }

    private void IncreaseValeu(ObjectType type)
    {
        int currentScore = 0;

        switch (type)
        {
            case ObjectType.Cube:
                currentScore = GetCurrentScore(_cubeText);
                _cubeText.text = currentScore.ToString();
                break;
            case ObjectType.Sphere:
                currentScore = GetCurrentScore(_sphereText);
                _sphereText.text = currentScore.ToString();
                break;
            case ObjectType.Capsul:
                currentScore = GetCurrentScore(_culinderText);
                _culinderText.text = currentScore.ToString();
                break;
            default:

                break;
        }
    }

    private int GetCurrentScore(TMP_Text text)
    {
        Debug.Log(Convert.ToInt32(text.text));
        return (Convert.ToInt32(text.text)+1);
    }

    public int[] GetScore()
    {
        int[] scores = new int[3];
        scores[0] = Convert.ToInt32(_cubeText.text);
        scores[1] = Convert.ToInt32(_sphereText.text);
        scores[2] = Convert.ToInt32(_culinderText.text);
        return scores;
    }
}
