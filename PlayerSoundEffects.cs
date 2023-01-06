using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Atavism;

public class PlayerSoundEffects : MonoBehaviour
{
    //time variables for storing the actual time

    public AudioSource idle;

    [Space]
    [Space]

    public AudioSource walk;
    public AudioClip[] walk_Sound_Array;

    [Space]
    [Space]

    public AudioSource run;
    public AudioSource jump;

    [Space]
    [Space]

    public AudioSource get_Damage;
    public AudioSource death;
    public AudioSource swimming_idle;
    public AudioSource swimming;

    [Space]
    [Space]

    public AudioSource chopping;
    public AudioClip[] chopping_Sound_Array;

    [Space]
    [Space]

    public AudioSource skinning;
    public AudioClip[] skinning_Sound_Array;

    [Space]
    [Space]

    public AudioSource mining;
    public AudioClip[] mining_Sound_Array;

    [Space]
    [Space]

    public AudioSource fishing_In;
    public AudioSource fishing_Bait;
    public AudioSource fishing_Loop;
    public AudioClip[] fishing_Loop_Sound_Array;

    [Space]
    [Space]

    public AudioSource gathering;
    public AudioClip[] gathering_Sound_Array;

    public AudioSource phalanx_Slash_Attack;
    public AudioClip[] phalanx_Slash_Attack_Sound_Array;

    [Space]
    [Space]

    public AudioSource phalanx_Shield_Block;
    public AudioClip[] phalanx_Shield_Block_Sound_Array;

    [Space]
    [Space]

    public AudioSource phalanx_Shield_Bash;

    [Space]
    [Space]

    public AudioSource phalanx_Regenerative_Light;
    public AudioClip[] phalanx_Regenerative_Light_Sound_Array;

    [Space]
    [Space]

    public AudioSource dropSound_Fiat;
    public AudioClip[] dropFiat_Sound_Array;

    [Space]
    [Space]

    public AudioSource lootSearchSound;
    public AudioSource lootFindSound;
    public AudioClip[] lootSearchSound_Array;
    public AudioClip[] lootFindSound_Array;


    [Space(10)]
    public AudioSource interactiveTaskTriggerSound;
    public AudioClip[] interactiveTaskTriggerSound_Array;

    [Space(10)]
    public AudioSource itemHarvestedSound;
    public AudioClip[] itemHarvestedSound_Array;

    [Space(10)]
    public AudioSource combatStartedSound;
    public AudioClip[] combatStartedSound_Array;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //get player animator at start

        anim = GetComponent<Animator>();

        //register Loot update event

        AtavismEventSystem.RegisterEvent("LOOT_UPDATE", this);
        AtavismEventSystem.RegisterEvent("INVENTORY_EVENT", this);
        AtavismEventSystem.RegisterEvent("PLAYER_COMBAT_STARTED", this);
        AtavismEventSystem.RegisterEvent("GATHERING_STARTED", this);

    }

    // Update is called once per frame
    void Update()
    {

        //loot search sound - Disabled for now

        //if (anim.GetBool("Loot") == true)
        //{
        //    if (!lootSearchSound.isPlaying)
        //    {
        //        lootSearchSound.PlayOneShot(RandomClip(lootSearchSound_Array));
        //    }
        //}
    }

    //loot success sound

    public void OnEvent(AtavismEventData eData)
    {
        if (eData.eventType == "LOOT_UPDATE")
        {
            // Check to see if player actually found loot items
            if (Inventory.Instance.Loot.Count > 0 || Inventory.Instance.LootCurr.Count > 0)
            {
                if (!lootFindSound.isPlaying)
                {
                    lootFindSound.Play();
                }
            }
        }
        else if (eData.eventType == "INVENTORY_EVENT" && eData.eventArgs[0] == "ItemHarvested")
        {
            if (!lootFindSound.isPlaying)
            {
                lootFindSound.Play();
            }
        }
        else if (eData.eventType == "PLAYER_COMBAT_STARTED")
        {
            combatTriggeredSound();
        }
        else if (eData.eventType == "GATHERING_STARTED")
        {
            // Play Interactive Task Trigger
        }
    }

    IEnumerator delayPlayLoot()
    {

        //Wait for seconds
        yield return new WaitForSeconds(1);
        lootFindSound.PlayOneShot(RandomClip(lootFindSound_Array));

    }

    AudioClip RandomClip(AudioClip[] clipArray)
    {
        return clipArray[Random.Range(0, clipArray.Length)];
    }

    void IdleSound()
    {
        idle.Play();
    }

    void WalkSound()
    {
        walk.PlayOneShot(RandomClip(walk_Sound_Array));
    }

    void RunSound()
    {
        run.Play();
    }

    void JumpSound()
    {
        jump.Play();
    }

    void GetDamageSound()
    {
        get_Damage.Play();
    }

    void DeathSound()
    {
        death.Play();
    }

    void SwimmingIdleSound()
    {
        swimming_idle.Play();
    }

    void SwimmingSound()
    {
        swimming.Play();
    }

    void ChoppingSound()
    {
        chopping.PlayOneShot(RandomClip(chopping_Sound_Array));
    }
    void interactiveTaskSound()
    {
        interactiveTaskTriggerSound.PlayOneShot(RandomClip(interactiveTaskTriggerSound_Array));
    }
    public void combatTriggeredSound()
    {
        combatStartedSound.PlayOneShot(RandomClip(combatStartedSound_Array));
    }
    void SkinningSound()
    {
        skinning.Play();
    }

    void MiningSound()
    {
        mining.PlayOneShot(RandomClip(mining_Sound_Array));
    }

    void FishingInSound()
    {
        fishing_In.Play();
    }

    void FishingLoopSound()
    {
        fishing_Loop.PlayOneShot(RandomClip(fishing_Loop_Sound_Array));
    }

    void FishingBaitSound()
    {
        fishing_Bait.Play();
    }

    void ItemHarvestedSound()
    {
        itemHarvestedSound.PlayOneShot(RandomClip(itemHarvestedSound_Array));
    }

    void PhalanxSlashAttackSound()
    {
        phalanx_Slash_Attack.PlayOneShot(RandomClip(phalanx_Slash_Attack_Sound_Array));
    }

    void PhalanxShieldBlockSound()
    {
        phalanx_Shield_Block.PlayOneShot(RandomClip(phalanx_Shield_Block_Sound_Array));
    }

    void PhalanxShieldBashSound()
    {
        phalanx_Shield_Bash.Play();
    }

    void PhalanxRegenerativeLightSound()
    {
        phalanx_Regenerative_Light.PlayOneShot(RandomClip(phalanx_Regenerative_Light_Sound_Array));
    }

    void StartSwing()
    {
        var animator = GetComponent<Animator>();

        animator.SetBool("Weapon_Swing", true);
    }

    void StopSwing()
    {
        var animator = GetComponent<Animator>();

        animator.SetBool("Weapon_Swing", false);
    }

    IEnumerator WaitForSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}