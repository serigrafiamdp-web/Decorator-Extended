# Decorator Extended — Current PASS State

**Date:** 2026-10-09  
**Current master baseline:** DECORATOR EXTENDED MASTER — 09 OCT 2026  
**Runtime baseline:** TEST 10G SHIFT FINE HORIZONTAL FIX = PASS

## Validated contracts

- Straight fine movement baseline remains **0.02 units**.
- Left/Right movement is camera-relative.
- Left/Right normal movement: **0.10 units per click**.
- Shift + Left/Right: **0.02 units per click**.
- Diagonal rotation: **1 degree per click**.
- Shift + diagonal rotation: **5 degrees per click**.
- Snap aligns rotation to the nearest cardinal axis: 0 / 90 / 180 / 270.
- In Edit mode, Snap preserves the object's placed position.
- Snap behavior is unified for new and edited objects.
- A new preview is initially positioned in front of the camera, then reparented to the Decorator world Parent so player movement no longer drags the preview.
- Translation arrows use the current camera viewpoint, so Left/Right/Forward/Back remain spatially intuitive while moving around an object.
- Existing placed decorations load correctly in TEST 10G.
- TEST 10F is recorded as a critical FAIL and is not part of the baseline.
- Original Emulator / VICE integration remains functional.
- VICE bezel MIN helper remains retained in the validated runtime package.
- Emulator 2 / FCEUX persistence and emulator coordination remain retained.
- Exterior placement/persistence remains retained.
- Public interiors remain retained without replacing vanilla NPC/services.
- FIREPLACE 3 custom slot remains retained.
- PIXEL custom slots remain retained.
- Right-side transparent UI, Delete/Reset layout, Snap visibility, HeadBobber handling and Edit highlight remain retained.

## Current runtime binary identity

`decorator.dfmod`

- Size: **27,077 bytes**
- SHA-256: `d13057de718f3f396a8e2ba98972c6d4abbecef2c42291db49ae14aa7b046ade`
- Validated package: `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip`

## Current source identity

| File | Git blob SHA-1 |
| --- | --- |
| `Scripts/DecoratorHelper.cs` | `0395d4ba80c3ad57d5f3454da83de0f3acd14f03` |
| `Scripts/DecoratorManager.cs` | `eb3520290862e9383e45a9eab39b59ec06769359` |
| `Scripts/DecoratorModLoader.cs` | `b8c24df935fefc12cabb434a04893a1606a59834` |
| `Scripts/DecoratorWindow.cs` | `f37403827f31658a957a007241d0d07da307bfe6` |

## PASS chain promoted

- TEST 10A — fine diagonal rotation = PASS
- TEST 10B — Edit Snap nearest axis = PASS
- TEST 10C — universal nearest-axis Snap = PASS
- TEST 10D — anchored new preview = PASS
- TEST 10E — camera-relative translation = PASS
- TEST 10F — Shift fine horizontal = **FAIL CRITICAL**
- TEST 10G — Shift fine horizontal fix = PASS

## Workflow

1. Branch from the latest PASS state.
2. Change one behavior at a time.
3. Test in runtime.
4. Record PASS or FAIL.
5. Promote only PASS source.
6. Never use a FAIL branch as a future base.
7. Keep binary identity and runtime package provenance recorded for every promoted MASTER.

## Historical rollback

The prior **RICOS DECORATOR V2 MASTER — 08 OCT 2026** remains historical rollback evidence.

Its dfmod identity was:

- Size: **27,143 bytes**
- SHA-256: `4f18fa6fd57187de1bfd66a66110729b93f84060a5149295bee72831b58d882c`

It is no longer the current master baseline.
