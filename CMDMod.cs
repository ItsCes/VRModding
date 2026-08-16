using Stunlock.Core;
using VampireCommandFramework;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;

namespace FAFO; 
[CommandGroup("sov", "s")]
public class Custom_Commands {

    static readonly PrefabGUID BarrelDisguiseABG = new(1250098443); // AB_Consumable_BarrelDisguise_AbilityGroup
    static readonly PrefabGUID LaughABG = new(-1685517289); // AB_Emote_Vampire_Laugh_AbilityGroup

    [Command("barrel")]
    public void BarrelShift(ChatCommandContext ctx) {
        CastAbility(ctx, BarrelDisguiseABG);
    }

    [Command("emote laugh", "e laugh")]
    public void LaughEmote(ChatCommandContext ctx) {
        CastAbility(ctx, LaughABG);
    }

  public static void CastAbility(ChatCommandContext ctx, PrefabGUID abilityGroup) {
    Entity player = ctx.Event.SenderCharacterEntity;
    Entity user = ctx.Event.SenderUserEntity;
    EntityManager entityManager = Plugin.Server.EntityManager;

    CastAbilityServerDebugEvent castEvent = new() {
        AbilityGroup = abilityGroup,
        Who = entityManager.GetComponentData<NetworkId>(player)
    };

    FromCharacter fromCharacter = new() {
        Character = player,
        User = user
    };

    int userIndex = entityManager.GetComponentData<User>(user).Index;

    DebugEventsSystem debugEventsSystem = Plugin.Server.GetExistingSystemManaged<DebugEventsSystem>();
    debugEventsSystem.CastAbilityServerDebugEvent(userIndex, ref castEvent, ref fromCharacter);
}
}