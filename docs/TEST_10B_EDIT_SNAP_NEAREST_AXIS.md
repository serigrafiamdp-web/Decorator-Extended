# DECORATOR TEST 10B — EDIT SNAP NEAREST AXIS

Status: **PASS**

Base:
- **TEST 10A FINE DIAGONAL ROTATION = PASS**
- **VICE TEST 08C bezel MIN = functional PASS**

## Problem

In Edit mode, checking Snap reused the placement pipeline:

- `SetObjectHeight(goHeight)`
- `SetObjectPosition()`

That code raycasts from the player and recalculates position, so an already placed object could jump away or disappear from the preview.

## TEST 10B behavior

When `editMode == true` and Snap is checked:

- `localPosition` is never recalculated.
- X rotation is forced to 0.
- Z rotation is forced to 0.
- Y rotation is rounded to the nearest cardinal axis: 0 / 90 / 180 / 270 degrees.
- Selecting another object clears the Snap checkbox so the next object is not modified automatically.
- Accept persists the adjusted transform through the existing `GetData()` path.

Outside Edit mode, Snap keeps its original placement/surface/raycast behavior.

## Source

Branch: `test/edit-snap-nearest-axis`

Functional source commit: `50860bdf4c5306aa123d465a55050098d67e0968`

The `DecoratorWindow.cs` byte length remains **63,571 bytes**, matching TEST 10A. The embedded UnityFS source body also remains byte-stable.

## Runtime binary

`decorator.dfmod`

- Size: **27,100 bytes**
- SHA-256: `1e3274d8063b91a9ce8220170ca929e1f6839c93c27d0b1e6e736e6c5864e968`
- Internal UnityFS node size: **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10B_EDIT_SNAP_NEAREST_AXIS.zip`

- SHA-256: `c5f3a82a5434d42ccd7ce205d65320b3389069590f17ed47ec03dbf379dd0536`

## PASS criteria

1. DFU starts normally.
2. Select an already placed object in Edit.
3. Position it approximately where wanted.
4. Check Snap.
5. The object remains in exactly the same position.
6. It aligns to the nearest cardinal Y rotation with X/Z = 0.
7. Accept saves that adjusted transform.
8. Selecting another object starts with Snap unchecked.
9. Snap for new object placement remains unchanged.


Promoted to MASTER on 2026-10-09.
