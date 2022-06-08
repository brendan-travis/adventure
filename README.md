# Adventure

A console based game written in .NET

## Project Structure

The application is divided into many project files to represent the different areas of functionality. Each of these projects has a matching unit test project along with over-arching test projects for integration and end to end tests (coming soon).

```
Adventure/
├─ src/
│  ├─ Adventure.Core
│  ├─ Adventure.Main
│  ├─ Adventure.Utils
│  └─ Catalogues/
│     ├─ Adventure.CreatureCatalogue
│     ├─ Adventure.LocaleCatalogue
│     └─ Adventire.SkillCatalogue
└─ tests/
   ├─ Adventure.Core.UnitTests
   ├─ Adventure.Main.UnitTests
   ├─ Adventure.Utils.UnitTests
   └─ Catalogues/
      ├─ Adventure.CreatureCatalogue.UnitTests
      ├─ Adventure.LocaleCatalogue.UnitTests
      └─ Adventire.SkillCatalogue.UnitTests
```
