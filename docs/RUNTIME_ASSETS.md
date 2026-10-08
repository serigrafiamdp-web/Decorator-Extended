# Runtime assets outside the dfmod

The C# source references runtime files that are not all embedded in the Decorator dfmod. They are separate from the source/build authority.

## Emulator integration

The current V2 MASTER package carries:

- `Emulators/Fceux/DECORATOR_FCEUX_EMULATOR2.bat`
- `Emulators/Fceux/DECORATOR_FCEUX_EMULATOR2.ps1`
- `Emulators/Vice/bin/VICE_BEZEL_PIXELPERFECT_TEST_07B.bat`
- `Emulators/Vice/bin/VICE_BEZEL_PIXELPERFECT_TEST_07B.ps1`

The Decorator code launches those paths at runtime. Missing scripts do not prevent the dfmod from being built, but emulator launching will fail.

## Custom loose textures

The source expects these custom texture names through DFU loose-file texture loading:

- `PIXEL_01.png` through `PIXEL_10.png`
- `DECORATOR_FIREPLACE3_0-0.png`
- `DECORATOR_FIREPLACE3_0-1.png`
- `DECORATOR_FIREPLACE3_0-2.png`
- `DECORATOR_FIREPLACE3_0-3.png`
- `DECORATOR_FIREPLACE3_2-0.png`

These assets are runtime dependencies for the PIXEL slots and FIREPLACE 3 visuals. They are not required merely to compile/build the dfmod, but they are required to reproduce the validated visual behavior.

Keep runtime assets versioned or packaged alongside each promoted MASTER so a PASS build remains reproducible.
