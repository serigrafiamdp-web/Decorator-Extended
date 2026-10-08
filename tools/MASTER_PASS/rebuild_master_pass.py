#!/usr/bin/env python3
import argparse
import base64
import hashlib
from pathlib import Path

EXPECTED_SIZE = 27143
EXPECTED_SHA256 = "4f18fa6fd57187de1bfd66a66110729b93f84060a5149295bee72831b58d882c"

def main():
    parser = argparse.ArgumentParser(description="Rebuild the exact Decorator V2 MASTER PASS dfmod from its Base64 archive.")
    parser.add_argument("output", nargs="?", default="decorator-master-pass.dfmod")
    args = parser.parse_args()

    root = Path(__file__).resolve().parent
    encoded = (root / "decorator-master-pass.b64").read_text(encoding="ascii").strip()
    data = base64.b64decode(encoded, validate=True)

    size = len(data)
    sha = hashlib.sha256(data).hexdigest()
    if size != EXPECTED_SIZE:
        raise SystemExit(f"SIZE MISMATCH: expected {EXPECTED_SIZE}, got {size}")
    if sha != EXPECTED_SHA256:
        raise SystemExit(f"SHA-256 MISMATCH: expected {EXPECTED_SHA256}, got {sha}")

    out = Path(args.output)
    out.write_bytes(data)
    print(f"PASS: wrote {out} ({size} bytes)")
    print(f"SHA-256: {sha}")

if __name__ == "__main__":
    main()
