> **Status:** Draft
>
> **Version:** 0.1
>
> **Last Updated:** 2026-06-29
>
> **Applies To:** Deadbelt Operations Platform (DOP)
>
> **Audience:** Contributors, Maintainers
>
> **Related Documents:**
>
> * coding-standards.md
> * CONTRIBUTING.md
> * CHANGELOG.md

# Branching Strategy

## Purpose

This document defines the Git branching strategy used by the Deadbelt Operations Platform.

The objectives are:

* Keep the main branch stable
* Simplify collaboration
* Encourage small, reviewable changes
* Enable predictable releases

---

# Branch Model

DOP follows a simplified GitHub Flow model.

The primary branches are:

```text
main
```

Feature development occurs in short-lived feature branches.

Release branches are not required during the early stages of the project.

---

# Main Branch

The `main` branch always represents the latest stable version of the project.

The `main` branch should:

* Build successfully
* Pass all automated tests
* Remain deployable
* Reflect production-ready code

Direct commits to `main` should be avoided once multiple contributors are active.

---

# Feature Branches

Feature work should be completed in dedicated branches.

Naming convention:

```text
feature/<description>
```

Examples:

```text
feature/workspaces
feature/environment-engine
feature/dayz-provider
feature/extension-loader
```

---

# Bug Fixes

Bug fixes should use:

```text
fix/<description>
```

Examples:

```text
fix/provider-timeout
fix/null-reference
```

---

# Documentation

Documentation updates should use:

```text
docs/<description>
```

Examples:

```text
docs/domain-model
docs/plugin-system
```

---

# Refactoring

Internal improvements without functional changes should use:

```text
refactor/<description>
```

---

# Pull Requests

Every Pull Request should:

* Have a clear title
* Explain the purpose
* Reference related issues where applicable
* Build successfully
* Pass automated validation
* Include documentation updates if required

Large Pull Requests should be avoided.

Small, focused changes are easier to review.

---

# Commit Messages

Commit messages should be concise and descriptive.

Good examples:

```text
Add Workspace domain model

Implement environment validation

Refactor provider registration

Add deployment result model

Update architecture documentation
```

Avoid:

```text
Fix stuff

Update

Changes

Test
```

---

# Versioning

DOP follows Semantic Versioning.

```text
MAJOR.MINOR.PATCH
```

Example:

```text
1.4.2
```

Meaning:

* MAJOR – Breaking changes
* MINOR – New backward-compatible features
* PATCH – Bug fixes

---

# Releases

Releases should be tagged in Git.

Examples:

```text
v0.1.0

v0.2.0

v1.0.0
```

Release notes should summarize:

* New features
* Fixes
* Breaking changes
* Documentation updates

---

# Protected Branches

Once the community grows, the `main` branch should require:

* Pull Request approval
* Successful CI builds
* Passing automated tests
* No merge conflicts

---

# Hotfixes

Critical production fixes may use:

```text
hotfix/<description>
```

Hotfixes should be merged back into `main` as soon as practical.

---

# Long-Lived Branches

Long-lived branches should generally be avoided.

The project should prefer:

* Small branches
* Frequent merges
* Continuous integration

---

# Tags

Tags should identify significant milestones.

Examples:

```text
v0.1.0-alpha

v0.5.0-beta

v1.0.0
```

---

# Branch Lifecycle

```text
Issue
    │
    ▼
Feature Branch
    │
    ▼
Development
    │
    ▼
Pull Request
    │
    ▼
Review
    │
    ▼
Merge
    │
    ▼
Delete Branch
```

Feature branches should be deleted after merging to keep the repository clean.

---

# Continuous Integration

Every Pull Request should trigger:

* Build
* Unit Tests
* Static Analysis
* Formatting Validation

Future pipelines may also include:

* Security Scanning
* Dependency Analysis
* Package Validation

---

# Design Principle

The branching strategy should encourage rapid development without sacrificing quality.

A stable `main` branch builds trust with contributors and users while allowing new features to be developed safely and independently.

---

# Issue Workflow

Issue Created
      ↓
Discussion
      ↓
Approved
      ↓
Branch Created
      ↓
Development
      ↓
Pull Request
      ↓
Review
      ↓
Merge
      ↓
Close Issue