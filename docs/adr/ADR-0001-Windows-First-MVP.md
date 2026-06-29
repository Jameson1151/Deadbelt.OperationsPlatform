# ADR-0001: Windows-First MVP

## Status

Accepted

## Context

DOP is intended to become a cross-platform operations platform. However, attempting to support Windows, Linux, web, CLI, and agent-based deployments from the beginning would slow development and increase complexity before the core platform is proven.

The initial contributor environment is Windows-based, and the first target use case involves managing locally installed dedicated game server infrastructure.

## Decision

The initial MVP will target Windows first.

The first implementation will focus on:

* Windows desktop application
* WPF user interface
* Local Windows provider
* Windows-compatible file system operations
* Windows Credential Manager or equivalent secure local secret handling

The Domain and Application layers must remain platform independent so future Linux, web, API, and agent-based clients can be added without redesigning the core architecture.

## Alternatives Considered

### Cross-Platform From Day One

Rejected because it would increase scope and delay the first usable proof of concept.

### Web-First Platform

Rejected because DOP needs strong local system integration during the MVP phase.

### CLI-First Platform

Rejected because the project needs an approachable management interface for server administrators.

## Consequences

### Positive

* Faster MVP development
* Simpler testing environment
* Better initial desktop experience
* Stronger focus on core platform behavior

### Negative

* Linux support is delayed
* Web/API support is delayed
* Early contributors on non-Windows platforms may have limited participation

## Related Documents

* docs/architecture/technology-stack.md
* docs/architecture/solution-structure.md
* docs/architecture/design-principles.md
