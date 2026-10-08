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

Current validated baseline: **RICOS DECORATOR V2 MASTER — 08 OCT 2026**, promoted from **UI TEST 09 = PASS**.

Development follows a PASS/FAIL workflow. Only validated changes are promoted to the current master baseline.


## Source and PASS authority

The current editable source under `Scripts/` has been verified byte-for-byte against the source packaged with the validated V2 MASTER.

The exact current PASS `decorator.dfmod` is preserved losslessly under `tools/MASTER_PASS/`.

- Binary details: `docs/MASTER_PASS_BINARY.md`
- Build workflow: `docs/BUILD.md`
- External runtime assets: `docs/RUNTIME_ASSETS.md`

Normal development is now source-first: edit C# -> build dfmod -> PASS/FAIL -> promote only PASS.
