using UnityEngine;

public class Player1 : APlayer
{ 
    void Start()

    {
        _characterController = GetComponent<CharacterController>();
        _characterController.enabled = true;
        currentHP = maxHP;
        PlayerObserver.Player1Pos = transform;
        PlayerObserver.Is1PlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(mining && timer>= speedMine){
            timer = 0;
            CastStoneMine();
        }
        if (Functions.TryFindNearEnemy(transform.position, out GameObject target)){
            transform.LookAt(target.transform);
        }
        //else transform.LookAt(fixDir);
    }
    private void FixedUpdate()
    {
        Walk();
    }
    

    
    #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            overlapMine.TryDrawGizmos();
        }
    #endif
}
