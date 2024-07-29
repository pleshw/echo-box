using System.Numerics;
using Build;
using Game;

namespace Game;


public static class EntityTests
{
    public static readonly ItemComponent TestOreItem = new()
    {
        ItemType = ItemTypes.ORE,
        DisplayName = "Test Ore",
        UniqueName = "Test Ore",
        RequiredLevel = 0,
        Description = "A Weapon for testing purposes",
        DisplayImage = "test/image/filepath",
    };

    public static readonly StageBuilderComponent TestStageBuilder = new()
    {
        UniqueName = "TestStageBuilder",
        GatherList = [
        new GatherComponent
      {
        UniqueName = "TestOre",
        RequiredLevel = 0,
        Resource = TestOreItem,
        TimeToRenew = 100,
        CompletedAt = null,
        Amount = 10,
        TotalProgress = 10,
        CurrentProgress = 0,
        Position = Vector2.Zero,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 10}
        }
      }
      ],
        GridMap = new GridMapComponent()
        {
            GridCells = Enumerable.Range(0, 100)
                            .Select(i => new GridCellComponent
                            {
                                Position = new(i % 10, i / 10),
                                Size = new(3, 3),
                                Index = i,
                                Status = (GridCellStatus)(1 << (i % 6))
                            } as IGridCellComponent)
                            .ToList(),
            Width = 10,
            Height = 10
        },
    };

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
        new HasPositionComponent
        {
            Position = Vector2.Zero
        },
        new InventoryComponent
        {
            Owner = new PlayerEntity("PlayerActor"),
            Items = [],
            MaxStackSize = 10
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


    private static readonly IEntityRoutineComponent DefaultRoutine = new EntityRoutineComponent
    {
        EntityBehaviourByGameTime = new()
    {
      { 0, new EntityBehaviourComponent
          {
            BehaviourType = BehaviourType.IDLE,
            Position = new(),
            TargetPosition = new(20,20)
          }
      }
    }
    };

    public static readonly BehaviourEntity BehaviourNPCActor = new("BehaviourNPCActor",
    new EntityScheduleComponent
    {
        DefaultRoutine = DefaultRoutine,

        EntityRoutineByGameDay = new()
        {
            {1, DefaultRoutine},
        },
    },
    [
        new DisplayNameComponent
        {
            DisplayName = "Behaviour NPC Actor"
        },
        new MenuPortraitDialogueComponent()
        {
            Id = new Guid("abbc29f9-945f-40f6-9ab7-6ab81233b2ca"),
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
        new HasPositionComponent
        {
            Position = Vector2.Zero
        },
        new InventoryComponent
        {
            Owner = new PlayerEntity("PlayerActor"),
            Items = [ItemTests.SerializableAllUsesItemItemSlot],
            MaxStackSize = 10
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
        new HasPositionComponent
        {
            Position = Vector2.Zero
        },
        new InventoryComponent
        {
            Owner = new PlayerEntity("PlayerActor"),
            Items = [],
            MaxStackSize = 10
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

    public static readonly List<BaseEntity> AllEntities = [PlayerActor, CompanionActor, TargetActor, BehaviourNPCActor];

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

    public static void TestRemakeBehaviourEntity()
    {
        new List<BehaviourEntity>() { BehaviourNPCActor }.ForEach(q => FileController.CreateProjectFile(
                "entity/test/",
                 q.UniqueName + ".json",
                 q
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