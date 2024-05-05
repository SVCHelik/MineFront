using UnityEngine;
public static class PlayerObserver{
    public static Transform Player1Pos;
    public static Transform Player2Pos;
    public static float getPlayersDist(){
        return Vector3.Distance(Player1Pos.position, Player2Pos.position);
    }
    public static bool Is1PlayerAlive;
    public static bool Is2PlayerAlive;

}