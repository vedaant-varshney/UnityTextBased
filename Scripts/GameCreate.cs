using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dectree;


// This may need some reference to MonoBehavior
public class GameLogic
{

    MonoBehaviour main;

    public GameLogic(MonoBehaviour mono)
    {
        main = mono;        
    }



    /// <summary>
    /// Manual creation of each game event 
    /// </summary>
    /// <returns></returns>
    public CustTree buildGameTree()
    {
        CustTree game = new CustTree();
        game.insertNode(new int[] { 0 }, 
            "Good day traveller. I am Otisio. You must escape this dungeon.", 
            "story", 
            new int[] { 0, 0, 0, 0, 0, 0}, 
            new string[] {"Proceed Left.", "Wait here.", "Proceed right." });
        game.insertNode(new int[] { 1 }, 
            "You have taken the left door. Before you lies a relic of the past. A ring which grants vitality (increases health cap). You take it.", 
            "treasure", 
            new int[] { 1, 0, 0, 1, 0, 0 }, 
            new string[] {"Exit", "", "" });
        game.insertNode(new int[] { 2 }, 
            "You have chosen to wait. Otisio seems disappointed. It seems he is not who you thought. Revealing his true identity as the creator of the dungeon, he vanquishes you for being boring.", 
            "gameover", 
            new int[] { -999, -999, -999, 0, 0, 0 }, 
            new string[] {"Restart.", "", "" });
        game.insertNode(new int[] { 3 }, 
            "You have taken the right door. You are face-to-face with a goblin.", 
            "enemy", 
            new int[] { 0, 0, 0, 0, 0, 0 }, 
            new string[] {"Attack", "Flee", "" });
        // The effects of a combat_win include the reward for the fight 
        game.insertNode(new int[] { 3, 1 }, 
            "You attack, narrowly winning. You lose health but now know how to better fight", 
            "combat_win", 
            new int[] { -2, 1, 0, 0, 1, 0 }, 
            new string[] {"Exit", "", "" });
        game.insertNode(new int[] { 3, 2 },
            "You are defeated in battle. You have lost.",
            "gameover",
            new int[] { -999, -999, -999, 0, 0, 0 },
            new string[] { "Restart", "", "" });  
        game.insertNode(new int[] { 3, 1, 1 }, 
            "After defeating the goblin, you find yourself outside of the dungeon. How peculiar. You won.", 
            "win", 
            new int[] { 0, 0, 0, 0, 0 }, 
            new string[] {"", "", "" }); 
        game.insertNode(new int[] { 1, 1 }, 
            "After obtaining treasure, you find yourself outside of the dungeon. How peculiar. You won.", 
            "win", 
            new int[] { 0, 0, 0, 0, 0 }, 
            new string[] {"", "", "" });
        

        return game;

    }


    //public CustTree goLeft()
    //{

    //}

    // If you reach an empty pathway 

}
