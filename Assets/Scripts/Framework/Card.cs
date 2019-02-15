﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Infissy.Properties.CardProperties;

namespace Infissy.Framework
{



public class Card {

    //Absolute, healable, desctructible e targetable rimangono private e descrivono lo stato attuale della carta, sono modificabili solo tramite metodi specifici.
    //
    //Le altre variabili non dovrebbero necessitare alcuna proprietà in quanto utilizzate principalmente per la visualizzazione, pensando di separarle in
    //una ulteriore classe.
    private int absolute;
    private bool healable;
    private bool destructible;
    private bool targetable;


    public int Absolute { get{ return absolute;} }
    public bool Healable { get{ return healable; } }
    public bool Destructible {get{return destructible;}}
    public bool Targetable { get{ return targetable;}}

    public string Title;
    public Sprite CardImage;
    public string Description;
    public CardReferenceCity ReferenceCity;
    //Rarità della carta nel ritrovamento nei pacchetti unita all'estetica, ho usato metalli dell'epoca per poterne usare i colori della carta visualizzata.
    public CardRarity Rarity;

    public int usage;
    
    public List<CardEffect> Effects;
    public List<CardEffect> SpawnEffects;
    public int Progress;
    public CardType Type; 
    public int IDCard;
    
    /// <summary>
    /// Inizializza la carta con dei campi basilari.
    /// </summary>
  


    public void CardInitialize (string title,
                            Sprite cardImage,
                            int absolute,
                            string description,
                            CardReferenceCity referenceCity,
                            CardRarity rarity,
                            List<CardEffect> effect,
                            int progress,
                            CardType type)
    {
        Title = title;
        CardImage = cardImage;
        this.absolute = absolute;
        Description = description;
        ReferenceCity = referenceCity;
        Rarity = rarity;
       
        Effects = effect;
        Progress = progress;


        switch(type){
            
            //TODO:Struttura forse non curabile
            case CardType.Structure:
            case CardType.Attack:
            healable = true;
            destructible = true;
            targetable = true;
            break;
            default:
            healable = false;
            destructible = false;
            targetable = false;
                    break;

        }
    }

    
    

    public bool AffectCard(int absoluteValue){
        bool affected = true;
        //Healing
        if(absoluteValue >= 0){
                if(healable = true){
                absolute += absoluteValue;
                
            }else{
                affected = false;
            }
        }else{
            //Damaging 
            if((absolute + absoluteValue) < 0 ){
                if(destructible = true){
                    //DestroyCard()
                    
                }else{
                    absolute = 0;
                }
            }else{
                absolute += absoluteValue;
            }
            
        }
    
        return affected;
    }

}








    public struct CardEffect{
            
          
            public CardEffectTarget EffectTarget;
            public int EffectValue;
            public CardEffectType EffectType;

        

    }



}
