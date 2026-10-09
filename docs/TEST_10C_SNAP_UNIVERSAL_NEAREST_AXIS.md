# DECORATOR TEST 10C — SNAP UNIVERSAL NEAREST AXIS

Status: **PASS**

Base:
- TEST 10A fine diagonal rotation = PASS
- TEST 10B edit Snap nearest axis = functional PASS
- VICE TEST 08C bezel MIN = functional PASS

## Goal

Make Snap behave the same before and after an object is placed.

## New Snap contract

When Snap is checked in either NEW/PLACE mode or EDIT mode:

- The object's position is preserved exactly where the user placed it.
- Snap does **not** call `SetObjectPosition()` or `SetObjectHeight()`.
- Local X rotation is forced to 0.
- Local Z rotation is forced to 0.
- Local Y rotation is rounded to the nearest cardinal axis: 0 / 90 / 180 / 270 degrees.
- While Snap remains active, Rotate Left / Right moves through the cardinal axes in 90-degree steps.
- Accept persists the resulting position and rotation.

## Source

Branch: `test/unified-snap-nearest-axis`

Functional source commit: `877eabb05643c5df844dd43509d1c2950a289e69`

`DecoratorWindow.cs` remains **63,571 bytes** for byte-stable UnityFS patching.

## Runtime binary

`decorator.dfmod`

- Size: **27,042 bytes**
- SHA-256: `b9b21868e86dfaca693094968bfc056a6da9767fbd6d8fd608abc00ff69480f3`
- Internal UnityFS node remains **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10C_SNAP_UNIVERSAL_NEAREST_AXIS.zip`

- SHA-256: `d8733e95467ac935c86b09cff48eb36d4d32220902f54fab2c3a51940191f079`

## PASS criteria

1. DFU starts normally.
2. Choose a new object from the list.
3. Move it to the desired position and leave it slightly rotated.
4. Check Snap.
5. The object does not move from that position.
6. It aligns to the nearest cardinal axis.
7. Accept saves that transform.
8. Repeat on an already placed object in Edit mode.
9. With Snap active, Rotate Left / Right advances in 90-degree steps.
10. VICE bezel MIN remains functional.


Promoted to MASTER on 2026-10-09.
