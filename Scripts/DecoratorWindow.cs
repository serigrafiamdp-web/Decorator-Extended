// DECORATOR EXTENDED
// Original mod: Decorator by Kaedius / KDS-KDS
// Extended modifications: DECORATOR EXTENDED BY RICO
// Unofficial fork - preserves the original MIT license.

using DaggerfallConnect.Arena2;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Banking;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Guilds;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Decorator
{
public class DecoratorWindow : DaggerfallPopupWindow
{
#region Fields
private Rect mainPanelRect = new Rect(0.0f, 0.0f, 120f, 20.0f);
private Rect listPanelRect = new Rect(0.0f, 22.0f, 120f, 150f);
private Panel mainPanel;
private Panel listPanel;
private LeftRightSpinner pageSpinner;
private Rect transformPanelRect = new Rect(0.0f, 0.0f, 190f, 60f);
private Rect transformSubPanel1Rect = new Rect(125.0f, 0.0f, 108f, 41f);
private Rect transformSubPanel2Rect = new Rect(125.0f, 41f, 108f, 11f);
private Rect upButtonRect = new Rect(48f, 0f, 11f, 10f);
private Rect downButtonRect = new Rect(48f, 31f, 11f, 10f);
private Rect leftButtonRect = new Rect(30f, 15f, 10f, 11f);
private Rect rightButtonRect = new Rect(66f, 15f, 11f, 11f);
private Rect rotateXZRightButtonRect = new Rect(61f, 6f, 9f, 9f);
private Rect rotateXZLeftButtonRect = new Rect(37f, 6f, 9f, 9f);
private Rect rotateLeftButtonRect = new Rect(37f, 26f, 9f, 9f);
private Rect rotateRightButtonRect = new Rect(61f, 26f, 9f, 9f);
private Rect acceptButtonRect = new Rect(50f, 17f, 7f, 7f);
private Rect lowButtonRect = new Rect(7f, 50f, 29f, 10f);
private Rect medButtonRect = new Rect(36f, 50f, 32f, 10f);
private Rect highButtonRect = new Rect(68f, 50f, 32f, 10f);
private Rect resetButtonRect = new Rect(169.0f, 42.0f, 20f, 7f);
private Rect deleteButtonRect = new Rect(169.0f, 50.0f, 20f, 7f);
private Texture2D transformSubPanelTexture1;
private Texture2D transformSubPanelTexture2;
private Panel transformPanel;
private Panel transformSubPanel1;
private Panel transformSubPanel2;
private Button upButton;
private Button downButton;
private Button leftButton;
private Button rightButton;
private Button rotateXZRightButton;
private Button rotateXZLeftButton;
private Button rotateLeftButton;
private Button rotateRightButton;
private Button acceptButton;
private Button resetButton;
private Button deleteButton;
private Button lowButton;
private Button medButton;
private Button highButton;
private Button debugButton;
private Checkbox scaleCheckBox;
private Checkbox snapCheckbox;
private Checkbox editCheckBox;
private Checkbox lightCheckbox;
private Checkbox containerCheckbox;
private Checkbox potionMakerCheckbox;
private Checkbox spellMakerCheckbox;
private Checkbox itemMakerCheckbox;
private Checkbox emulatorCheckbox;
private Checkbox emulator2Checkbox;
private Rect lightPanelRect = new Rect(230.0f, 95.0f, 90.0f, 53.0f);
private Panel lightPanel;
private Checkbox lightSpotCheckbox;
private HorizontalSlider lightIntensitySlider;
private HorizontalSlider lightSpotAngleSlider;
private HorizontalSlider lightHorizontalRotationSlider;
private HorizontalSlider lightVerticalRotationSlider;
private Button colorPicker;
private Rect scalePanelRect = new Rect(230.0f, 54.0f, 90.0f, 40.0f);
// RICOS UI TEST 09: Light submenu positioned below the Scale submenu footprint.
private Rect scaleResetButtonRect = new Rect(0.0f, 0.0f, 25.0f, 10.0f);
private Panel scalePanel;
private Button scaleResetButton;
private HorizontalSlider scaleXSlider;
private HorizontalSlider scaleYSlider;
private HorizontalSlider scaleZSlider;
private Transform Parent;
private GameObject previewGo;
private Light previewLight;
private BoxCollider previewCollider;
private PlacedObjectData_v2 lastPlacedObjectData;
private PlayerMouseLook playerMouseLook;
private PlayerActivate playerActivate;
private HeadBobber decoratorHeadBobber;
private bool decoratorHeadBobberWasEnabled;
private Dictionary<Renderer, Material[]> editHighlightOriginalMaterials = new Dictionary<Renderer, Material[]>();
private List<Material> editHighlightMaterials = new List<Material>();
private Vector3 defaultPosition = new Vector3(0.0f, 0.1f, 2f);
private Vector3 lastPosition = Vector3.zero;
private Ray snapRay = new Ray();
private RaycastHit snapRayHit = new RaycastHit();
private bool editMode;
private int goHeight = 2;
private int goRotation = 0;
private int pages = 1;
private KeyCode hideWindowKey;
private bool mouselookToggle = false;
private bool colorPickerEnabled;
private bool spellRank;
private bool potionRank;
private bool itemRank;
private Dictionary<string, string> common = new Dictionary<string, string>()
{
{"-1", "Common" },
{"41100", "Chair 1 , Wide" },
{"41101", "Chair 1, Narrow" },
{"41102", "Chair w. Armrest" },
{"41103", "Chair 2, Wide" },
{"41122", "Throne, Narrow" },
{"41123", "Throne, Wide" },
{"41104", "Throne, Green" },
{"51100", "Chair, Red" },
{"51101", "Chair, Thin" },
{"41113", "Stool, Small" },
{"41114", "Stool, Large" },
{"41105", "Bench, Thick" },
{"41106", "Bench, Thin" },
{"41126", "Bench w Backrest" },
{"43307", "Bench, Park" },
{"41108", "Table 1" },
{"41109", "Table 2" },
{"41110", "Table 3" },
{"41111", "Table 4" },
{"41112", "Table 5" },
{"41130", "Table 6" },
{"41121", "Table 7" },
{"41000", "Large Bed" },
{"41001", "Small Bed" },
{"41002", "Small Bed w. Top" },
};
private Dictionary<string, string> containers = new Dictionary<string, string>()
{
{"-1", "Containers" },
{"41803", "Small Dresser" },
{"41802", "Small Cabinent" },
{"41051", "Small Cabinent w. Cab" },
{"41032", "Small Dresser w. Cab" },
{"41035", "Small Dresser w. Alch" },
{"41036", "Small Dresser w. Cloth" },
{"41037", "Small Dresser w. Misc" },
{"41800", "Wardrobe" },
{"41801", "Double Wardrobe" },
{"41030", "Shelves, Empty" },
{"41016", "Shelves, Books" },
{"41124", "Shelves, Keg and Bottles" },
{"41010", "Shelves, Clothes" },
{"41027", "Shelves, Misc" },
{"41041", "Shelves, Alchemy" },
{"41047", "Shelves, Books w Weapons" },
{"41045", "Shelves, Books w Misc" },
{"41821", "Small Crate 1" },
{"41824", "Small Crate 2" },
{"41826", "Medium Crate 1" },
{"41817", "Medium Crate 2" },
{"41833", "Large Crate 1" },
{"41811", "Chest 1" },
{"41812", "Chest 2" },
};
private Dictionary<string, string> lights = new Dictionary<string, string>()
{
{"-1", "Lights" },
{"210.27", "Lantern 1"},
{"210.24", "Lantern 1 w. Chain, Long" },
{"210.25", "Lantern 1 w. Chain, Medium" },
{"210.26", "Lantern 1 w. Chain, Short" },
{"210.22", "Lantern 2 w. Chain, Short" },
{"210.10", "Fancy Candle Chandolier, Unlit" },
{"210.9", "Fancy Candle Chandolier, Lit" },
{"210.16", "Torch 1" },
{"210.17", "Torch 2" },
{"210.18", "Torch 3" },
{"210.0", "Small Brazier" },
{"210.19", "Large Brazier" },
{"210.7", "Candle Chandolier, Unlit" },
{"210.23", "Candle Chandolier, Lit" },
{"210.2", "Skull Candle" },
{"210.3", "Candle" },
{"210.4", "Candle w. Base, Small" },
{"210.21", "Candle w. Base, Large" },
{"210.5", "Three Candles w. Base" },
{"210.20", "Tiki Torch" },
{"210.6", "Skull Tiki Torch" },
};
private Dictionary<string, string> wall = new Dictionary<string, string>()
{
{"-1", "Wall" },
{"51115", "Painting 1" },
{"51116", "Painting 2" },
{"51117", "Painting 3" },
{"51118", "Painting 4" },
{"51119", "Painting 5" },
{"51120", "Painting 6" },
{"42500", "Banner 1" },
{"42501", "Banner 2" },
{"42502", "Banner 3" },
{"42503", "Banner 4" },
{"42504", "Banner 5 " },
{"42505", "Banner 6 " },
{"42506", "Banner 7 " },
{"42507", "Banner 8 " },
{"42508", "Banner 9 " },
{"42509", "Banner 10 " },
{"42510", "Banner 11 " },
{"42511", "Banner 12 " },
{"42520", "Banner 13 " },
{"42521", "Banner 14" },
{"42522", "Banner 15" },
{"42523", "Banner 16" },
{"42532", "Banner 17" },
{"42533", "Banner 18" },
{"42534", "Banner 19" },
{"42535", "Banner 20" },
{"42536", "Tapestry 1" },
{"42537", "Tapestry 2" },
{"42538", "Tapestry 3" },
{"42539", "Tapestry 4" },
{"42540", "Tapestry 5" },
{"42541", "Tapestry 6" },
{"42542", "Tapestry 7" },
{"42543", "Tapestry 8" },
{"42544", "Tapestry 9" },
{"42545", "Tapestry 10" },
{"42546", "Tapestry 11" },
{"42547", "Tapestry 12" },
{"42548", "Tapestry 13" },
{"42549", "Tapestry 14" },
{"42550", "Tapestry 15" },
{"42551", "Tapestry 16" },
{"42552", "Tapestry 17" },
{"42553", "Tapestry 18" },
{"42554", "Tapestry 19" },
{"42555", "Tapestry 20" },
{"42556", "Tapestry 21" },
{"42557", "Tapestry 22" },
{"42558", "Tapestry 23" },
{"42559", "Tapestry 24" },
{"42560", "Tapestry 25" },
{"42567", "Tapestry 26" },
{"42568", "Tapestry 27" },
{"42569", "Tapestry 28" },
{"42570", "Tapestry 29" },
{"42571", "Tapestry 30" },
};
private Dictionary<string, string> pixel = new Dictionary<string, string>()
{
{"-1", "PIXEL" },
{"2000001001", "PIXEL 01" },
{"2000001002", "PIXEL 02" },
{"2000001003", "PIXEL 03" },
{"2000001004", "PIXEL 04" },
{"2000001005", "PIXEL 05" },
{"2000001006", "PIXEL 06" },
{"2000001007", "PIXEL 07" },
{"2000001008", "PIXEL 08" },
{"2000001009", "PIXEL 09" },
{"2000001010", "PIXEL 10" },
};
private Dictionary<string, string> library = new Dictionary<string, string>()
{
{"-1", "Library" },
{"211.1", "Quill and Ink" },
{"208.0", "Globe" },
{"208.1", "Magnifying Glass" },
{"209.0", "Three Books, Stacked" },
{"209.1", "Two Books, Stacked" },
{"209.2", "Book, Brown" },
{"209.3", "Book, Green" },
{"209.4", "Book, Green, Large" },
{"209.5", "a Scroll" },
{"209.6", "Stack of Scrolls" },
{"209.7", "Piece of Paper 1" },
{"209.8", "Piece of Paper 2" },
{"209.10", "Stack of Paper" },
{"216.40", "Scrolls w Books" },
{"209.11", "Stone Tablet 1, Brown" },
{"209.12", "Stone Tablet 1, Grey" },
{"209.13", "Stone Tablet 2, Brown" },
{"209.14", "Stone Tablet 2, Grey" },
{"209.15", "Stack of Stone Tablets" },
};
private Dictionary<string, string> misc1 = new Dictionary<string, string>()
{
{"-1", "Misc 1" },
{"208.4", "Telescope" },
{"208.3", "Weight Scales" },
{"208.5", "Handheld Mirror" },
{"208.6", "Hourglass" },
{"211.0", "Wrappings" },
{"211.3", "Dung" },
{"211.4", "Chain, Short" },
{"211.7", "Chain, Long" },
{"211.5", "Chains, Long" },
{"211.6", "Chains, Short and Long" },
{"211.47", "Bell" },
{"211.48", "Necklace" },
{"211.49", "Holy Water" },
{"211.50", "Talisman" },
{"211.56", "Finger" },
{"211.54", "a Baby" },
{"211.20", "Scarecrow" },
{"211.21", "Rocking Horse" },
{"211.22", "Noose" },
{"211.24", "Pipe, Short" },
{"211.25", "Pipes, Short" },
{"211.23", "Pipes, Long" },
{"200.11", "Pillow, White" },
{"200.13", "Pillow, Pink" },
{"200.19", "Wooden Bucket" },
{"205.0", "Wooden Barrel" },
{"205.8", "Basket, Small" },
{"205.9", "Basket, Large" },
{"205.10", "Basket of fish" },
{"211.9", "a Fish, Blue" },
{"211.8", "Pile of Fish, Blue" },
{"211.10", "a Fish, Grey" },
{"211.11", "Fish, Grey, Hanging" },
{"205.17", "Sack 1" },
{"205.19", "Sack 2" },
{"205.20", "Sack 3" },
{"205.21", "Chest 1" },
{"205.22", "Chest 2" },
{"205.23", "Chest 3" },
{"205.24", "Chest 4" },
{"205.25", "Chests 1"},
{"205.26", "Chests 2" },
};
private Dictionary<string, string> misc2 = new Dictionary<string, string>()
{
{"-1", "Misc 2" },
{"41009", "Spinning Wheel" },
{"41120", "Organ" },
{"41116", "Fireplace 1" },
{"41117", "Fireplace 2" },
{"2000000003", "Fireplace 3" },
{"41118", "Anvil" },
{"51111", "Altar" },
{"74224", "Sword 1" },
{"74227", "Sword 2" },
{"74095", "Sword 3" },
{"74225", "Axe" },
{"74219", "Sickle" },
{"74221", "Crossbow" },
{"99800", "Arrow" },
{"74226", "Suit of Armor" },
{"74231", "Marble Diamond" },
{"74230", "Decoration" },
{"41700", "Stocks" },
{"41300", "Torture 1" },
{"41301", "Torture 2" },
{"41302", "Torture 3" },
{"41303", "Torture 4" },
{"41312", "Cage" },
{"41209", "Water Trough, Filled" },
{"41210", "Water Trough, Empty" },
{"41220", "Fountain 1" },
{"41222", "Fountain 2" },
{"41239", "Cart" },
{"41238", "Divider" },
{"21003", "Fence, Wood" },
{"60606", "Gate" },
{"41125", "Wooden Stand" },
{"62315", "Column, Marble" },
{"61127", "Wooded Post" },
{"41409", "Ladder" },
{"61132", "Steering Wheel" },
{"41020", "Podium 1" },
{"41021", "Podium 2" },
{"41739", "Sign" },
{"41703", "Booth" },
{"60719", "Rock 1" },
{"60720", "Rock 2" },
{"60712", "Rock 3" },
{"60612", "Rock 4" },
{"60715", "Rock 5" },
{"60716", "Rock 6" },
{"60613", "Rock 7" }
};
private Dictionary<string, string> alchemy = new Dictionary<string, string>()
{
{"-1", "Alchemy" },
{"205.31", "Colorful Bottles" },
{"205.11", "Bottle 1, Empty" },
{"205.12", "Bottle 1, Half-full" },
{"205.13", "Bottle 1, Full" },
{"211.2",  "Bottle 2, Empty" },
{"205.32", "Bottle, Blue" },
{"205.33", "Bottle, Pink" },
{"205.34", "Bottle, Orange" },
{"205.35", "Bottle, Green" },
{"205.1", "Flask w Yellow Liquid" },
{"208.2", "Flask over Candle 1" },
{"253.41", "Flask over Candle 2" },
{"205.3", "Empty Bottle" },
{"205.2", "Bottle of Eyes" },
{"205.4", "Bottle w Brain" },
{"205.5", "Bottle w Orange Liquid" },
{"205.7", "Bottle with Purple Liquid" },
{"205.6", "Bottle w Red Liquid" },
{"205.43", "Small Bottle w Green Liquid" },
{"254.34", "Flask w Red Liquid 1, Corked" },
{"254.36", "Flask w Red Liquid 2, Corked" },
{"254.49", "Flask w Black Liquid, Corked" },
{"254.0", "Ruby" },
{"254.1", "Emerald" },
{"254.2", "Sapphire" },
{"254.3", "Diamond" },
{"254.4", "Jade" },
{"254.5", "Turqoise" },
{"254.6", "Pearl" },
{"254.7", "Malachite" },
{"254.8", "Amber" },
{"254.9", "Twigs" },
{"254.10", "Green Leaves" },
{"254.11", "Red Flowers" },
{"254.12", "Yellow Flowers" },
{"254.13", "Root Tendrils" },
{"254.14", "Root Bulb" },
{"254.15", "Pine Branch" },
{"254.16", "Green Berries" },
{"254.17", "Red Berries" },
{"254.18", "Yellow Berries" },
{"254.19", "Clover" },
{"254.20", "Gingko Leaves" },
{"254.21", "Bamboo" },
{"254.22", "Palm" },
{"254.23", "Aloe" },
{"254.24", "Fig" },
{"254.25", "Cactus" },
{"254.26", "Red Rose" },
{"254.27", "Yellow Rose" },
{"254.28", "Black Rose" },
{"254.29", "White Rose" },
{"254.30", "Red Poppy" },
{"254.31", "Black Poppy" },
{"254.32", "Golden Poppy" },
{"254.33", "White Poppy" },
{"254.35", "Ingredient" },
{"254.37", "Fairy Dragon's Scales" },
{"254.38", "Giant Scorpion Stinger" },
{"254.39", "Small Scorpion Stinger" },
{"254.40", "Ingredient 2" },
{"254.41", "Mummy Wrappings" },
{"254.42", "Wereboar's Tusk" },
{"254.43", "Unicorn Horn" },
{"254.44", "Ectoplasm" },
{"254.45", "Ghoul's Tongue" },
{"254.46", "Spider's Venom" },
{"254.47", "Wraith Essence" },
{"254.48", "Dragon's Scales" },
{"254.50", "Basilisk's Eye" },
{"254.51", "Daedra's Heart" },
{"254.52", "Ichor/Rain Water/Snake Venom" },
{"254.53", "Gryphon's Feather" },
{"254.54", "Gorgon Snake" },
{"254.55", "Nymph Hair" },
{"254.56", "Holy Relic" },
{"254.57", "Big Tooth" },
{"254.58", "Medium Tooth" },
{"254.59", "Small Tooth" },
{"254.61", "Mercury" },
{"254.62", "Gold" },
{"254.63", "Iron" },
{"254.64", "Tin" },
{"254.65", "Silver/Platinum" },
{"254.66", "Brass/Copper" },
{"254.67", "Sulphur" },
{"254.68", "Ingredient 3" },
{"254.69", "Ingredient 4" },
{"254.70", "Ivory" },
{"254.71", "Ingredient 5" },
};
private Dictionary<string, string> bio = new Dictionary<string, string>()
{
{"-1", "Bio" },
{"201.0", "Horse, Brown" },
{"201.1", "Horse, Black" },
{"201.2", "Camel" },
{"201.3", "Cow 1" },
{"201.4", "Cow 2" },
{"201.5", "Pig 1" },
{"201.6", "Pig, 2" },
{"201.7", "Cat 1" },
{"201.8", "Cat 2" },
{"201.9", "Dog 1" },
{"201.10", "Dog 2" },
{"201.11", "Seagull" },
{"205.37", "Plant 1" },
{"205.38", "Plant 2" },
{"205.39", "Plant 3" },
{"205.40", "Plant 4" },
{"213.0","Orange" },
{"213.1","Apple" },
{"213.2","Potted Plant 1" },
{"213.4","Potted Plant 2" },
{"213.5","Potted Plant 3" },
{"213.6","Potted Plant 4" },
{"213.13","Potted Plant, Hanging 1" },
{"213.14","Potted Plant, Hannging 2" },
{"213.3","Plant 1" },
{"213.15","Plant 2" },
{"213.16","Plant 3" },
{"213.17","Plant 4" },
{"213.7","Vine" },
{"213.8","Vines 1" },
{"213.9","Vines 2" },
{"213.10","Vines 3" },
{"213.11","Logs 1" },
{"213.12","Logs 2" },
{"41735", "Large Log __RICOS_CONTINUE__