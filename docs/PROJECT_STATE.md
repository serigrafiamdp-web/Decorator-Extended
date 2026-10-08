# Decorator Extended — Current PASS State

**Date:** 2026-10-08  
**Current master baseline:** RICOS DECORATOR V2 MASTER  
**Runtime baseline:** RICOS_DECORATOR_UI_TEST_09_LIGHT_BELOW_SCALE = PASS

## Validated contracts

- Fine object movement: **0.02 units per click**.
- Original Emulator / VICE integration remains functional.
- Emulator 2 / FCEUX: persistent flag, ALT+M hide/show, ALT+Q exit, and coordination with VICE.
- Exterior placement and persistence validated.
- Public interiors validated without replacing vanilla NPC/services.
- FIREPLACE 3 custom virtual slot architecture validated.
- PIXEL custom slots retained.
- Right-side Decorator UI is transparent and borderless.
- Delete is positioned below Reset.
- Snap remains visible while Edit mode is active.
- Player camera drift while walking with an unconfirmed preview item is fixed by temporarily disabling HeadBobber while Decorator owns the UI.
- A placed object selected in Edit mode receives a temporary yellow translucent highlight and restores its original materials afterward.
- UI font sizing is normalized.
- Light submenu is positioned below the Scale submenu footprint to prevent overlap.

## Workflow

1. Branch conservatively from the latest PASS state.
2. Test one change at a time.
3. Mark each build PASS or FAIL.
4. Promote only PASS builds.
5. Keep source, project state, credits, and release notes in GitHub.

## Credits

Original mod: **Decorator by Kaedius / KDS-KDS**  
Extended modifications: **DECORATOR EXTENDED BY RICO**
