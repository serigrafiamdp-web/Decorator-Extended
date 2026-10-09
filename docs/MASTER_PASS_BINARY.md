# Current MASTER PASS binary

The current validated Decorator Extended runtime baseline is the `decorator.dfmod` contained in:

- `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip`
- Runtime status: **PASS**
- Promotion date: **2026-10-09**

## Current binary identity

- Format: UnityFS AssetBundle
- Unity header lineage: `2019.4.40f1`
- Size: **27,077 bytes**
- SHA-256: `d13057de718f3f396a8e2ba98972c6d4abbecef2c42291db49ae14aa7b046ade`
- Internal UnityFS uncompressed node used by the validated patch workflow: **130,404 bytes**

## Current source identity

The source promoted with the 10G PASS baseline is:

| File | Git blob SHA-1 |
| --- | --- |
| `DecoratorHelper.cs` | `0395d4ba80c3ad57d5f3454da83de0f3acd14f03` |
| `DecoratorManager.cs` | `eb3520290862e9383e45a9eab39b59ec06769359` |
| `DecoratorModLoader.cs` | `b8c24df935fefc12cabb434a04893a1606a59834` |
| `DecoratorWindow.cs` | `f37403827f31658a957a007241d0d07da307bfe6` |

## Historical V2 rollback binary

The previous **RICOS DECORATOR V2 MASTER — 08 OCT 2026** remains historical rollback evidence.

- Size: **27,143 bytes**
- SHA-256: `4f18fa6fd57187de1bfd66a66110729b93f84060a5149295bee72831b58d882c`
- Existing Git archive: `tools/MASTER_PASS/decorator-master-pass.b64`
- Existing verifier: `tools/MASTER_PASS/rebuild_master_pass.py`

That archive reconstructs the **historical V2 baseline**, not the current 10G runtime.

## Authority rule

For the current MASTER:

1. `Scripts/` is the editable source authority.
2. The current PASS binary identity is the 27,077-byte / SHA-256 value above.
3. The validated runtime package is `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip`.
4. The older Base64 archive is retained only for rollback and forensic comparison.

Do not mistake the historical V2 Base64 archive for the current 10G runtime binary.
