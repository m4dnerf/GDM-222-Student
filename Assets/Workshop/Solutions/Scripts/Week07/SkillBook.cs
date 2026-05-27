using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack;
        Skill fireStorm;
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

    public void Start()
        {
            // สร้างสกิล
            attack = new Skill("Attack");
            attack.isAvailable = true;
            fireStorm = new Skill("Thunderburst");
            fireBall = new Skill("Overkill");
            fireBlast = new Skill("FireBurst");
            fireWave = new Skill("FirePlasma");
            fireExplosion = new Skill("FireExplosion");
       
        // build skill tree
        // └── Attack
        //     └── FireStorm
        //         ├── FireBlast
        //         └── FireBall
        //             └── FireWave
        //                 └── FireExplosion


        // 1. set the nextSkills for each skill

        // [0] Attack -> FireStorm
        attack.nextSkills.Add(fireStorm);
            // [1] FireStorm -> FireBlast
            fireStorm.nextSkills.Add(fireBlast);
            // [2] FireStorm -> FireBall
            fireStorm.nextSkills.Add(fireBall);
            // [3] FireBall -> FireWave
            fireBall.nextSkills.Add(fireWave);
            // [4] FireWave -> FireExplosion
            fireWave.nextSkills.Add(fireExplosion);
       

            this.attackSkillTree = new SkillTree(attack);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            } 
        }
    }

