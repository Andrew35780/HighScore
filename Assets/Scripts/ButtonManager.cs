using System.Collections;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Animation startWindowAnimation;

    public void OnStartButton_Click() 
    {
        GetComponent<AudioSource>().Play();
        
        StartCoroutine(StartWindowAnimation());
    }

    private IEnumerator StartWindowAnimation()
    {
        yield return new WaitForSeconds(0.15f);

        startWindowAnimation.Play();
    }
}
