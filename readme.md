# CheckBoxList.Core.BS5

Creates a multiselection check box list based on the provided item source. **Bootstrap 5 compatible.**

> **Note:** This project is based on the original [CheckBoxList.Core](https://github.com/ganeshnj/CheckBoxList.Core) by Ganesh Narayan Jangir. This fork adds Bootstrap 5 support and targets .NET 10.

---

## What's New in This Fork

### Bootstrap 5 Support
- ✅ New `Bootstrap5Basic` template using Bootstrap 5 `form-check` structure
- ✅ New `Bootstrap5Inline` template using `form-check-inline` for horizontal layouts
- ✅ Proper checkbox/label association with `id` and `for` attributes
- ✅ Native Bootstrap 5 styling (no custom CSS required)

### .NET 10 Upgrade
- ✅ Library upgraded from .NET Standard 2.0 to .NET 10
- ✅ Sample project uses minimal hosting model
- ✅ Implicit usings and nullable reference types enabled

### Package Renamed
- Package renamed from `CheckBoxList.Core` to `CheckBoxList.Core.BS5`
- Namespace changed from `CheckBoxList.Core.*` to `CheckBoxList.Core.BS5.*`

---

## Installation

### Package Manager Console

```powershell
Install-Package CheckBoxList.Core.BS5
```

### .NET CLI

```bash
dotnet add package CheckBoxList.Core.BS5
```

---

## Quick Start

### 1. Add Tag Helper

In `_ViewImports.cshtml`:

```cshtml
@addTagHelper *, CheckBoxList.Core.BS5
```

### 2. Controller

```csharp
using CheckBoxList.Core.BS5.Models;

public IActionResult Index()
{
    List<CheckBoxItem> checkBoxItems = new List<CheckBoxItem>()
    {
        new CheckBoxItem(1, "Option 1"),
        new CheckBoxItem(2, "Option 2", isChecked: true),
        new CheckBoxItem(3, "Option 3", isDisabled: true),
        new CheckBoxItem(4, "Option 4", isChecked: true, isDisabled: true)
    };

    return View(checkBoxItems);
}

public IActionResult Result(List<int> selectedIds)
{
    return View(selectedIds);
}
```

### 3. View

```cshtml
@model List<CheckBoxList.Core.BS5.Models.CheckBoxItem>

<form asp-action="Result" method="post">
    <check-box-list name="selectedIds" items="Model" template="Bootstrap5Basic"></check-box-list>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

---

## Available Templates

| Template | Description | Output |
|----------|-------------|--------|
| `Basic` | Plain HTML checkboxes | `<label><input>...</label><br>` |
| `Bootstrap3Basic` | Bootstrap 3 stacked | `<div class="checkbox">...` |
| `Bootstrap3Inline` | Bootstrap 3 inline | `<label class="checkbox-inline">...` |
| `Bootstrap5Basic` | Bootstrap 5 form-check (recommended) | `<div class="form-check">...` |
| `Bootstrap5Inline` | Bootstrap 5 inline | `<div class="form-check form-check-inline">...` |

### Bootstrap 5 Output Example

```html
<div class="form-check">
    <input class="form-check-input" type="checkbox" name="selectedIds" value="1" id="selectedIds_0">
    <label class="form-check-label" for="selectedIds_0">Option 1</label>
</div>
```

---

## Documentation

- [Usage Guide](docs/USAGE_GUIDE.md) - Complete guide for new projects
- [Migration Guide](docs/MIGRATION_GUIDE.md) - Upgrade from CheckBoxList.Core v1.x

---

## Requirements

- .NET 10 or later
- Bootstrap 5.x (for Bootstrap 5 templates)

---

## Credits

- **Original Project:** [CheckBoxList.Core](https://github.com/ganeshnj/CheckBoxList.Core) by [Ganesh Narayan Jangir](https://github.com/ganeshnj)
- **Bootstrap 5 Fork:** This repository

---

## License

MIT