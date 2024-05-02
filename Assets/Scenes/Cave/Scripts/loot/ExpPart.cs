using UnityEngine;
using NTC.Pool;
public class ExpPart:pickableItem {
    

    private void Start() {
        target = transform;    
    }

    private void Update() {
        if(isOnMove){
            RotateMove();
            if(Vector3.Distance(target.position, transform.position)<1){
                isOnMove = false;
                target.GetComponent<Player>().ApplyExp(value);
                NightPool.Despawn(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!isOnMove){
            if (other.gameObject.tag == "Player")            
                if (other.gameObject.TryGetComponent(out Player player)){
                    target = other.transform;
                    isOnMove = true;
                
            }

        }
    }
}