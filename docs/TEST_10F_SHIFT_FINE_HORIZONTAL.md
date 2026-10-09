# DECORATOR TEST 10F — SHIFT FINE HORIZONTAL

Status: **PENDING PASS/FAIL**

Base: **TEST 10E CAMERA-RELATIVE TRANSLATION = PASS**

## Change

Left / Right movement keeps the camera-relative orientation validated in TEST 10E, but now has two speeds:

- Normal Left/Right: **0.10 units per click**
- Shift + Left/Right: **0.02 units per click**

## Unchanged

- Up / Down behavior
- Shift + Up/Down vertical movement
- Fine diagonal rotation
- Snap behavior
- Anchored new preview
- Accept/save behavior
- VICE bezel MIN

## Source

Branch: `test/shift-fine-horizontal`

Functional commit: `406d4a4d2689e0b007c558cdbba3f6c36847ef70`

`Scripts/DecoratorWindow.cs`
- Git blob: `7ad4a072bd134d718c329a480c1b40232f940072`
- SHA-256: `b1ed8350598a404af50aca0e9448a05d3736b6d4c3c8d813a577f43b57d06281`
- Size: **63,571 bytes**

## Runtime

`Mods/decorator.dfmod`
- Size: **27,072 bytes**
- SHA-256: `f51d52e07ab78bb3c21d0d43d041e927ca4dd89d88fb28e483a280e7f99c5346`
- UnityFS uncompressed node: **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10F_SHIFT_FINE_HORIZONTAL.zip`
- SHA-256: `49ea552cb22dd5670fd291a257f412097d92e555f1a2725eda84ade0424269fa`

## PASS criteria

1. Left/Right remain spatially correct relative to the current camera.
2. Without Shift they move noticeably faster at 0.10.
3. Holding Shift returns to the fine 0.02 step.
4. Behavior is identical for new anchored previews and Edit-selected objects.
5. Up/Down, vertical Shift movement, rotations, Snap and Accept remain unchanged.
