# ADR-0002: Environment-Centric Architecture

## Status

Accepted

## Context

Traditional game server management tools often focus on individual servers. However, real communities manage complete operational ecosystems that include development, testing, production, events, mods, configuration, backups, monitoring, providers, and automation.

Managing only a server does not capture the complete operational state.

## Decision

DOP will use the Environment as the primary unit of management.

A Server is a component of an Environment, not the root object.

An Environment may contain:

* Servers
* Configuration
* Packages
* Mods
* Providers
* Extensions
* Deployments
* Jobs
* Schedules
* Backups
* Secrets
* Monitoring signals

## Alternatives Considered

### Server-Centric Architecture

Rejected because it limits DOP to traditional server management and makes promotion, cloning, drift detection, and environment comparison harder.

### Provider-Centric Architecture

Rejected because providers are implementation details, not the operational state being managed.

### Game-Centric Architecture

Rejected because DOP should remain game-agnostic at the core platform level.

## Consequences

### Positive

* Supports Development, Testing, Production workflows
* Enables environment promotion
* Enables drift detection
* Enables environment cloning
* Supports future multi-server deployments
* Keeps the core model platform-oriented

### Negative

* More complex than a simple server launcher
* Requires careful domain modeling
* May be less familiar to users at first

## Related Documents

* docs/architecture/domain-model.md
* docs/architecture/design-principles.md
* docs/architecture/data-flow.md
