# Contributing to Deadbelt Operations Platform (DOP)

First, thank you for your interest in contributing to the **Deadbelt Operations Platform (DOP)**.

Whether you're fixing a typo, improving documentation, reporting a bug, implementing a feature, or reviewing code, your contribution helps make DOP a better platform for everyone.

DOP is intended to be a long-term, community-owned open-source project. Every contributor plays a role in its success.

---

# Before You Begin

We encourage all contributors to familiarize themselves with the project's architecture before writing code.

Recommended reading order:

1. README.md
2. PROJECT_CHARTER.md
3. VISION.md
4. docs/README.md
5. Architecture documentation
6. Coding Standards
7. Branching Strategy

Understanding the project's philosophy before contributing helps maintain architectural consistency.

---

# Ways to Contribute

There are many ways to contribute.

Examples include:

* Reporting bugs
* Improving documentation
* Suggesting new features
* Improving existing features
* Writing tests
* Reviewing pull requests
* Improving performance
* Improving accessibility
* Creating extensions
* Building providers
* Answering community questions

Not every valuable contribution involves writing code.

---

# Development Environment

Current development platform:

* Windows 11
* Visual Studio 2022 Community (or newer)
* .NET SDK (see `global.json`)
* Git
* PowerShell

Additional tools may be introduced as the project evolves.

---

# Finding Work

GitHub Issues are the source of truth for project work.

Before beginning development:

1. Search for an existing issue.
2. Join the discussion if appropriate.
3. If no issue exists, create one.
4. Wait for discussion if the proposed change affects architecture.
5. Create a feature branch linked to the issue.

Example:

```text
Issue #42

feature/42-workspaces
```

---

# Branching

Create a feature branch from `main`.

Examples:

```text
feature/42-workspaces
fix/17-provider-timeout
docs/51-plugin-system
```

Refer to `docs/development/branching-strategy.md` for complete details.

---

# Coding Standards

All contributions should follow the project's coding standards.

Highlights include:

* Small, focused classes
* Constructor dependency injection
* Clear naming
* Async for I/O
* Composition over inheritance
* Nullable Reference Types enabled
* One public type per file

See:

`docs/development/coding-standards.md`

---

# Documentation

Documentation is considered part of the product.

If your contribution changes behavior, architecture, or user workflows, update the appropriate documentation in the same pull request.

Good documentation reduces the barrier to entry for future contributors.

---

# Testing

Where practical, new functionality should include tests.

Priority areas include:

* Domain
* Application
* Providers

Testing expectations will continue to evolve as the platform grows.

---

# Pull Requests

Before submitting a Pull Request, ensure:

* The project builds successfully.
* Tests pass.
* Documentation has been updated where necessary.
* The change is focused on a single issue or feature.
* Commit history is clean and meaningful.

Pull requests should explain:

* What changed
* Why it changed
* Any important implementation details
* Any breaking changes

---

# Code Reviews

Reviews are intended to improve the project.

Feedback should be:

* Respectful
* Constructive
* Specific
* Actionable

Discussion is encouraged.

The goal is to build better software together.

---

# Design Philosophy

Every contribution should align with the project's documented design principles.

In particular:

* Environment over Server
* Desired State over Current State
* Provider Neutrality
* Thin UI, Rich Application Layer
* Extension First
* Community Ownership

If a proposed change conflicts with these principles, begin a discussion before implementation.

---

# Reporting Bugs

A good bug report includes:

* Platform
* DOP version
* Steps to reproduce
* Expected behavior
* Actual behavior
* Relevant logs
* Screenshots (if applicable)

Clear bug reports significantly reduce investigation time.

---

# Suggesting Features

Feature requests should explain:

* The problem being solved
* Why the feature is valuable
* Possible implementation ideas
* Alternatives considered

Large architectural proposals should begin as an RFC before implementation.

---

# Leave It Better

DOP follows the "Leave It Better" principle.

Whenever you work on part of the codebase, leave it in a better state than you found it.

Examples include:

* Improving readability
* Removing dead code
* Clarifying comments
* Refactoring confusing logic
* Improving documentation
* Adding missing tests

Small improvements accumulate into long-term quality.

---

# Community

DOP is intended to become a community-driven platform.

Respectful discussion, thoughtful engineering, and a willingness to learn from one another are valued more than individual preferences.

Every contributor helps shape the future of the project.

Thank you for being part of it.
