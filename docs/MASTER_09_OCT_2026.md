# MASTER promotion — 09 OCT 2026

Promoted baseline: **TEST 10G SHIFT FINE HORIZONTAL FIX = PASS**

This promotion consolidates the accepted transform-control work completed after the 08 OCT V2 MASTER.

## Promoted behavior

- Fine diagonal rotation.
- Nearest-cardinal Snap in Edit.
- Unified Snap for new and edited objects.
- New preview appears in front of the camera and then anchors to the world.
- Player movement no longer drags an unconfirmed preview.
- Translation arrows are camera-relative.
- Left/Right normal movement uses 0.10 units.
- Shift + Left/Right uses fine 0.02 units.
- Existing placed decorations load normally.

## Excluded

- TEST 10F is explicitly excluded and retained only as a critical FAIL record.

## Runtime binary

- Size: **27,077 bytes**
- SHA-256: `d13057de718f3f396a8e2ba98972c6d4abbecef2c42291db49ae14aa7b046ade`
- Validated package: `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip`

## Promotion rule

Future work branches from this MASTER, never from TEST 10F.
