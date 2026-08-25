# GCAS Agentic E2E Test Repository

Purpose: a deliberately vulnerable, runnable .NET 9 repository for end-to-end testing of the Prototype_GCAS remediation platform.

The repository contains real vulnerability patterns and a real test project. It intentionally does **not** contain remediation answers, expected patches, fake scan results, or agent outputs.

## Build and test

```bash
dotnet restore
dotnet build
dotnet test
```

## Intended findings

- SQL Injection in `ProductsController`
- OS Command Injection in `DiagnosticsController`
- Reflected XSS in `SearchController`
- Path Traversal in `FileController`
- Hardcoded credential in `SecretService`
- Outdated `Newtonsoft.Json` dependency in `GcasE2ETestApi.csproj`

All findings are mapped in the companion Excel workbook supplied separately.

## Repository mapping

The remediation platform should resolve this repository strictly by Application Number through its own `config/repositories.json` configuration. Do not add scanner exports or remediation outputs to this repository.
