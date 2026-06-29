# Security Policy

## Supported Versions

During the early stages of development, only the latest development branch is supported.

Once stable releases begin, this table will be updated.

| Version            | Supported |
| ------------------ | :-------: |
| Development (main) |     ✅     |
| Previous Releases  |     ❌     |

---

# Reporting a Security Vulnerability

If you discover a security vulnerability in DOP, **please do not create a public GitHub issue.**

Instead, report the vulnerability privately so it can be investigated and resolved before public disclosure.

Until a dedicated security contact is established, please use GitHub's **Private Vulnerability Reporting** feature (if enabled) or contact the project maintainers through the official project channels.

Your report should include:

* Description of the issue
* Steps to reproduce
* Potential impact
* Suggested mitigation (if known)
* Supporting logs or screenshots where appropriate

We appreciate responsible disclosure and will acknowledge reports as quickly as possible.

---

# Responsible Disclosure

We ask that security researchers:

* Allow reasonable time for investigation and remediation before public disclosure.
* Avoid accessing, modifying, or deleting data that does not belong to you.
* Avoid actions that could negatively impact users or infrastructure.
* Report vulnerabilities in good faith.

Our goal is to work collaboratively with the security community to improve the platform.

---

# Security Principles

Security is a core architectural principle of DOP.

The project is designed around the following concepts:

* Security by Default
* Least Privilege
* Secure Secret Storage
* Explicit Permissions
* Provider Isolation
* Extension Validation
* Defense in Depth

Security considerations should be incorporated during design and implementation rather than added after features are complete.

---

# Secrets

Sensitive information must never be committed to the repository.

Examples include:

* Passwords
* API Keys
* Access Tokens
* Encryption Keys
* Certificates
* Private Keys

Developers should use local configuration, environment variables, or supported secret providers during development.

---

# Dependencies

Third-party dependencies should be:

* Actively maintained
* Well documented
* Necessary
* Reviewed before introduction

The project prefers built-in .NET functionality when practical to reduce unnecessary dependency risk.

---

# Extensions

Extensions should be treated as potentially untrusted code.

The platform will validate extensions before loading and may introduce additional security features over time, including:

* Manifest validation
* Permission declarations
* Version compatibility checks
* Digital signature verification
* Extension isolation

---

# Security Reviews

Major architectural changes should consider their security impact.

Examples include:

* New provider implementations
* Agent communication
* Authentication changes
* Extension loading
* Secret management
* Remote execution capabilities

Security should be part of the design review process, not a post-development checklist.

---

# Reporting Process

When a vulnerability is reported:

1. Acknowledge receipt.
2. Validate the issue.
3. Assess severity and impact.
4. Develop and test a fix.
5. Publish a security update.
6. Credit the reporter when appropriate and with their permission.

---

# Security Updates

Security-related fixes should be clearly identified in release notes and the project changelog.

Where practical, fixes should be backported to supported releases.

---

# Our Commitment

The Deadbelt Operations Platform is committed to building a secure, reliable, and trustworthy platform.

Security is an ongoing process rather than a one-time milestone, and we welcome responsible contributions that help improve the safety and resilience of the project for the entire community.
