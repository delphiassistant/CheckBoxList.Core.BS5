# CheckBoxList.Core.BS5 Usage Guide

This guide explains how to use CheckBoxList.Core.BS5 v2.0+ in a new ASP.NET Core project with Bootstrap 5.

---

## Prerequisites

- .NET 10 or later
- ASP.NET Core MVC or Razor Pages project
- Bootstrap 5.x (for Bootstrap 5 templates)

---

## Step 1: Install the NuGet Package

```bash
dotnet add package CheckBoxList.Core.BS5
```

Or via Package Manager Console:

```powershell
Install-Package CheckBoxList.Core.BS5
```

---

## Step 2: Add Tag Helper Reference

In your `_ViewImports.cshtml` file, add:

```cshtml
@addTagHelper *, CheckBoxList.Core.BS5
```

---

## Step 3: Create Your Model

Create a list of `CheckBoxItem` objects to populate your checkbox list:

```csharp
using CheckBoxList.Core.BS5.Models;

// In your controller or page model:
var items = new List<CheckBoxItem>
{
    new CheckBoxItem(1, "Option 1"),
    new CheckBoxItem(2, "Option 2", isChecked: true),  // Pre-selected
    new CheckBoxItem(3, "Option 3"),
    new CheckBoxItem(4, "Option 4", isDisabled: true)  // Disabled
};
```

### CheckBoxItem Constructor

```csharp
public CheckBoxItem(object id, string title, bool isChecked = false, bool isDisabled = false)
```

| Parameter | Description |
|-----------|-------------|
| `id` | Value submitted when checkbox is selected |
| `title` | Label text displayed next to the checkbox |
| `isChecked` | Whether the checkbox is pre-selected |
| `isDisabled` | Whether the checkbox is disabled |

---

## Step 4: Use the Tag Helper in Your View

```cshtml
@model List<CheckBoxList.Core.BS5.Models.CheckBoxItem>

<form asp-action="Submit" method="post">
    <check-box-list name="selectedIds" items="Model" template="Bootstrap5Basic"></check-box-list>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

### Tag Helper Attributes

| Attribute | Type | Description |
|-----------|------|-------------|
| `name` | string | The form field name (used in model binding) |
| `items` | `List<CheckBoxItem>` | The list of checkbox items to render |
| `template` | `TemplateType` | The rendering template to use |

---

## Step 5: Available Templates

| Template | Description | CSS Framework |
|----------|-------------|---------------|
| `Basic` | Plain HTML checkboxes with `<label>` and `<br>` | None |
| `Bootstrap3Basic` | Bootstrap 3 stacked checkboxes | Bootstrap 3 |
| `Bootstrap3Inline` | Bootstrap 3 inline checkboxes | Bootstrap 3 |
| `Bootstrap5Basic` | Bootstrap 5 form-check (stacked) | Bootstrap 5 |
| `Bootstrap5Inline` | Bootstrap 5 form-check-inline | Bootstrap 5 |

### Bootstrap 5 Basic Output

```html
<div class="form-check">
    <input class="form-check-input" type="checkbox" name="selectedIds" value="1" id="selectedIds_0">
    <label class="form-check-label" for="selectedIds_0">Option 1</label>
</div>
```

### Bootstrap 5 Inline Output

```html
<div class="form-check form-check-inline">
    <input class="form-check-input" type="checkbox" name="selectedIds" value="1" id="selectedIds_0">
    <label class="form-check-label" for="selectedIds_0">Option 1</label>
</div>
```

---

## Step 6: Handle Form Submission

In your controller, receive the selected IDs:

```csharp
[HttpPost]
public IActionResult Submit(List<int> selectedIds)
{
    // selectedIds contains the IDs of checked checkboxes
    foreach (var id in selectedIds)
    {
        // Process selected items
    }
    
    return View("Result", selectedIds);
}
```

> **Note:** The parameter name (`selectedIds`) must match the `name` attribute in the tag helper.

---

## Complete Example

### Controller

```csharp
using CheckBoxList.Core.BS5.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var items = new List<CheckBoxItem>
        {
            new CheckBoxItem(1, "Red"),
            new CheckBoxItem(2, "Green", isChecked: true),
            new CheckBoxItem(3, "Blue"),
            new CheckBoxItem(4, "Yellow", isDisabled: true)
        };
        
        return View(items);
    }

    [HttpPost]
    public IActionResult Submit(List<int> selectedColors)
    {
        // Process selected colors
        return View("Result", selectedColors);
    }
}
```

### View (Index.cshtml)

```cshtml
@model List<CheckBoxList.Core.BS5.Models.CheckBoxItem>
@{
    ViewData["Title"] = "Select Colors";
}

<h2>Choose Your Colors</h2>

<form asp-action="Submit" method="post">
    <div class="mb-3">
        <check-box-list name="selectedColors" items="Model" template="Bootstrap5Basic"></check-box-list>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

---

## Troubleshooting

### Tag helper not recognized

Ensure `@addTagHelper *, CheckBoxList.Core.BS5` is in `_ViewImports.cshtml`.

### Checkboxes not styled

Verify Bootstrap 5 CSS is loaded in your `_Layout.cshtml`:

```html
<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
```

### Empty selectedIds on submit

Check that the `name` attribute in the tag helper matches your action parameter name.
