# Building Decorator Extended

## Source of truth

For new development, edit the repository source, not an existing `.dfmod` binary.

Primary editable files:

- `Scripts/DecoratorHelper.cs`
- `Scripts/DecoratorManager.cs`
- `Scripts/DecoratorModLoader.cs`
- `Scripts/DecoratorWindow.cs`
- `decorator.dfmod.json`
- `modsettings.json`

The immutable current PASS binary is documented in `docs/MASTER_PASS_BINARY.md` and archived under `tools/MASTER_PASS/`.

## Build environment

The validated PASS dfmod is a UnityFS bundle built with Unity **2019.4.40f1** according to its bundle header.

Build inside a Daggerfall Unity Unity project that contains the DFU mod-building tooling. Keep the Decorator project layout expected by `decorator.dfmod.json`, i.e. the mod files under the Decorator mod folder and the same script filenames.

The original mod metadata and GUID are retained unless a deliberate compatibility-breaking change is being made.

## Development workflow

1. Start from the latest validated PASS commit on this fork.
2. Create a test branch or isolated test change.
3. Modify the relevant file(s) under `Scripts/`.
4. Build a new `decorator.dfmod` with the Daggerfall Unity mod builder.
5. Package only the required runtime files for the test.
6. Run the existing PASS/FAIL validation in Daggerfall Unity.
7. If FAIL, do not promote the binary or source to the master baseline.
8. If PASS, commit the exact source used to build it, update `docs/PROJECT_STATE.md`, and record the new binary size/SHA-256.
9. When a new MASTER is promoted, archive its exact dfmod as a new byte-level reference. Do not overwrite historical PASS evidence silently.

## Important rule

**Do not patch the `.dfmod` directly for normal development.**

The normal chain is now:

`GitHub source -> DFU/Unity build -> decorator.dfmod TEST -> PASS/FAIL -> promote PASS source + binary identity`

The archived current PASS can always be reconstructed with:

```bash
python tools/MASTER_PASS/rebuild_master_pass.py
```
