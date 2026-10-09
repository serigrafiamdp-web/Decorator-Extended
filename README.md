# Decorator Extended

Unofficial extended fork of **Decorator** for Daggerfall Unity.

## Credits

- **Original mod:** Decorator
- **Original author:** Kaedius / KDS-KDS
- **Original repository:** KDS-KDS/Decorator
- **License:** MIT
- **Extended modifications:** **DECORATOR EXTENDED BY RICO**

This fork is developed independently. The original repository remains unchanged unless a separate pull request is explicitly opened and accepted by the original maintainer.

## Current development status

Current validated baseline: **DECORATOR EXTENDED MASTER — 09 OCT 2026**, promoted from **TEST 10G = PASS**.

Development follows a PASS/FAIL workflow. Only validated changes are promoted to the current master baseline.

### Current validated behavior

- Fine straight movement baseline: **0.02 units**.
- Camera-relative horizontal/world-plane translation.
- Left/Right: **0.10 normal**, **0.02 with Shift**.
- Fine diagonal rotations: **1 degree normal**, **5 degrees with Shift**.
- Snap aligns to the nearest cardinal axis without unexpectedly moving an edited object.
- Snap behavior is unified for new and edited objects.
- New previews appear in front of the camera, then become anchored to the world instead of following the player.
- Existing placed decorations load normally with the 10G PASS build.
- VICE bezel MIN runtime helper remains part of the validated runtime package.
- Emulator/FCEUX coordination, exterior persistence, public interiors, FIREPLACE 3 and PIXEL slots remain retained.

## Source and PASS authority

The editable source under `Scripts/` is the current development authority.

Current validated runtime binary identity:

- `decorator.dfmod` size: **27,077 bytes**
- SHA-256: `d13057de718f3f396a8e2ba98972c6d4abbecef2c42291db49ae14aa7b046ade`
- Runtime validation package: `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip` = PASS

The older V2 binary archive under `tools/MASTER_PASS/` is retained as historical rollback evidence and is no longer the current runtime authority.

- Current project state: `docs/PROJECT_STATE.md`
- Binary details: `docs/MASTER_PASS_BINARY.md`
- Build workflow: `docs/BUILD.md`
- External runtime assets: `docs/RUNTIME_ASSETS.md`

Normal development remains source-first:

`GitHub source -> build dfmod -> PASS/FAIL -> promote only PASS`
