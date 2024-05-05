using UnityEngine;
using NTC.Pool;
public class OrePart: pickableItem{
    private void Start() {
        target = transform;    
    }

    private void Update() {
        if(isOnMove){
            RotateMove();
            if(Vector3.Distance(target.position, transform.position)<1){
                isOnMove = false;
                target.GetComponent<APlayer>().ApplyOre(value);
                NightPool.Despawn(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!isOnMove){
            if (other.gameObject.tag == "Player")            
                if (other.gameObject.TryGetComponent(out APlayer player)){
                    target = other.transform;
                    isOnMove = true;
                
            }

        }
    }
    

}