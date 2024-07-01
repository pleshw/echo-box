using System.Numerics;
using Game;

namespace Tests;


public static class EntityTests
{
    public static readonly DialogueComponent DialogueComponentWithoutContinuation = new()
    {
        Id = new Guid("26e2357a-ea5d-4cce-918d-62d8de0c964a"),
        Title = "Test Dialogue Without Continuation",
        Content = "This is a test Dialogue without continuation.",
        Options = [],
        AlreadyCompleted = false,
        IsReadyToComplete = true,
        IsHidden = false,
    };

    public static readonly QuestDialogueComponent DialogueComponentWithQuest = new()
    {
        Id = new Guid("c00707b8-16d2-48af-a0a5-1d05c553a5f8"),
        Title = "Test Dialogue With Quest",
        Content = "This is a test Dialogue that, when confirmed, will assign a quest to the player.",
        Options = [DialogueComponentWithoutContinuation],
        AlreadyCompleted = false,
        IsReadyToComplete = true,
        IsHidden = false,
        Quest = QuestTests.SerializableQuestAllTasks
    };

    public static readonly MenuPortraitDialogueComponent DialogueComponentWithShopMenuAndPortrait = new()
    {
        Id = new Guid("49d83ba6-690c-474f-b677-642866686728"),
        Title = "Test Dialogue With Shop Menu and Continuation",
        Content = "This is a test Dialogue with a shop menu and some continuation lines.",
        Options = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
        AlreadyCompleted = false,
        IsReadyToComplete = true,
        IsHidden = false,
        MenuComponent = new MenuShopComponent
        {
            DisplayName = "What are you buying?",
            ItemList = [ItemTests.SerializableShopItemSlot1, ItemTests.SerializableShopItemSlot2, ItemTests.SerializableShopItemSlot3],
            UniqueName = "CraftMenuDialogueComponentWithMenu"
        },
        ListenerPortrait = new DisplayImageComponent
        {
            DisplayImage = "test/image/filepath"
        },
        SpeakerPortrait = new DisplayImageComponent
        {
            DisplayImage = "test/image/filepath"
        },
    };

    public static readonly PlayerEntity PlayerActor = new("PlayerActor");

    public static readonly NonPlayableEntity CompanionActor = new("CompanionActor", [
        new DisplayNameComponent
        {
            DisplayName = "Companion"
        },
        new MenuPortraitDialogueComponent()
        {
            Id = new Guid("49d83ba6-690c-474f-b677-642866686728"),
            Title = "Test Dialogue With Shop Menu and Continuation",
            Content = "This is a test Dialogue with a shop menu and some continuation lines.",
            Options = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
            AlreadyCompleted = false,
            IsReadyToComplete = true,
            IsHidden = false,
            MenuComponent = new MenuShopComponent
            {
                DisplayName = "What are you buying?",
                ItemList = [ItemTests.SerializableShopItemSlot1, ItemTests.SerializableShopItemSlot2, ItemTests.SerializableShopItemSlot3],
                UniqueName = "CraftMenuDialogueComponentWithMenu"
            },
            ListenerPortrait = new DisplayImageComponent
            {
                DisplayImage = "test/image/filepath"
            },
            SpeakerPortrait = new DisplayImageComponent
            {
                DisplayImage = "test/image/filepath"
            },
        },
        new PositionComponent
        {
            Position = Vector2.Zero
        },
        new InventoryComponent
        {
            Owner = new PlayerEntity("PlayerActor"),
            Items = [],
            Capacity = 10
        },
        new AliveComponent
        {
            IsAlive = true
        },
        new RelationshipComponent
        {
            CompletedDialogs = [],
            Level = 0,
        }
    ]);

    public static readonly NonPlayableEntity TargetActor = new("TargetActor", [
        new DisplayNameComponent
        {
            DisplayName = "TargetActor"
        },
        new MenuPortraitDialogueComponent()
        {
            Id = new Guid("49d83ba6-690c-474f-b677-642866686728"),
            Title = "Test Dialogue With Shop Menu and Continuation",
            Content = "This is a test Dialogue with a shop menu and some continuation lines.",
            Options = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
            AlreadyCompleted = false,
            IsReadyToComplete = true,
            IsHidden = false,
            MenuComponent = new MenuShopComponent
            {
                DisplayName = "What are you buying?",
                ItemList = [ItemTests.SerializableShopItemSlot1, ItemTests.SerializableShopItemSlot2, ItemTests.SerializableShopItemSlot3],
                UniqueName = "CraftMenuDialogueComponentWithMenu"
            },
            ListenerPortrait = new DisplayImageComponent
            {
                DisplayImage = "test/image/filepath"
            },
            SpeakerPortrait = new DisplayImageComponent
            {
                DisplayImage = "test/image/filepath"
            },
        },
        new PositionComponent
        {
            Position = Vector2.Zero
        },
        new InventoryComponent
        {
            Owner = new PlayerEntity("PlayerActor"),
            Items = [],
            Capacity = 10
        },
        new AliveComponent
        {
            IsAlive = true
        },
        new RelationshipComponent
        {
            CompletedDialogs = [],
            Level = 0,
        }
    ]);

    public static readonly List<BaseEntity> AllEntities = [PlayerActor, CompanionActor, TargetActor];

    public static void TestRemakeAllEntities()
    {
        AllEntities.ForEach(q => FileController.CreateProjectFile(
            new ProjectFileInfo<BaseEntity>()
            {
                FolderPath = "entity/test/",
                FileName = q.UniqueName + ".json",
                FileData = q
            }
        ));
    }

    public static BaseEntity GetEntityByUniqueName(string uniqueName)
    {
        return AllEntities.Where(q => q.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.");
    }

    public static List<BaseEntity> GetEntitiesByUniqueName(List<IUniqueNameComponent> uniqueNames)
    {
        return GetEntitiesByUniqueName(uniqueNames.Select(u => u.UniqueName).ToList());
    }

    public static List<BaseEntity> GetEntitiesByUniqueName(List<string> uniqueNames)
    {
        return uniqueNames.Select(uniqueName =>
                  AllEntities.FirstOrDefault(q => q.UniqueName == uniqueName)
                  ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.")
              ).ToList();
    }
}