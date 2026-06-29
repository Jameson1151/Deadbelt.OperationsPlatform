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
> * README.md
> * PROJECT_CHARTER.md
> * VISION.md
> * ROADMAP.md
> * architecture/overview.md
> * architecture/domain-model.md
> * architecture/application-lifecycle.md
> * architecture/technology-stack.md
> * architecture/plugin-system.md

# Solution Structure

## Overview

Deadbelt Operations Platform (DOP) is organized as a modular .NET solution.

The solution is designed to support multiple user interfaces, provider integrations, extensions, automation workflows, and future platform services while keeping the core domain model independent from external systems.

The primary architectural goal is to prevent the desktop application, providers, and external integrations from becoming tightly coupled to the core platform logic.

---

## Proposed Repository Structure

```text
Deadbelt.OperationsPlatform
│
├── src
│   ├── Deadbelt.Domain
│   ├── Deadbelt.Application
│   ├── Deadbelt.Infrastructure
│   ├── Deadbelt.Providers
│   ├── Deadbelt.Extensions
│   ├── Deadbelt.Desktop
│   ├── Deadbelt.Cli
│   └── Deadbelt.Shared
│
├── tests
│   ├── Deadbelt.Domain.Tests
│   ├── Deadbelt.Application.Tests
│   ├── Deadbelt.Infrastructure.Tests
│   ├── Deadbelt.Providers.Tests
│   └── Deadbelt.Extensions.Tests
│
├── docs
├── assets
├── samples
└── tools
```

---

## Project Responsibilities

## Deadbelt.Domain

The `Deadbelt.Domain` project contains the core business model of the platform.

This project defines the concepts that exist regardless of user interface, operating system, provider, or game-specific implementation.

### Belongs Here

* Entities
* Value objects
* Domain events
* Domain enums
* Domain validation rules
* Domain exceptions
* Core aggregates

Examples:

* Workspace
* Environment
* Server
* Configuration
* Package
* Mod
* Deployment
* Job
* Schedule
* Backup
* Secret
* MonitoringSignal

### Does Not Belong Here

* File system access
* JSON serialization
* Database access
* SteamCMD logic
* Hosting provider APIs
* WPF code
* CLI code
* HTTP clients
* Discord integration
* RCON implementation

### Dependency Rule

`Deadbelt.Domain` should have no dependency on other DOP projects.

It is the center of the architecture.

---

## Deadbelt.Application

The `Deadbelt.Application` project contains platform use cases and orchestration logic.

This project coordinates domain objects and calls abstractions for external operations.

### Belongs Here

* Use cases
* Application services
* Command handlers
* Query handlers
* Validation workflows
* Deployment orchestration
* Environment promotion logic
* Job execution coordination
* Interfaces for providers and infrastructure

Examples:

* CreateEnvironmentService
* DeployEnvironmentService
* PromoteEnvironmentService
* ValidateEnvironmentService
* BackupEnvironmentService
* StartServerService
* StopServerService

### Does Not Belong Here

* WPF controls
* CLI argument parsing
* Direct file system access
* Direct SteamCMD execution
* Direct hosting provider SDK calls
* Direct database implementation
* UI-specific formatting

### Dependency Rule

`Deadbelt.Application` may depend on:

* `Deadbelt.Domain`
* `Deadbelt.Shared`

It should not depend directly on concrete provider or infrastructure implementations.

---

## Deadbelt.Infrastructure

The `Deadbelt.Infrastructure` project contains platform infrastructure services that are not provider-specific.

Infrastructure supports the platform but does not represent external hosting or game-specific integrations.

### Belongs Here

* File system services
* JSON serialization
* Local configuration persistence
* Logging setup
* Local database access
* Secret storage implementations
* Dependency injection registration
* Application settings storage
* Local cache management

Examples:

* JsonFileEnvironmentStore
* LocalSettingsStore
* WindowsCredentialSecretStore
* FileSystemService
* LoggingBootstrapper

### Does Not Belong Here

* Domain business rules
* UI code
* CLI command definitions
* Hosting provider API logic
* Game-specific behavior
* Steam Workshop business logic

### Dependency Rule

`Deadbelt.Infrastructure` may depend on:

* `Deadbelt.Application`
* `Deadbelt.Domain`
* `Deadbelt.Shared`

It implements interfaces defined by the Application layer.

---

## Deadbelt.Providers

The `Deadbelt.Providers` project contains provider implementations used to communicate with external systems, services, hosts, protocols, or platforms.

Providers answer the question:

> How does DOP talk to this external system?

### Belongs Here

* SteamCMD provider
* RCON provider
* Local Windows host provider
* Local Linux host provider
* Hosting provider integrations
* Backup target providers
* Notification providers
* Monitoring providers

Examples:

* SteamCmdProvider
* RconProvider
* LocalWindowsServerProvider
* DiscordNotificationProvider
* SftpFileTransferProvider
* HostingProviderClient

### Does Not Belong Here

* Domain entities
* UI logic
* General application orchestration
* Extension loading
* Core business rules
* Game-specific configuration rules unless owned by a provider

### Dependency Rule

`Deadbelt.Providers` may depend on:

* `Deadbelt.Application`
* `Deadbelt.Domain`
* `Deadbelt.Infrastructure`
* `Deadbelt.Shared`

Providers should implement interfaces defined outside the provider implementation itself.

---

## Deadbelt.Extensions

The `Deadbelt.Extensions` project contains extension contracts, extension metadata, extension loading concepts, and eventually the public extension SDK.

Extensions answer the question:

> What new capability does this add to DOP?

### Belongs Here

* Extension interfaces
* Extension metadata
* Extension manifests
* Extension loading contracts
* Extension permission model
* Extension lifecycle hooks
* Extension discovery abstractions

Examples:

* IDeadbeltExtension
* ExtensionManifest
* ExtensionPermission
* ExtensionLoadContext
* ExtensionDescriptor

### Does Not Belong Here

* Core domain entities
* WPF screens
* Concrete hosting provider implementations
* Direct file system access
* Direct network calls
* Secrets in plain text

### Dependency Rule

`Deadbelt.Extensions` may depend on:

* `Deadbelt.Domain`
* `Deadbelt.Application`
* `Deadbelt.Shared`

The extension system should remain versioned and stable enough for external developers to build against.

---

## Deadbelt.Desktop

The `Deadbelt.Desktop` project contains the desktop user interface.

The initial desktop client should be built using WPF and MVVM.

### Belongs Here

* Views
* ViewModels
* UI services
* Commands
* UI navigation
* Dialogs
* Resource dictionaries
* Desktop-specific dependency injection
* Desktop-specific settings presentation

Examples:

* MainWindow
* EnvironmentDashboardView
* EnvironmentDashboardViewModel
* SettingsView
* DeploymentProgressDialog

### Does Not Belong Here

* Domain business rules
* Deployment orchestration
* Provider implementations
* Secret storage implementation
* SteamCMD execution logic
* File synchronization logic

### Dependency Rule

`Deadbelt.Desktop` may depend on:

* `Deadbelt.Application`
* `Deadbelt.Domain`
* `Deadbelt.Infrastructure`
* `Deadbelt.Providers`
* `Deadbelt.Extensions`
* `Deadbelt.Shared`

The Desktop project should use Application services rather than implementing platform behavior directly.

---

## Deadbelt.Cli

The `Deadbelt.Cli` project provides command-line access to DOP capabilities.

The CLI should support automation, scripting, and eventually CI/CD workflows.

### Belongs Here

* CLI command definitions
* Argument parsing
* Console output formatting
* Exit codes
* CLI-specific dependency injection
* Automation-friendly commands

Examples:

```powershell
dop environment list
dop environment validate Development
dop deploy Development Testing
dop backup Production
dop server restart Production
```

### Does Not Belong Here

* Domain business rules
* Provider implementations
* Desktop UI logic
* Direct configuration persistence
* Direct SteamCMD logic

### Dependency Rule

`Deadbelt.Cli` may depend on:

* `Deadbelt.Application`
* `Deadbelt.Domain`
* `Deadbelt.Infrastructure`
* `Deadbelt.Providers`
* `Deadbelt.Extensions`
* `Deadbelt.Shared`

The CLI should use the same Application services as the Desktop project.

---

## Deadbelt.Shared

The `Deadbelt.Shared` project contains shared primitives that are safe to use across multiple layers.

This project must be kept intentionally small.

### Belongs Here

* Common result types
* Shared constants
* Version information
* Lightweight utility types
* Cross-layer value primitives

Examples:

* Result
* Result<T>
* Error
* OperationStatus
* PlatformConstants

### Does Not Belong Here

* Business rules
* Provider logic
* UI logic
* File access
* Network access
* Large utility libraries
* Anything that does not have a clear cross-layer purpose

### Dependency Rule

`Deadbelt.Shared` should not depend on other DOP projects.

If this project starts growing too quickly, it should be reviewed and refactored.

---

# Dependency Rules

The general dependency direction is:

```text
User Interfaces
    ↓
Application
    ↓
Domain

Infrastructure → Application Interfaces
Providers → Application Interfaces
Extensions → Extension Contracts / Application Interfaces
Shared → No project dependencies
```

The Domain layer must remain independent.

Concrete external integrations must not leak into the Domain model.

---

# Naming Conventions

## Projects

Project names should use the format:

```text
Deadbelt.<LayerOrCapability>
```

Examples:

```text
Deadbelt.Domain
Deadbelt.Application
Deadbelt.Infrastructure
Deadbelt.Providers
Deadbelt.Extensions
Deadbelt.Desktop
Deadbelt.Cli
```

---

## Namespaces

Namespaces should match the project and folder structure.

Example:

```csharp
namespace Deadbelt.Domain.Workspaces;
namespace Deadbelt.Application.Environments;
namespace Deadbelt.Providers.Steam;
namespace Deadbelt.Desktop.ViewModels;
```

---

## Tests

Test projects should mirror the production project name.

Examples:

```text
Deadbelt.Domain.Tests
Deadbelt.Application.Tests
Deadbelt.Providers.Tests
```

---

# Future Projects

Additional projects may be introduced as the platform matures.

Potential future projects:

```text
Deadbelt.Api
Deadbelt.Agent
Deadbelt.Web
Deadbelt.Sdk
Deadbelt.Installers
Deadbelt.Telemetry
Deadbelt.AI
```

These should only be added when there is a clear architectural need.

---

# Design Principle

If a class could be reused by the Desktop app, CLI, API, or future Agent, it probably does not belong in the Desktop project.

If a class represents a core platform concept, it probably belongs in Domain.

If a class coordinates a user action or workflow, it probably belongs in Application.

If a class talks to an external system, it probably belongs in Infrastructure or Providers.

If a class adds optional capability, it probably belongs in Extensions.
