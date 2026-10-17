# TEST 11A — WEB launcher (UNTESTED)

Base: MASTER 09 OCT 2026 / TEST 10G PASS. Branch: `test/web-launch-11a`.

Changes:
- Checkbox `WEB` beneath Emulator / Emulator 2 in the Decorator transform panel.
- New `isWeb` flag on `PlacedObjectData_v2`, round-tripped through `PlacedObject.SetData/GetData`.
- Clicking a WEB-configured object while the game HUD is active and the mouse cursor is released invokes the OS default browser using `ProcessStartInfo.UseShellExecute = true`.
- Fixed destination: https://serigrafiamdp-web.github.io/RICOS-C64-MOD-JAMES-C64-WEB-EMULATOR-/c64/
- Emulator and Emulator 2 behavior unchanged; checkbox options are mutually exclusive.

Validation checklist (all PENDING): build with Daggerfall Unity 1.1.1 mod environment; place an object and check WEB; save/load; activate with ENTER + left click; verify default browser URL; verify Emulator / Emulator 2 still function. No binary was built or verified in this branch. Do not promote to MASTER until PASS.
