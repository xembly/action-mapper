# Changelog

[![Keep a Changelog](https://img.shields.io/badge/Keep%20a%20Changelog-1.0.0-informational)](https://keepachangelog.com/en/1.0.0/)
[![Semantic Versioning](https://img.shields.io/badge/Sematic%20Versioning-2.0.0-informational)](https://semver.org/spec/v2.0.0.html)

Keep the newest entry at top, format date according to ISO 8601: `YYYY-MM-DD`.

Categories:
- _major_ release trigger:
    - `Added` for new features.
    - `Removed` for now removed features.
- _minor_ release trigger:
    - `Added` for new non-breaking features supporting backward compatibility.
    - `Changed` for changes in existing functionality.
    - `Deprecated` for soon-to-be removed features.
- _bug-fix_ release trigger:
    - `Fixed` for any bug fixes.
    - `Security` in case of vulnerabilities.

## [Unreleased]

## [1.0.1]
### Fixed
- Fixed bug preventing the same action being registered for multiple key bindings.
- Corrected ActionRegister.ByWindowTitle to have the window identifier set correectly.

## [1.0.0]
### Added
- Initial release of the library.

[Unreleased]: https://github.com/xembly/action-mapper/compare/1.0.0...HEAD
[1.0.0]: https://github.com/xembly/action-mapper/releases/tag/1.0.0
