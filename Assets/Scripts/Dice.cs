using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private Text highScore;
    [SerializeField] private AudioSource rollDiceSound;
    [SerializeField] private Image dice;
    [SerializeField] private Sprite[] diceSprites;

    private void Start() => highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    public void RollDice()
    {
        rollDiceSound.Play();
        StartCoroutine(ChangeScore());
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }

    private Sprite GetSpriteByNumber(int number)
    {
        return number switch
        {
            1 => diceSprites[0],
            2 => diceSprites[1],
            3 => diceSprites[2],
            4 => diceSprites[3],
            5 => diceSprites[4],
            6 => diceSprites[5],
            _ => diceSprites[5],
        };
    }

    private IEnumerator ChangeScore() 
    {
        int number = Random.Range(1, 7);

        yield return new WaitForSeconds(0.7f);

        dice.enabled = true;

        dice.sprite = GetSpriteByNumber(number);

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }
}
