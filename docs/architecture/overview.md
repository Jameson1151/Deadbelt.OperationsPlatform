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
> * architecture/solution-structure.md
> * architecture/application-lifecycle.md
> * architecture/technology-stack.md

# Architecture Overview

## Overview

Deadbelt Operations Platform (DOP) is designed as a modular operations platform for dedicated game server infrastructure.

The architecture is based on separation of concerns, provider neutrality, extensibility, and a desired-state operational model.

DOP should remain capable of managing local, remote, hosted, and future cloud-based environments without tying the core platform to a specific game, host, operating system, or third-party service.

---

## Architectural Goals

DOP is designed to support:

* Local and remote environment management
* Provider-neutral integrations
* Modular extension development
* Secure secret handling
* Repeatable deployments
* Environment promotion
* Automation
* Monitoring
* Future API and CLI support
* Future intelligent operations

---

## Layered Architecture

DOP should follow a layered architecture.

```text
User Interfaces
│
├── Desktop App
├── CLI
├── Future Web UI
└── Future API
        │
Application Layer
        │
Domain Layer
        │
Provider / Infrastructure Layer
        │
External Systems
```

---

## Proposed Solution Structure

```text
src
│
├── Deadbelt.Domain
├── Deadbelt.Application
├── Deadbelt.Providers
├── Deadbelt.Extensions
├── Deadbelt.Desktop
└── Deadbelt.Cli

tests
│
├── Deadbelt.Domain.Tests
├── Deadbelt.Application.Tests
├── Deadbelt.Providers.Tests
└── Deadbelt.Extensions.Tests
```

---

## Project Responsibilities

### Deadbelt.Domain

Contains the core business model.

This project defines platform concepts such as:

* Workspace
* Environment
* Server
* Provider
* Extension
* Configuration
* Package
* Mod
* Deployment
* Job
* Schedule
* Backup
* Secret
* Monitoring Signal

The Domain project should not depend on infrastructure, UI frameworks, file systems, databases, Steam, Discord, hosting providers, or any external service.

---

### Deadbelt.Application

Contains use cases and orchestration logic.

Examples:

* Create environment
* Validate environment
* Deploy environment
* Promote environment
* Start server
* Stop server
* Apply configuration
* Run backup
* Execute job
* Load extension

The Application layer coordinates domain objects and provider interfaces but should avoid directly depending on specific provider implementations.

---

### Deadbelt.Providers

Contains provider implementations that communicate with external systems.

Examples:

* Local Windows provider
* Local Linux provider
* SteamCMD provider
* RCON provider
* File system provider
* Backup provider
* Notification provider
* Hosting provider integrations

Providers implement platform interfaces and are replaceable.

---

### Deadbelt.Extensions

Contains extension contracts, extension loading, extension metadata, and future SDK concepts.

Extensions allow optional capabilities to be added without changing the core platform.

Examples:

* Game-specific extensions
* Hosting provider extensions
* Monitoring extensions
* Notification extensions
* AI-assisted extensions
* Backup extensions

---

### Deadbelt.Desktop

Contains the desktop user interface.

The initial desktop application should be built with WPF and MVVM.

The Desktop project should:

* Display data
* Collect user input
* Call application services
* Show job status
* Present environment state

It should not contain business logic that belongs in Domain or Application.

---

### Deadbelt.Cli

Contains command-line access to platform capabilities.

The CLI should eventually support automation scenarios such as:

```powershell
dop environment list
dop environment validate Development
dop deploy Development Testing
dop backup Production
dop server restart Production
```

The CLI should use the same Application services as the desktop app.

---

## Dependency Direction

Dependencies should flow inward.

```text
Desktop ─┐
CLI ─────┤
         ↓
Application
         ↓
Domain

Providers → Application Interfaces / Domain Models
Extensions → Extension Contracts
```

The Domain layer must remain independent.

---

## Provider Model

DOP should interact with external systems through providers.

A provider is responsible for performing operations against a specific system, host, service, or protocol.

Examples:

* A Steam provider updates server binaries.
* A Workshop provider synchronizes mods.
* A hosting provider starts or stops a remote server.
* A notification provider sends Discord messages.
* A backup provider stores and restores backups.

DOP orchestrates providers but does not own the systems they manage.

---

## Extension Model

Extensions add optional capabilities to the platform.

The extension model should allow the community to build integrations without modifying the core codebase.

Extensions may provide:

* Providers
* UI modules
* Automation actions
* Validation rules
* Monitoring signals
* Game-specific capabilities

The extension system should remain secure, documented, and versioned.

---

## Desired-State Operations

DOP should favor a desired-state model.

An Environment defines what should exist.

Providers report what actually exists.

The Application layer compares desired state to actual state and determines what actions are required.

This enables:

* Drift detection
* Deployment previews
* Safer updates
* Repeatable environments
* Rollback support

---

## Security Architecture

Security must be considered from the beginning.

Sensitive data should be handled through a Secret abstraction.

Secrets may include:

* API keys
* RCON passwords
* Hosting provider tokens
* Steam credentials
* Webhook URLs
* Encryption keys

Secrets should not be stored in plain text by default.

Future implementations should support secure storage providers such as:

* Windows Credential Manager
* Encrypted local storage
* External secret providers
* Environment variables for automation

---

## Initial Implementation Focus

The initial implementation should focus on:

1. Defining the domain model
2. Creating the application layer
3. Building a local provider
4. Building a configuration engine
5. Creating a WPF desktop shell
6. Adding CLI foundations
7. Supporting a first game-specific implementation through extensions/providers

---

## Architectural Principle

DOP should orchestrate systems rather than monopolize them.

The platform should provide a unified control plane while remaining compatible with existing tools, providers, and community workflows.
