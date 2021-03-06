# Project Kitchen

A collaborative kitchen game.

- [Project Kitchen](#project-kitchen)
  - [Design](#design)
  - [Browse Code](#browse-code)
  - [Getting Started](#getting-started)
    - [Software Requirements](#software-requirements)
  - [Contributing](#contributing)
    - [Standards](#standards)
    - [Feature Development](#feature-development)
    - [Branch Types](#branch-types)
    - [Associated Repositories](#associated-repositories)
  - [License](#license)

## Design

- [Functional Specification](documentation/functional/functional.md)
- [Technical Specification](documentation/technical/technical.md)

## Browse Code

[![Preview in Visual Studio Code](https://img.shields.io/badge/preview%20in-vscode.dev-blue)](https://open.vscode.dev/snowmeltarcade/projectkitchen)

## Getting Started

Follow these steps to get started with this project.

```bash
git clone https://github.com/snowmeltarcade/projectkitchen.git
cd ./projectkitchen
git submodule update --init --recursive
cd ./src
python3 build.py
```

### Software Requirements

This project will build on Windows, Mac and Linux. The following software is required in order to build:

* [Git](https://git-scm.com/)
* [Python 3.7](https://www.python.org/) or above
* [Unity3D 2021.3.4f1 LTS](https://unity3d.com/unity/whats-new/2021.3.4)

## Contributing

Pull requests are welcome. All changes must be committed to a separate brach and a pull request made to merge into `main`. Documentation should be updated as part of the pull request. All code should be tested as far as it possible (it is difficult to unit test all code in a game).

### Standards

See [here](https://github.com/snowmeltarcade/coding-standards) for the expected coding standards.

### Feature Development

It is recommended that all new features are first prototyped in their own test branch. Here you can focus on getting the feature and algorithms etc... correct. When you are confident that feature is ready, please develop the feature with in a development branch with focus on code correctness, testing and documentation.

### Branch Types

The main development branch is called `main`. No code is to be directly committed to this branch. Releases are branched from `main`. All code in this branch is considered release ready.

Development branches contain active development on a feature of some kind. They should have meaningful names that describe their purpose. Their live times should be kept as short as is reasonable. Try and keep development branches specific to a feature. Merge/rebase often with `main` to keep merge conflicts at a minimum. When merging with `main`, please squash all commits. The branch should be deleted after a successful merge.

Prototype/test branches contain test or prototyping code used to experiment with new features. They should have meaningful names describing what the branch is testing or prototyping. They should be prefixed with `test-`. They have no fixed live time and can be used as a reference for development branches as long as they are needed. These branches should not be merged with `main`.

### Associated Repositories

There are two associated repositories to be aware of:

* [projectkitchen-assets](https://github.com/snowmeltarcade/projectkitchen-assets)
  * This contains production assets used by the game. It is linked as a submodule within the unity 3d project.
* [projectkitchen-assets-dev](https://github.com/snowmeltarcade/projectkitchen-assets-dev)
  * This contains the development files used to create the production assets.
* [projectkitchendocumentation](https://github.com/snowmeltarcade/projectkitchendocumentation)
  * This contains the generated documentation for this project.

## License

![License](https://img.shields.io/github/license/snowmeltarcade/projectkitchen?style=plastic)
