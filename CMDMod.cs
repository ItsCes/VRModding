using Stunlock.Core;
using ScarletCore.Services;
using VampireCommandFramework;

namespace FAFO; 

/* 
Praise the Barrel.
Be the Barrel.
Become Barrel.
*/

public class Custom_Commands {

static readonly PrefabGUID BarrelDisguiseABG = new(1250098443); // AB_Consumable_BarrelDisguise_AbilityGroup
static readonly PrefabGUID DanceEmoteABG = new(604121141); // AB_Emote_Vampire_DanceSingle01_AbilityGroup
static readonly PrefabGUID LaughABG = new(-1685517289); // AB_Emote_Vampire_Laugh_AbilityGroup
static readonly PrefabGUID DanceEmoteABG2 = new(-925169006); //AB_Emote_Vampire_DanceSingle02_AbilityGroup

    [Command("sov barrel")]
    public void BarrelShift(ChatCommandContext ctx) {
        var player = ctx.Event.SenderCharacterEntity;
        AbilityService.CastAbility(player, BarrelDisguiseABG);
    }
    [Command("sov emote dance1")]
    public void Dance1Emote(ChatCommandContext ctx) {
        var player = ctx.Event.SenderCharacterEntity;
        AbilityService.CastAbility(player, DanceEmoteABG);
    }
    [Command("sov emote danc21")]
    public void Dance2Emote(ChatCommandContext ctx) {
        var player = ctx.Event.SenderCharacterEntity;
        AbilityService.CastAbility(player, DanceEmoteABG2);
    }
    [Command("sov emote laugh")]
    public void LaughEmote(ChatCommandContext ctx) {
        var player = ctx.Event.SenderCharacterEntity;
        AbilityService.CastAbility(player, LaughABG);
    }

}
