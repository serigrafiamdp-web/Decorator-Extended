# DECORATOR TEST 10D — ANCHORED NEW PREVIEW

Status: **PASS**

Base:
- TEST 10A fine diagonal rotation = PASS
- TEST 10B edit Snap nearest axis = functional PASS
- TEST 10C universal nearest-axis Snap behavior retained
- VICE bezel MIN helper retained

## Goal

Make a newly selected object behave like an already selected Edit object after its initial appearance.

## New-preview contract

When a new item is selected from the list:

1. It is created using the Player only for the initial placement calculation.
2. A one-time position Snap is calculated from the real MainCamera position/forward.
3. It is normalized to the nearest cardinal rotation.
4. It is immediately reparented to the Decorator Parent using `SetParent(Parent, true)`.
5. Its world transform is preserved during that reparent.
6. From that point onward, player movement or rotation must not move the preview.
7. Transform controls move the item independently.
8. Accept persists the final transform through the existing Parent-relative save path.

## Source

Branch: `test/anchored-new-preview`

Functional source commit: `a46ae7b04ec72cb93c32c58e8fac2d888967942b`

Git blob SHA for `Scripts/DecoratorWindow.cs`:
`805a360d5469a8e4105c566f0fe4e4726ed760a7`

Source SHA-256:
`a0058ad9a8a0f212acbd1aaf5c6a56c67e300dfa0af1600788e5ee162d728fa3`

The file remains exactly **63,571 bytes** for byte-stable UnityFS patching.

## Runtime binary

`decorator.dfmod`

- Size: **26,929 bytes**
- SHA-256: `6419c4c637201fdc533076ddf185e4403ffb3300dbbb22bbf1709ce7b0da541b`
- Internal UnityFS node: **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10D_ANCHORED_NEW_PREVIEW.zip`

- SHA-256: `3250caf7e50c2457c33daba5efbb5be84c2050ad7e34d6599db94fcda603aa45`

## PASS criteria

1. DFU starts normally.
2. Selecting a new object places it ahead of the camera/player view.
3. Initial position uses the closest one-time Snap ahead.
4. Initial rotation is straight/cardinal.
5. Walking or turning after appearance does not drag the preview.
6. Fine translation and diagonal rotation continue to work.
7. Accept saves the final location.
8. Existing Edit behavior is unchanged.


Promoted to MASTER on 2026-10-09.
