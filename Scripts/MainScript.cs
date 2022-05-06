using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dectree;
using UnityEngine.UI;
using TMPro;

public class MainScript : MonoBehaviour
{

    AudioSource source;
    [SerializeField] GameObject testing;
    [SerializeField] GameObject op1button;
    [SerializeField] GameObject op2button;
    [SerializeField] GameObject op3button;
    [SerializeField] GameObject oneText;
    [SerializeField] GameObject twoText;
    [SerializeField] GameObject threeText;
    [SerializeField] GameObject health;
    [SerializeField] GameObject attack;
    [SerializeField] GameObject luck;
    [SerializeField] GameObject mainText;
    TextMeshProUGUI op1text;
    TextMeshProUGUI op2text;
    TextMeshProUGUI op3text;
    Button op1but;
    Button op2but;
    Button op3but;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // testing =  GameObject.Find("Testing");
        source = GameObject.Find("Typewriter").GetComponent<AudioSource>();



        op1but = op1button.GetComponent<Button>();
        op2but = op2button.GetComponent<Button>();
        op3but = op3button.GetComponent<Button>();
        op1but.onClick.AddListener(op1OnClick);
        op2but.onClick.AddListener(op2OnClick);
        op3but.onClick.AddListener(op3OnClick);



        op1text = oneText.GetComponent<TextMeshProUGUI>();
        op2text = twoText.GetComponent<TextMeshProUGUI>();
        op3text = threeText.GetComponent<TextMeshProUGUI>();



        TextManage text = new TextManage(testing, this, source);
        yield return  StartCoroutine(text.textReplace(0.07f, "This is a new text"));
        // yield return StartCoroutine(text.moveIn());

        GameLogic gl = new GameLogic(this);


        CustTree game = gl.buildGameTree();
        PlayerCont player = new PlayerCont();

        // Player will begin the game. Once they click a button
        // they must traverse the tree with the applied effects
        // The effects will be dependent on the type of encounter (ie story or enemy)
        // The type of reaction will be different for each one, so we would likely need a function to handle this



    }

    // Update is called once per frame
    void Update()
    {
    }


    void op1OnClick ()
    {
        op1text.text = "wow much wow";
    }

    
    void op2OnClick ()
    {

        op1text.text = "wow much pow";
    }

    void op3OnClick ()
    {

        op1text.text = "wow much row";
    }
}
