> **Status:** Draft
>
> **Version:** 0.1
>
> **Last Updated:** 2026-06-29
>
> **Applies To:** Deadbelt Operations Platform (DOP)
>
> **Audience:** Contributors, Architects, Maintainers
>
> **Related Documents:**
>
> * architecture/solution-structure.md
> * architecture/design-principles.md
> * branching-strategy.md
> * CONTRIBUTING.md

# Coding Standards

## Purpose

This document establishes the coding standards for the Deadbelt Operations Platform.

The goal is consistency.

Readable, predictable, maintainable code is valued more highly than clever or overly complex implementations.

---

# Guiding Philosophy

Every line of code should make the platform easier to understand.

Contributors should optimize for clarity rather than brevity.

Future maintainers should be able to understand code without requiring extensive explanation.

---

# Language Version

The project uses the latest supported .NET SDK defined in `global.json`.

New language features may be adopted after evaluating readability and long-term maintainability.

---

# General Principles

Prefer:

* Small classes
* Small methods
* Clear names
* Explicit behavior
* Immutable objects where practical
* Composition over inheritance
* Dependency Injection
* Async programming for I/O

Avoid:

* Static state
* Deep inheritance trees
* Hidden side effects
* God classes
* Circular dependencies
* Premature optimization

---

# Naming

## Projects

```
Deadbelt.<Capability>
```

Examples:

```
Deadbelt.Domain
Deadbelt.Application
Deadbelt.Desktop
```

---

## Classes

Use PascalCase.

Good:

```
EnvironmentManager
DeploymentService
Workspace
```

Avoid abbreviations unless widely understood.

---

## Interfaces

Prefix interfaces with **I**.

Examples:

```
IEnvironmentRepository
IProvider
ILogger
```

---

## Methods

Use verbs.

Examples:

```
LoadEnvironment()
SaveWorkspace()
DeployEnvironment()
```

---

## Properties

Use nouns.

Examples:

```
EnvironmentName
WorkspacePath
ProviderStatus
```

---

## Private Fields

Use:

```csharp
private readonly ILogger _logger;
private readonly IConfigurationService _configurationService;
```

---

## Constants

Use PascalCase.

```csharp
public const int DefaultPort = 2302;
```

---

# File Organization

One public type per file.

File names should match the public type.

Example:

```
Environment.cs
DeploymentService.cs
```

---

# Class Design

Classes should have a single responsibility.

If a class becomes difficult to explain in one sentence, consider splitting it.

---

# Method Design

Methods should:

* Perform one task
* Be easy to test
* Return predictable results

Prefer early returns over deeply nested conditionals.

---

# Async Programming

I/O operations should use async/await.

Avoid blocking calls such as:

```
.Wait()

.Result
```

Library code should use ConfigureAwait(false) where appropriate.

---

# Dependency Injection

Dependencies should be injected through constructors.

Avoid service locators.

Avoid manually creating dependencies inside classes.

---

# Logging

Use Microsoft.Extensions.Logging abstractions.

Log:

* Startup
* Shutdown
* Errors
* Warnings
* Deployments
* Extension loading
* Provider operations

Avoid excessive debug logging.

Never log secrets.

---

# Exception Handling

Throw exceptions only for exceptional situations.

Validation failures should return structured results whenever possible.

Exceptions should include meaningful messages.

---

# Result Pattern

Application services should favor result objects over exceptions for expected outcomes.

Example:

```
Result Success
Result Failure
Result<T>
```

---

# Nullability

Nullable Reference Types should remain enabled.

Do not suppress nullable warnings without good reason.

---

# XML Documentation

Public APIs should include XML documentation.

Internal implementation details generally do not require XML comments if the code is self-explanatory.

---

# Comments

Write comments that explain **why**, not **what**.

Avoid redundant comments.

Bad:

```csharp
// Increment counter
counter++;
```

Good:

```csharp
// Skip provider initialization during recovery mode.
```

---

# Testing

Every new feature should include tests where practical.

Focus testing on:

* Domain
* Application
* Providers

UI testing should be limited.

---

# Code Reviews

Every pull request should consider:

* Correctness
* Readability
* Maintainability
* Security
* Performance
* Documentation

---

# Formatting

The project uses:

* EditorConfig
* dotnet format

Formatting should be automated whenever possible.

---

# Dependencies

New dependencies should be introduced only when they solve a clearly defined problem.

Favor built-in .NET functionality over third-party libraries.

---

# Security

Never:

* Commit secrets
* Hardcode credentials
* Disable validation
* Ignore warnings without explanation

Security should be considered during implementation rather than after development.

---

# Design Rule

If code makes the architecture harder to understand, it should be redesigned before it is merged.

Long-term maintainability always takes precedence over short-term convenience.
