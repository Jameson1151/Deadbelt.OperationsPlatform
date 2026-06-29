# ADR-0003: Provider vs Extension Separation

## Status

Accepted

## Context

DOP needs to integrate with external systems while also allowing new capabilities to be added over time.

Early discussions used the terms provider, plugin, and extension interchangeably. This created ambiguity.

The platform needs a clear distinction between:

* Systems DOP communicates with
* Capabilities added to DOP

## Decision

DOP will distinguish Providers from Extensions.

A Provider answers:

> How does DOP communicate with this external system?

An Extension answers:

> What capability does this add to DOP?

Examples of Providers:

* SteamCMD provider
* RCON provider
* Local Windows provider
* Discord notification provider
* Hosting provider
* Backup provider

Examples of Extensions:

* DayZ support
* Rust support
* BattleMetrics integration
* AI assistant
* Economy editor
* Deployment visualizer

Extensions may register Providers, but they are not the same concept.

## Alternatives Considered

### Treat Everything as Plugins

Rejected because it creates unclear responsibilities and makes architecture harder to explain.

### Treat Everything as Providers

Rejected because not every capability communicates with an external system.

### Hardcode Integrations into Core

Rejected because it would make the platform difficult to maintain and extend.

## Consequences

### Positive

* Clearer architecture
* Easier contributor onboarding
* Better extension model
* Cleaner provider contracts
* More maintainable core platform

### Negative

* Requires more upfront documentation
* Contributors must understand the distinction
* Some features may involve both providers and extensions

## Related Documents

* docs/architecture/plugin-system.md
* docs/architecture/solution-structure.md
* docs/glossary.md
