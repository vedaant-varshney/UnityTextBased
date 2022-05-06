using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;



// Class to make handling game text easier

/// <summary>
/// Class to handle basic game text management and animation
/// </summary>
public class TextManage
{

    // Fields (Variables)
    private GameObject parentGO;
    private TextMeshProUGUI tmproGUI;
    private MonoBehaviour monob;
    private AudioSource source;
    private AudioClip clip;
    private string initText;
    private string outString;
    
    // Properties (Public: get,set)
       

    // Constructors 

    // Version where we are handling a specific text element that must play audio
    public TextManage(GameObject parentGameObject, MonoBehaviour mono, AudioSource asource)
    {
        parentGO = parentGameObject;
        tmproGUI = parentGO.GetComponent<TextMeshProUGUI>();
        initText = tmproGUI.text;
        monob = mono;
        source = asource;
        clip = asource.clip;
    }
    
    

     

    // Methods

    /// <summary>
    /// Makes the GUI Element's text element appear on an interval 
    /// </summary>
    /// <param name="interval">Add speed in seconsd</param>
    public IEnumerator textAppear(float interval, string newText)
    {
        foreach (char c in newText)
        {
            outString += c.ToString();
            source.PlayOneShot(clip);
            tmproGUI.text = outString;
            yield return new WaitForSeconds(interval);
        }
        // Reset outstring to "" 
        outString = "";
    }
   
    
    /// <summary>
    /// Makes the GUI Element's text element disappear on an interval 
    /// </summary>
    /// <param name="interval">Remove speed in seconsd</param>
    public IEnumerator textDisappear(float interval)
    {
        int strlen = initText.Length;
        for (int i = strlen-1; i >= 0; --i)
        {

            source.PlayOneShot(clip);
            tmproGUI.text = initText.Substring(0, i);
            yield return new WaitForSeconds(interval);
        }
    }

    /// <summary>
    /// Replaces given text by first causing a disappear before the appear
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="newText"></param>
    public IEnumerator textReplace(float interval, string newText)
    {
        yield return monob.StartCoroutine(textDisappear(interval));
        // monob.StopAllCoroutines();
        yield return monob.StartCoroutine(textAppear(interval, newText));
    }

    /// <summary>
    /// Makes parent object disappear by scaling to 0 
    /// </summary>  
    public IEnumerator moveOut()
    {
        parentGO.transform.localScale = new Vector3(0, 0);
        yield return null; 
    }

    /// <summary>
    /// Makes parent reappear by scaling back to 1
    /// </summary>
    /// <returns></returns>
    public IEnumerator moveIn()
    {
        parentGO.transform.localScale = new Vector3(1, 1);
        yield return null; 
    }


    // Move off screen
    // Fancy text display new
    // Replace old

}
 
 