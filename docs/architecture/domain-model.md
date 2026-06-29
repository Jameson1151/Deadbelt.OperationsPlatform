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
> * architecture/application-lifecycle.md
> * architecture/solution-structure.md
> * architecture/technology-stack.md
> * architecture/plugin-system.md

# Domain Model

## Overview

The Deadbelt Operations Platform (DOP) domain model defines the core business concepts used throughout the platform.

DOP is designed around managing complete operational environments rather than individual servers. This allows the platform to support local servers, hosted servers, multi-server communities, extensions, providers, automation, monitoring, and future intelligent operations without redesigning the core model.

---

# Core Concepts

## Workspace

A **Workspace** represents the highest-level organizational boundary in DOP.

A Workspace may represent:

* A game server community
* A development lab
* A hosting customer
* A group of related environments
* A future organization or tenant boundary

Example:

```text
Workspace: Deadbelt Community
```

A Workspace contains one or more Environments.

---

## Environment

An **Environment** is the primary unit of management in DOP.

An Environment represents the complete desired state of a game server deployment.

Examples:

```text
Development
Testing
Production
Event Server
Experimental
```

An Environment may contain:

* Servers
* Configuration
* Mods
* Packages
* Providers
* Deployments
* Backups
* Schedules
* Monitoring
* Secrets
* Extensions

The Environment is the most important domain object in the platform.

---

## Server

A **Server** represents a managed game server instance.

A Server may be:

* Local
* Remote
* Self-hosted
* Hosted by a provider
* Physical
* Virtual
* Containerized
* Cloud-hosted

A Server belongs to an Environment.

A Server does not define the entire operational state by itself. It is one component within an Environment.

---

## Provider

A **Provider** represents an external system or platform that DOP interacts with.

Examples:

* Local Windows host
* Linux host
* SteamCMD
* Hosting provider
* RCON provider
* Backup provider
* Notification provider
* Monitoring provider
* Community service provider

Providers allow DOP to orchestrate systems it does not own.

---

## Extension

An **Extension** adds optional platform functionality.

Extensions may provide:

* Hosting integrations
* Notification systems
* Backup targets
* Monitoring tools
* Game-specific support
* Automation modules
* AI-assisted features

Extensions should integrate through documented interfaces and should not require changes to the core platform.

---

## Configuration

A **Configuration** represents settings that define how an Environment or Server should behave.

Configuration may include:

* Server name
* Ports
* IP bindings
* Runtime settings
* Gameplay settings
* File paths
* Launch parameters
* Provider settings
* Extension settings

DOP should treat configuration as desired state whenever possible.

---

## Package

A **Package** represents a reusable group of related items that can be applied to one or more Environments.

Packages may contain:

* Mods
* Configuration fragments
* Mission files
* Economy settings
* Event definitions
* Extension settings

Packages allow repeatable deployment across Development, Testing, and Production environments.

---

## Mod

A **Mod** represents a game modification known to DOP.

A Mod may include:

* Name
* Source
* Version
* Workshop ID
* Local path
* Dependencies
* Load order
* Client/server classification

Mods may be managed directly or through Packages.

---

## Deployment

A **Deployment** represents the process of applying desired state to an Environment.

A Deployment may include:

* Configuration changes
* Mod updates
* Server updates
* Package changes
* File synchronization
* Backup creation
* Validation
* Restart operations
* Rollback metadata

Deployments should be auditable and repeatable.

---

## Job

A **Job** represents a unit of work executed by DOP.

Examples:

* Start server
* Stop server
* Restart server
* Update mods
* Create backup
* Validate configuration
* Deploy environment
* Run health check

Jobs may be manually triggered, scheduled, or event-driven.

---

## Schedule

A **Schedule** defines when Jobs should run.

Examples:

* Restart every 4 hours
* Backup every 6 hours
* Check for updates daily
* Run health checks every 5 minutes
* Send restart warnings before maintenance

Schedules belong to an Environment or Workspace.

---

## Backup

A **Backup** represents a restorable snapshot of part or all of an Environment.

Backups may include:

* Configuration
* Profiles
* Mission files
* Economy files
* Logs
* Databases
* Mod manifests
* Deployment metadata

Backup storage may be local or provider-based.

---

## Secret

A **Secret** represents sensitive information.

Examples:

* API keys
* RCON passwords
* Steam credentials
* Hosting provider tokens
* Encryption keys
* Webhook URLs

Secrets must never be stored in plain text unless explicitly allowed by a secure local development mode.

---

## Monitoring Signal

A **Monitoring Signal** represents operational data collected from an Environment or Server.

Examples:

* Server online/offline status
* Player count
* CPU usage
* Memory usage
* Restart count
* Failed jobs
* Mod update status
* Backup status
* Health check result

Monitoring Signals may be used for dashboards, alerts, automation, and future intelligent recommendations.

---

# Conceptual Hierarchy

```text
Workspace
│
├── Environment
│   │
│   ├── Server
│   ├── Configuration
│   ├── Packages
│   │   └── Mods
│   ├── Providers
│   ├── Extensions
│   ├── Deployments
│   ├── Jobs
│   ├── Schedules
│   ├── Backups
│   ├── Secrets
│   └── Monitoring Signals
│
└── Environment
```

---

# Desired State Model

DOP should prefer a desired-state model.

Instead of only asking:

```text
What is currently running?
```

DOP should also ask:

```text
What should this environment look like?
```

The platform can then compare desired state against actual state and determine whether changes are required.

This enables:

* Environment drift detection
* Deployment previews
* Safer updates
* Repeatable configuration
* Rollback support
* Environment promotion

---

# Environment Promotion

DOP should support promoting changes between Environments.

Example:

```text
Development
    ↓
Testing
    ↓
Production
```

Promotion may include:

* Configuration changes
* Package changes
* Mod updates
* Mission updates
* Economy updates
* Extension settings

Promotion should include validation and backup creation before changes are applied.

---

# Provider Boundary

DOP should orchestrate providers, not own them.

For example, DOP may interact with a hosting provider API, but the hosting provider remains responsible for its own infrastructure.

This boundary is important for:

* Legal clarity
* Maintainability
* Provider neutrality
* Extension development
* Security

---

# Initial Domain Priorities

The first implementation should focus on these domain objects:

1. Workspace
2. Environment
3. Server
4. Configuration
5. Provider
6. Extension
7. Mod
8. Package
9. Deployment
10. Secret

Other concepts may be introduced as the platform matures.

---

# Design Principle

The domain model should remain as platform-agnostic as possible.

Game-specific concepts should live in providers, extensions, or implementation layers unless they are truly universal to game server operations.

The core domain should describe operations, environments, providers, automation, and deployment rather than any single game.
