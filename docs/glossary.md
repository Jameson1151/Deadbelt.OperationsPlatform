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
> * overview.md
> * domain-model.md
> * solution-structure.md
> * design-principles.md

# Glossary

## Purpose

This glossary provides authoritative definitions for terms used throughout the Deadbelt Operations Platform documentation.

Contributors should use these definitions consistently to reduce ambiguity and ensure that architecture, code, documentation, and discussions all refer to the same concepts.

---

## Agent

A runtime component responsible for executing operations on behalf of DOP.

The Agent provides a secure abstraction between the platform and the operating system, allowing deployments, monitoring, process management, and automation to occur locally or remotely.

---

## Application Layer

The orchestration layer responsible for coordinating workflows, use cases, validation, and interactions between the Domain model and Providers.

Business workflows belong here.

---

## Backup

A recoverable snapshot of all or part of an Environment.

Backups may include configuration, missions, profiles, databases, logs, and deployment metadata.

---

## Capability

A functional feature or service that DOP provides.

Capabilities may be implemented by the core platform or through Extensions.

---

## Configuration

The collection of settings that define how an Environment or Server should operate.

Configuration represents desired state rather than implementation details.

---

## Deployment

The process of reconciling an Environment's desired state with its current state.

Deployments may include configuration changes, file synchronization, mod updates, validation, backups, and restart operations.

---

## Drift

The difference between an Environment's desired state and its actual operational state.

Drift detection allows DOP to identify inconsistencies and recommend or perform corrective actions.

---

## Domain

The collection of core business concepts that define DOP independently of any user interface, operating system, provider, or game.

---

## Environment

The primary unit of management within DOP.

An Environment represents the complete operational definition of a deployment, including servers, configuration, packages, providers, monitoring, and automation.

---

## Extension

An optional component that adds new capabilities to DOP without modifying the core platform.

Extensions may add support for games, providers, UI modules, automation, monitoring, or future AI features.

---

## Infrastructure

The collection of technical services that support the platform but are not themselves business concepts.

Examples include file storage, serialization, logging, dependency injection, and secret storage.

---

## Job

A discrete unit of work executed by DOP.

Jobs may be manually triggered, scheduled, or event-driven.

---

## Monitoring Signal

Operational data collected from an Environment or Provider.

Examples include player counts, server status, CPU usage, backup status, and deployment health.

---

## Package

A reusable collection of related configuration, mods, or deployment assets that can be applied to one or more Environments.

Packages simplify repeatable deployments.

---

## Plugin System

The framework responsible for discovering, validating, loading, and managing Extensions.

The Plugin System is the mechanism that enables extensibility.

---

## Promotion

The controlled movement of an Environment or its configuration between lifecycle stages such as Development, Testing, and Production.

Promotions should include validation and rollback capabilities.

---

## Provider

A component responsible for communicating with an external system.

Providers interact with operating systems, hosting platforms, Steam, RCON, backup targets, notification services, and other infrastructure.

Providers answer the question:

> "How does DOP communicate with this system?"

---

## Secret

Sensitive information required by the platform.

Examples include API keys, passwords, authentication tokens, encryption keys, and webhook URLs.

---

## Server

A managed runtime instance of a game server.

Servers are components of an Environment rather than independent management units.

---

## Shared

A project containing lightweight primitives used across multiple architectural layers.

Shared should remain intentionally small and free of business logic.

---

## Workspace

The highest organizational boundary within DOP.

A Workspace groups one or more Environments that belong to the same community, organization, or deployment.

---

## Desired State

The authoritative definition of how an Environment should be configured and operated.

DOP compares desired state with actual state to determine whether changes are required.

---

## Actual State

The current operational state reported by Providers or Agents.

Differences between desired state and actual state represent operational drift.

---

## Orchestration

The coordination of multiple operations, providers, and services to achieve a desired outcome.

DOP acts as an orchestration platform rather than a collection of disconnected management tools.

---

## Operations Platform

A software platform that coordinates deployment, monitoring, automation, configuration management, and infrastructure operations across one or more Environments.

This is the defining concept of Deadbelt Operations Platform.
