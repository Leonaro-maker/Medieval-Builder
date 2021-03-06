﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string type;
    private List<string> typesAvailable = new List<string>{"Human", "Zombie", "Belmmyae", "Manticore", "Troll", "Huldra", "Werewolf", "Bahkauv"};
    [SerializeField] private int level;
    [SerializeField] private int baseHealth;
    [SerializeField] private int magic;
    [SerializeField] private int ranged;
    [SerializeField] private int melee;
    [SerializeField] private float baseCritChance;
    [SerializeField] private float attackRange;
    [SerializeField] private int baseArmor;
    [SerializeField] private int baseMovementspeed;
    [SerializeField] private int baseAttackSpeed;
    [SerializeField] private int frostResistance;
    [SerializeField] private int fireResistance;
    [SerializeField] private bool aggressive;
    [SerializeField] private List<Ability> abilities = new List<Ability>();
    [SerializeField] private Dictionary<Dictionary<string, int>, float> droptable = new Dictionary<Dictionary<string, int>, float>();
    AbilityCatalog abilityCatalog;

    public Enemy(string name, string description, string type, int level, int maxHealth, int ranged, int magic, int melee, float critChance, float attackRange, int armor, int movementspeed, int baseAttackSpeed, int frostResistance, int fireResistance, bool aggressive, List<string> abilitiesString, Dictionary<Dictionary<string, int>, float> droptable){
        this.name = name;
        this.description = description;
        if(!typesAvailable.Contains(type)){
            throw new System.ArgumentException("That type does not exist");
        } else {
            this.type = type;
        }
        this.type = type;
        this.level = level;
        this.baseHealth = maxHealth;
        this.ranged = ranged;
        this.melee = melee;
        this.magic = magic;
        this.baseCritChance = critChance;
        this.attackRange = attackRange;
        this.baseArmor = armor;
        this.baseMovementspeed = movementspeed;
        this.baseAttackSpeed = baseAttackSpeed;
        this.frostResistance = frostResistance;
        this.fireResistance = fireResistance;
        this.aggressive = aggressive;
        this.droptable = droptable;
      

        abilityCatalog = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AbilityCatalog>();

        if(abilitiesString.Count > 0){
            foreach(string ability in abilitiesString){
                if(abilityCatalog){
                    //Debug.Log(abilityCatalog.getAbilityByName(ability));
                    //if(abilityCatalog.getAbilityByName(ability) != null){
                        this.abilities.Add(abilityCatalog.getAbilityByName(ability));
                    //} else {
                    //    throw new System.ArgumentException("Tried to add an ability that dont exist: " + ability);
                    //}
                } else {
                    Debug.Log("couldnt find catalog");
                }
            }
        }
    }

    void Awake()
    {
        
    }

    public string getName(){
        return name;
    }
    public string getDescription(){
        return description;
    }
    public string getType(){
        return type;
    }
    public int getLevel(){
        return level;
    }
    public int getBaseHealth(){
        return baseHealth;
    }
    
    public float getBaseCritChange(){
        return baseCritChance;
    }
    public int getBaseArmor(){
        return baseArmor;
    }
    public int getBaseMovementSpeed(){
        return baseMovementspeed;
    }
    public int getAttackSpeed(){
        return baseAttackSpeed;
    }
    public float getAttackRange(){
        return attackRange;
    }
    public List<Ability> getAbilities(){
        return abilities;
    }
    public bool getAggressive(){
        return aggressive;
    }
    public Dictionary<Dictionary<string, int>, float> getDroptable(){
        return droptable;
    }
    public int getRanged(){
        return ranged;
    }

    public int getMagic(){
        return magic;
    }
    public int getMelee(){
        return melee;
    }
    public int getFrostResistance(){
        return frostResistance;
    }
    public int getFireResistance(){
        return fireResistance;
    }
}
