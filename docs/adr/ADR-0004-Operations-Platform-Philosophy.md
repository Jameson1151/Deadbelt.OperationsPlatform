# ADR-0004: Operations Platform Philosophy

## Status

Accepted

## Context

The project began as an effort to create a better game server management tool.

As the project vision developed, it became clear that DOP should not simply replace existing server managers. Instead, it should apply modern infrastructure engineering principles to game server operations.

Game server communities often rely on disconnected tools for deployment, updates, monitoring, backups, scheduling, configuration, and integrations.

## Decision

DOP will be designed as an operations platform rather than a traditional server manager.

The platform should focus on:

* Environment management
* Desired-state operations
* Automation
* Provider orchestration
* Extension support
* Monitoring
* Deployment workflows
* Future agent-based operations

The desktop application is one client of the platform, not the platform itself.

## Alternatives Considered

### Server Manager

Rejected because it focuses too narrowly on individual server lifecycle operations.

### Deployment Tool

Rejected because deployment is only one part of operations.

### Game-Specific Tool

Rejected because DOP should remain platform-oriented and extensible.

## Consequences

### Positive

* Strong long-term vision
* Better architectural flexibility
* Supports future agents, CLI, API, and web UI
* Differentiates DOP from existing tools
* Encourages enterprise-grade engineering practices

### Negative

* Larger initial design scope
* Requires careful prioritization
* MVP must avoid trying to implement every platform capability immediately

## Related Documents

* PROJECT_CHARTER.md
* VISION.md
* ROADMAP.md
* docs/architecture/design-principles.md
