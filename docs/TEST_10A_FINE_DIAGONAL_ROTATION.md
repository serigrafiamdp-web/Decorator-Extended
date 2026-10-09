# DECORATOR TEST 10A — FINE DIAGONAL ROTATION

Status: **PENDING PASS/FAIL**

Base:
- `RICOS_DECORATOR_V2_MASTER_08_OCT_2026`
- VICE bezel **MIN** helper from TEST 08C retained in the test ZIP.

## Single Decorator change

The four diagonal transform controls are refined:

- Normal click: **1 degree per click**
- Shift + click: **5 degrees per click**
- Straight movement remains **0.02 units per click**
- Snap behavior remains unchanged

Only eight source lines change in `Scripts/DecoratorWindow.cs`.

## Source

Branch: `test/fine-diagonal-rotation`

Commits:
- `35b31409145fedc49a490f88cb3d0b08838472b1`
- `17f6d1c3a66fdb9439613f40a729edc56a0ce8ba`

The Shift literals use `5.00f` / `-5.00f` intentionally to preserve byte length versus the previous `10.0f` / `-10.0f` values in the UnityFS source payload.

## Runtime binary

`decorator.dfmod`

- Size: **27,327 bytes**
- SHA-256: `72fa8533ff9e6e12babf251127c9b932cadd2de2db0fda02309394bda6e82855`
- Internal UnityFS node size remains **130,404 bytes**

## Test ZIP

`DECORATOR_TEST_10A_FINE_DIAGONAL_ROTATION.zip`

- SHA-256: `c3413f11cad9d98cb9b8f82cf5575de5706c6c5041dd333f61894e1f638d0932`

## Validate

PASS only if:

1. DFU starts normally.
2. All four diagonal controls move in fine 1-degree steps.
3. Shift + diagonal moves in 5-degree steps.
4. Straight arrows still move 0.02 units per click.
5. Snap behavior is unchanged.
6. VICE bezel MIN remains functional.
