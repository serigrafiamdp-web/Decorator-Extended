# DECORATOR TEST 10E — CAMERA-RELATIVE TRANSLATION

Status: **PASS**

Base: **TEST 10D anchored new preview**.

## Problem

After the new preview became anchored to the world, normal translation still used different local-axis logic in NEW and EDIT modes.

That made Left / Right / Forward / Back feel spatially wrong depending on player/camera orientation.

## TEST 10E behavior

Normal translation is now relative to the current MainCamera orientation projected onto the horizontal plane:

- Up = camera forward
- Down = camera backward
- Left = camera left
- Right = camera right
- Step = 0.02 units per click
- NEW and EDIT share the same spatial logic

Unchanged:

- SHIFT + Up/Down keeps the previous behavior
- Fine diagonal rotations remain unchanged
- Snap remains unchanged
- New-preview anchoring remains unchanged
- VICE bezel MIN remains included

## Source

Branch: `test/camera-relative-translation`

Functional source commit: `0090c4bf7912434643648b00a41ffda800a01d07`

Git blob SHA for `Scripts/DecoratorWindow.cs`:
`9d865906d7dce30bac9ef27b1b727ed19347854e`

Source SHA-256:
`860a88ce80c0f873a38aa35bfff492e2c4ad3fb3bd2157bb25cf5df4ba3c79bb`

The source remains exactly **63,571 bytes**.

## Runtime binary

`decorator.dfmod`

- Size: **27,032 bytes**
- SHA-256: `ec3386b5b206b4846d1938e42d10d6543e7cc96b4acfe937a14275c2d2d9f970`
- Internal UnityFS node remains **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10E_CAMERA_RELATIVE_TRANSLATION.zip`

- SHA-256: `b3bd6ed91947b83b701ce640f991ebaf9b222fe584914a1aae4bee72d2570340`

## PASS criteria

1. DFU starts normally.
2. With a new object anchored in front, Up moves it forward from the current camera viewpoint.
3. Down moves it backward.
4. Left and Right always match the screen/camera sides.
5. Rotate/walk around the object and repeat: directions remain intuitive from the new viewing angle.
6. Same behavior in Edit mode.
7. SHIFT Up/Down remains unchanged.
8. Rotations, Snap, Accept, and VICE MIN remain unchanged.


Promoted to MASTER on 2026-10-09.
