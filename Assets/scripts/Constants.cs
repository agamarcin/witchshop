using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    //public const int LIVES = 3;
    public enum Targets : int
    {
        SELF,
        RELETIONSHIP,
        PROCESS,
        DIRECTIONS
    }
    
    public enum Elements : int
    {//change element into interface/class
        FIRE,
        AIR,
        WATER,
        EARTH,
        SPIRIT
    }
    
    public enum Values : int
    {
        
        NUA,
        LAO,
        KORE,
        TOA,
        MUNU,
        SUOS,
        VAS,
        EZRO//base item
        
        /*LUCK,
        WISDOM,//likes mana
        PATIENCE,//likes strength
        COURAGE,//likes love
        MANA,//likes wisdom
        LOVE,//likes courage
        STRENGTH//likes patience*/
    }   
    
    public enum Colors : int
    {
        WHITE,
        BLACK,
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE,
        PINK,
        BROWN,
        SILVER,
        GOLD
    }   
    
    
}
