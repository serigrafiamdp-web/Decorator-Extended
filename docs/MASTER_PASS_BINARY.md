# Exact MASTER PASS binary

The byte-level authority for the current validated Decorator Extended baseline is the `decorator.dfmod` contained in:

- `RICOS_DECORATOR_V2_MASTER_08_OCT_2026.zip`
- Runtime validation source: `RICOS_DECORATOR_UI_TEST_09_LIGHT_BELOW_SCALE.zip` = PASS

Both packages contain the exact same `decorator.dfmod`.

## Binary identity

- Format: UnityFS AssetBundle
- Unity header: `2019.4.40f1`
- Size: **27,143 bytes**
- SHA-256: `4f18fa6fd57187de1bfd66a66110729b93f84060a5149295bee72831b58d882c`

The older `RICOS DECORATOR V2 MASTER.zip` contains a different 26,354-byte dfmod with SHA-256
`f7f39ded3924af9d67d767faf48bfc73d259ffb964fa710ddaf91995fd93dbbe`.
It is historical and is **not** the authority for the current V2 PASS baseline.

## Source identity

The four C# files packaged beside the PASS dfmod were checked using Git blob identity and match the files currently committed under `Scripts/` byte-for-byte:

| File | Git blob SHA-1 |
| --- | --- |
| `DecoratorHelper.cs` | `0395d4ba80c3ad57d5f3454da83de0f3acd14f03` |
| `DecoratorManager.cs` | `eb3520290862e9383e45a9eab39b59ec06769359` |
| `DecoratorModLoader.cs` | `b8c24df935fefc12cabb434a04893a1606a59834` |
| `DecoratorWindow.cs` | `7315e2c90973f44995e3dd35d726ef9046eb3d1d` |

Unlike DF-AMP, this dfmod does not use a separately archived .NET core assembly as its authority. The dfmod itself is the binary authority and carries the mod assets/scripts inside the UnityFS bundle.

## Lossless archive

The exact PASS dfmod is preserved losslessly as Base64 at:

- `tools/MASTER_PASS/decorator-master-pass.b64`

Reconstruct and verify it with:

```bash
python tools/MASTER_PASS/rebuild_master_pass.py
```

The script refuses to produce a PASS file if size or SHA-256 does not match the values above.

Do not edit the Base64 archive. Future development happens in `Scripts/`; the archived PASS binary is a rollback/reference artifact.
