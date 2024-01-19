# 🛥️🐳 KSail

[![Test](https://github.com/devantler/ksail/actions/workflows/test.yaml/badge.svg?branch=main)](https://github.com/devantler/ksail/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler/ksail/graph/badge.svg?token=DNEO90PfNR)](https://codecov.io/gh/devantler/ksail)

> [!NOTE]
> This is an early release of KSail. I am actively working on the tool, so if you encounter any issues, please let me know 🙏🏻

![image](https://github.com/devantler/ksail/assets/26203420/c9bfa40b-5ac1-4c81-9511-b8124853e578)

<details>
  <summary>Show/hide folder structure</summary>

<!-- readme-tree start -->
```
.
├── .github
│   ├── scripts
│   └── workflows
├── .vscode
├── autocomplete
├── scripts
├── src
│   └── KSail
│       ├── Arguments
│       ├── CLIWrappers
│       ├── Commands
│       │   ├── Check
│       │   │   └── Handlers
│       │   ├── Down
│       │   │   ├── Handlers
│       │   │   └── Options
│       │   ├── Init
│       │   │   └── Handlers
│       │   ├── Lint
│       │   │   └── Handlers
│       │   ├── List
│       │   │   └── Handlers
│       │   ├── Root
│       │   │   └── Handlers
│       │   ├── SOPS
│       │   │   ├── Handlers
│       │   │   └── Options
│       │   ├── Start
│       │   │   └── Handlers
│       │   ├── Stop
│       │   │   └── Handlers
│       │   ├── Up
│       │   │   ├── Handlers
│       │   │   └── Options
│       │   └── Update
│       │       ├── Handlers
│       │       └── Options
│       ├── Enums
│       ├── Extensions
│       ├── Models
│       ├── Options
│       ├── Provisioners
│       └── assets
│           ├── binaries
│           └── k3d
└── tests
    └── KSail.Tests.Integration
        ├── Commands
        │   ├── Check
        │   ├── Down
        │   ├── Hosts
        │   ├── Lint
        │   ├── List
        │   ├── Root
        │   ├── SOPS
        │   ├── Start
        │   ├── Stop
        │   ├── Up
        │   └── Update
        └── TestUtils

60 directories
```
<!-- readme-tree end -->

</details>

## Getting Started

### Prerequisites

System:

- Unix or Linux-based OS.
  - darwin-amd64 🍎✅
  - darwin-arm64 🍎✅
  - linux-amd64 🐧✅
  - linux-arm64 🐧✅
  - windows-amd64 🪟❌
  - windows-arm64 🪟❌

Tools:

- [Docker](https://www.docker.com) (required)
- [SOPS](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&ved=2ahUKEwiBwqfUh9aDAxViVPEDHUBJBxQQFnoECAMQAQ&url=https%3A%2F%2Fgithub.com%2Fgetsops%2Fsops&usg=AOvVaw1VL2ENXs82bAZnq5jAzeH_&opi=89978449) (optional, if you want to use SOPS for managing secrets.)
- [K9s](https://k9scli.io) (optional, but recommended for debugging.)
- [VScode Extension - Run on Save(pucelle.run-on-save)](https://github.com/pucelle/vscode-run-on-save) (optional, but recommended to run `ksail update` on save, to enable a seamless developer experience.)

### Installation

With Homebrew:

```shell
brew tap devantler/formulas
brew install ksail
```

Manually:

1. Download the latest release from the [releases page](https://github.com/devantler/ksail/releases).
2. Make the binary executable: `chmod +x ksail`.
3. Move the binary to a directory in your `$PATH`: `mv ksail /usr/local/bin/ksail`.

### Usage

To get started use the global help flag:

```shell
ksail --help
```

## What is KSail?

KSail is a CLI tool designed to simplify the management of GitOps-enabled Kubernetes clusters in Docker. It provides a set of commands that allow you to easily create, manage, and dismantle GitOps-enabled clusters. KSail also integrates with SOPS for managing secrets in Git repositories and provides features for validating and verifying your clusters.

## How does it work?

KSail leverages several key technologies to provide its functionality:

- **Embedded Binaries:** KSail embeds binaries for tools like k3d, flux, age, and sops. This enables KSail to work out of the box without requiring you to install any additional dependencies.
- **K3d Backend:** KSail uses K3d, allowing you to run Kubernetes clusters inside Docker containers with a small footprint.
- **Flux GitOps:** KSail sets up Flux GitOps to manage the state of your clusters, with your manifest source serving as the single source of truth.
- **Local OCI Registries:** KSail uses local OCI registries to store and distribute Docker images and manifests.
- **SOPS and Age Integration:** KSail integrates with SOPS and Age for managing secrets in Git repositories.
- **Manifest linting:** KSail lints your manifest files before deploying your clusters.
- **Cluster Reconciliation Checking:** After deploying your clusters, KSail verifies that they reconcile successfully.

## Why was it made?

KSail was created to fill a gap in the tooling landscape for managing GitOps-enabled Kubernetes clusters in Docker. It aims to simplify the process of enabling GitOps, with necessary tools like OCI registries, and SOPS to enable a seamless development environment for K8s.

## Why is it useful?

There are currently two main use cases for KSail:

- **Local Development:** KSail can be used to create and manage GitOps-enabled Kubernetes clusters in Docker for local development. This allows you to easily build and test your applications in a K8s environment.
- **CI/CD:** KSail can be used to spin up GitOps-enabled Kubernetes clusters in CI/CD, to easily verify that your changes are working as expected before deploying them to your other environments.

## Contributing

Contributions to KSail are welcome! You can contribute by reporting bugs, requesting features, or submitting pull requests. When creating an issue or pull request, please provide as much detail as possible to help understand the problem or feature.
