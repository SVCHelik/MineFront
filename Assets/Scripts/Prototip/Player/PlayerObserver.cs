using UnityEngine;
public static class PlayerObserver{
    public static Transform Player1Pos;
    public static Transform Player2Pos;
    public static float getPlayersDist(){
        if(Is1PlayerAlive && Is2PlayerAlive){
            return Vector3.Distance(Player1Pos.position, Player2Pos.position);
        }
        else return 0;
    }
    public static bool Is1PlayerAlive;
    public static bool Is2PlayerAlive;

}