# Migration Guide: CheckBoxList.Core v1.x to CheckBoxList.Core.BS5 v2.0

This guide helps you migrate from CheckBoxList.Core v1.x (Bootstrap 3, .NET Core 2.2) to CheckBoxList.Core.BS5 v2.0 (Bootstrap 5, .NET 10).

---

## What's New in v2.0

- ✅ **New Package Name**: `CheckBoxList.Core.BS5` (previously `CheckBoxList.Core`)
- ✅ **Target Framework**: .NET 10 (previously .NET Standard 2.0)
- ✅ **Bootstrap 5 Templates**: New `Bootstrap5Basic` and `Bootstrap5Inline` templates
- ✅ **Backward Compatible**: Bootstrap 3 templates still available

---

## Migration Steps

### Step 1: Update Your Project Target Framework

Update your `.csproj` file to target .NET 10:

```xml
<!-- Before -->
<TargetFramework>netcoreapp2.2</TargetFramework>

<!-- After -->
<TargetFramework>net10.0</TargetFramework>
```

---

### Step 2: Replace the NuGet Package

Remove the old package and add the new one:

```bash
dotnet remove package CheckBoxList.Core
dotnet add package CheckBoxList.Core.BS5
```

Or update your `.csproj`:

```xml
<!-- Before -->
<PackageReference Include="CheckBoxList.Core" Version="1.x.x" />

<!-- After -->
<PackageReference Include="CheckBoxList.Core.BS5" Version="2.0.0" />
```

---

### Step 3: Update Namespace References

Update all `using` statements and `@model` directives:

```csharp
// Before
using CheckBoxList.Core.Models;

// After
using CheckBoxList.Core.BS5.Models;
```

In views:

```cshtml
<!-- Before -->
@model List<CheckBoxList.Core.Models.CheckBoxItem>

<!-- After -->
@model List<CheckBoxList.Core.BS5.Models.CheckBoxItem>
```

---

### Step 4: Update Tag Helper Reference

In `_ViewImports.cshtml`:

```cshtml
<!-- Before -->
@addTagHelper *, CheckBoxList.Core

<!-- After -->
@addTagHelper *, CheckBoxList.Core.BS5
```

---

### Step 5: Upgrade Bootstrap (Required for Bootstrap 5 Templates)

#### Option A: Install via npm

```bash
npm install bootstrap@5.3.2
```

Copy to your `wwwroot/lib/bootstrap` folder.

#### Option B: Use CDN

Update your `_Layout.cshtml`:

```html
<!-- Before (Bootstrap 3) -->
<link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css" />
<script src="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/bootstrap.min.js"></script>

<!-- After (Bootstrap 5) -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
```

> **Note:** Bootstrap 5 does not require jQuery. You can remove jQuery unless other parts of your application need it.

---

### Step 6: Update Template References in Views

Change the `template` attribute from Bootstrap 3 to Bootstrap 5:

```cshtml
<!-- Before -->
<check-box-list name="selectedIds" items="Model" template="Bootstrap3Basic"></check-box-list>

<!-- After -->
<check-box-list name="selectedIds" items="Model" template="Bootstrap5Basic"></check-box-list>
```

#### Template Mapping

| v1.x Template | v2.0 Template |
|---------------|---------------|
| `Bootstrap3Basic` | `Bootstrap5Basic` |
| `Bootstrap3Inline` | `Bootstrap5Inline` |
| `Basic` | `Basic` (unchanged) |

---

### Step 7: Update Bootstrap 3 CSS Classes in Layout/Views

Bootstrap 5 has breaking changes to CSS class names. Update your views:

#### Navbar

```html
<!-- Before (Bootstrap 3) -->
<nav class="navbar navbar-inverse navbar-fixed-top">
    <button class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">

<!-- After (Bootstrap 5) -->
<nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
    <button class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarNav">
```

#### Buttons

```html
<!-- Before -->
<button class="btn btn-default">Submit</button>

<!-- After -->
<button class="btn btn-secondary">Submit</button>
<!-- or -->
<button class="btn btn-primary">Submit</button>
```

#### Form Groups

```html
<!-- Before -->
<div class="form-group">

<!-- After -->
<div class="mb-3">
```

#### Data Attributes

Bootstrap 5 uses `data-bs-*` prefix:

| Bootstrap 3 | Bootstrap 5 |
|-------------|-------------|
| `data-toggle` | `data-bs-toggle` |
| `data-target` | `data-bs-target` |
| `data-dismiss` | `data-bs-dismiss` |

---

### Step 8: Update Program.cs (If Using .NET 6+ Minimal Hosting)

If migrating from .NET Core 2.2/3.1 with `Startup.cs`:

```csharp
// Before (Startup.cs pattern)
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseStaticFiles();
        app.UseMvc(routes => { ... });
    }
}

// After (Program.cs minimal hosting)
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
```

You can then delete `Startup.cs`.

---

## HTML Output Comparison

### Bootstrap 3 (v1.x)

```html
<div class="checkbox">
    <label>
        <input name="selectedIds" value="1" type="checkbox"> Option 1
    </label>
</div>
```

### Bootstrap 5 (v2.0)

```html
<div class="form-check">
    <input class="form-check-input" type="checkbox" name="selectedIds" value="1" id="selectedIds_0">
    <label class="form-check-label" for="selectedIds_0">Option 1</label>
</div>
```

---

## Keeping Bootstrap 3 (No Template Changes)

If you want to stay on Bootstrap 3, you can continue using the old templates:

```cshtml
<check-box-list name="selectedIds" items="Model" template="Bootstrap3Basic"></check-box-list>
```

However, you will need to:
1. Upgrade to .NET 10 (required by the library)
2. Keep Bootstrap 3 CSS/JS in your project
3. Update namespace references to `CheckBoxList.Core.BS5`

---

## Common Migration Issues

### Issue: Checkboxes look unstyled

**Cause:** Bootstrap 5 CSS not loaded or wrong template used.

**Solution:** Ensure Bootstrap 5 CSS is in `_Layout.cshtml` and use `Bootstrap5Basic` template.

### Issue: Navbar toggle doesn't work

**Cause:** Bootstrap 5 requires different data attributes.

**Solution:** Change `data-toggle` to `data-bs-toggle` and `data-target` to `data-bs-target`.

### Issue: jQuery errors after removing it

**Cause:** Other parts of your app depend on jQuery.

**Solution:** Keep jQuery for those features or migrate them to vanilla JavaScript.

### Issue: Build fails with "TargetFramework not supported"

**Cause:** Project still targets old framework.

**Solution:** Update `.csproj` to `<TargetFramework>net10.0</TargetFramework>`.

### Issue: Tag helper not found

**Cause:** Old tag helper reference in `_ViewImports.cshtml`.

**Solution:** Change `@addTagHelper *, CheckBoxList.Core` to `@addTagHelper *, CheckBoxList.Core.BS5`.

---

## Quick Reference Checklist

- [ ] Update project to .NET 10
- [ ] Replace `CheckBoxList.Core` NuGet package with `CheckBoxList.Core.BS5` v2.0.0
- [ ] Update `using CheckBoxList.Core.*` to `using CheckBoxList.Core.BS5.*`
- [ ] Update `@addTagHelper *, CheckBoxList.Core` to `@addTagHelper *, CheckBoxList.Core.BS5`
- [ ] Update `@model` directives in views
- [ ] Upgrade Bootstrap 3 to Bootstrap 5
- [ ] Update `_Layout.cshtml` CSS/JS references
- [ ] Change `template="Bootstrap3Basic"` to `template="Bootstrap5Basic"`
- [ ] Update navbar classes and data attributes
- [ ] Replace `btn-default` with `btn-secondary` or `btn-primary`
- [ ] Replace `form-group` with `mb-3`
- [ ] Remove jQuery (optional)
- [ ] Convert to minimal hosting (optional but recommended)
