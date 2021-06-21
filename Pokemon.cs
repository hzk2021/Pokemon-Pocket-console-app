using System;
using System.Collections.Generic;

/**
    Student Name: He Zhenkai
    Admin Number: 204304Z
    Tutorial Group: 4
**/

namespace PokemonPocket{
    public class PokemonMaster{
        public string Name {get;set;}
        public int NoToEvolve {get; set;}
        public  string EvolveTo {get; set;}

        public PokemonMaster(string name, int noToEvolve, string evolveTo){
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }
    }

    public abstract class Pokemon
    {
        public string Name {get;set;}
        public int Health {get; set;}
        public int Exp {get; set;}

        public abstract string GetSkills();
        public Pokemon(string name, int health, int exp)
        {
            this.Name = name;
            this.Health = health;
            this.Exp = exp;
        }
    }

    public class Pikachu : Pokemon
    {
        public string Skill {get; set;}
        public Pikachu(string name, int health, int exp) : base(name, health, exp)
        {
            this.Skill = "Lighting Bolt";
        }
        public override string GetSkills()
        {
            return this.Skill;
        }
    }

    public class Eevee : Pokemon
    {
        public string Skill {get; set;}
        public Eevee(string name, int health, int exp) : base(name, health, exp)
        {
            this.Skill = "Run Away";
        }
        public override string GetSkills()
        {
            return this.Skill;
        }
    }

    public class Charmander : Pokemon
    {
        public string Skill {get; set;}
        public Charmander(string name, int health, int exp) : base(name, health, exp)
        {
            this.Skill = "Solar Power";
        }
        public override string GetSkills()
        {
            return this.Skill;
        }
    }
  
  







  
}