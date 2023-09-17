
#  Unity Test Extensions
> A set of extensions and helpers for the Unity Test Framework.

## Overview
This repository contains extensions and helpers for the [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html).

### Goals of this project
* Help developers avoid boilerplate code when creating tests in Unity.
* Include code for the most useful scenarios shown in the UTF documentation.
* Include code for scenarios shown in the [Unite Copenhagen talk](https://www.youtube.com/watch?v=wTiF2D0_vKA).
* Add other innovations and updates to UTF (also from the community).

### Table of Contents
* [Installation](#installation)
	* [Prerequisites](#prerequisities)
    * [Install from Unity Package Manager](#Install-from-unity-package-manager)
    * [Install from GitHub source](#install-from-github-source)
* [Features](#features)
	* [LogAssertEx](#logassertex)
	* [Running tests from a menu item](#running-tests-from-a-menu-item)
* [Coming Soon](#coming-soon)
	* Scoped Assertions
	* Build a player for tests (split build & run
* [Contributors](#contributors)
* [Contact](#contact)
* [License](#license)

## Installation

There are a few options for installing this library in your project (see below).

#### Prerequisities

In order to use this library, you must install the following:

 - Unity 2019.2 (or higher)
 - The *Unity Test Framework* package.

#### Install from Unity Package Manager
TBD

#### Install from GitHub source
TBD

## Features
The following section lists the avaailble features as well as planed ones.

### LogAssertEx
Updates and enhancements to the [LogAssert](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-custom-assertion.html#logassert) class.
See this [forum thread](https://forum.unity.com/threads/feedback-for-logassert-class.530539/) with feedback about the *LogAssert* class.

### Running tests from a menu item
Adding the ability to execute edit mode or play mode tests from a menu item.
Also, the static method used for launching tests from the menu item can be re-used and executed when running tests from the command line in batch mode.

## Contributors
Contributions are welcome! Feel free to submit a new pull request with your suggested changes!
## Contact
Feel free to reach out with any question, comment or feedback:

 - For feature requests - open a new issue and describe your requirement.
 - For general questions and feedback - feel free to [email](mailto:liortal53@gmail.com) me.

## License

Distributed under the [MIT License](https://opensource.org/license/mit/). See `LICENSE` for more information.
