# DECORATOR TEST 10G — SHIFT FINE HORIZONTAL FIX

Status: **PASS**

Base: **TEST 10E CAMERA-RELATIVE TRANSLATION = PASS**

TEST 10F is **FAIL CRITICAL** and is not used as a base.

## Root cause fixed

10F used a compact ternary containing `?.02f`, which can be tokenized as C# null-conditional operator `?.`. The corrected expression is explicit:

`? 0.02f : 0.10f`

## Intended behavior

- Left/Right without Shift: **0.10 units per click**
- Shift + Left/Right: **0.02 units per click**
- Camera-relative direction from TEST 10E is preserved.

All other controls and persistence paths remain unchanged.

Functional source commit: `288999c459ad2ceaf1e8d9d41f13a49c639107f6`
Branch: `test/shift-fine-horizontal-fix`

Runtime `decorator.dfmod`:
- SHA-256: `d13057de718f3f396a8e2ba98972c6d4abbecef2c42291db49ae14aa7b046ade`
- UnityFS node: **130,404 bytes**

Test ZIP:
- `DECORATOR_TEST_10G_SHIFT_FINE_HORIZONTAL_FIX.zip`
- SHA-256: `aebeb52c499858f4c2c1f3ba71e73ca41ebfae6e6b1a3aa9d5ed0ccbb1e036ef`


## User validation

PASS confirmed in runtime. Existing placed decorations load normally. Left/Right fast movement works at 0.10, and Shift + Left/Right provides fine 0.02 movement.
