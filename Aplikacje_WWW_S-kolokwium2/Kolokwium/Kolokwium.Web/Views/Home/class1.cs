/*

@model SchoolRegister.ViewModels.VM.AddOrUpdateSubjectVm

@{
    ViewData["Title"] = $"{ViewBag.ActionType} Subject";
}

<h2>@ViewData["Title"]</h2>
<hr />

<div class="row">
    <div class="col-md-4">
        <form asp-action="AddOrEditSubject">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-group">
                <input asp-for="Id" type="hidden" class="form-control" />
            </div>

            <div class="form-group">
                <label asp-for="Name" class="control-label"></label>
                <input asp-for="Name" class="form-control" />
                <span asp-validation-for="Name" class="text-danger"></span>
            </div>

            <div class="form-group">
                <label asp-for="Description" class="control-label"></label>
                <input asp-for="Description" class="form-control" />
                <span asp-validation-for="Description" class="text-danger"></span>
            </div>

            <div class="form-group">
                <label class="control-label">Teacher</label>
                <select asp-for="TeacherId" class="form-control"
                asp-items="@ViewBag.TeachersSelectList"></select>
                <span asp-validation-for="TeacherId" class="text-danger"></span>
            </div>

            <div class="form-group">
                <input type="submit" value="@ViewBag.ActionType" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}



======================================

@using SchoolRegister.ViewModels.VM
@model IEnumerable<SubjectVm>
@{
    ViewData["Title"] = "Index";
}

<h2>Subject</h2>
@if (User.IsInRole("Admin")) {
    <p>
        <a asp-action="AddOrEditSubject">Create New</a>
    </p>
}

<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Description)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.TeacherName)
            </th>
            <th>
                <label>Groups Count</label>
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Name)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Description)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.TeacherName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Groups.Count)
            </td>
            <td>
                @if (User.IsInRole("Admin")) {
                    <a asp-action="AddOrEditSubject" asp-route-id="@item.Id">Edit</a> @:|
                    <a asp-controller="Group" asp-action="AttachSubjectToGroup" asp-route-subjectId="@item.Id">Attach Subject to Group</a> @:|
                    <a asp-controller="Group" asp-action="DetachSubjectFromGroup" asp-route-subjectId="@item.Id">Detach Subject from Group</a> @:|
                }
                <a asp-action="Details" asp-route-id="@item.Id">Details</a>
            </td>
        </tr>
        }
    </tbody>
</table>





=====================





@model SchoolRegister.ViewModels.VM.SubjectVm

@{
    ViewData["Title"] = "Details";
}

<h1>Details</h1>

<div>
    <h4>Subject</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Name)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Name)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Description)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Description)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.TeacherName)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.TeacherName)
        </dd>
    </dl>

    <p><b>Groups:</b></p>
    <ul>
        @foreach (var group in Model.Groups) {
            <li>@group.Name</li>
        }
    </ul>
</div>
<div>
    @if (User.IsInRole("Admin")) {
        <span><a asp-action="AddOrEditSubject" asp-route-id="@Model.Id">Edit</a> |</span>
    }
    <a asp-action="Index">Back to List</a>
</div>








================











@model SchoolRegister.ViewModels.VM.AttachDetachSubjectToTeacherVm

@{
    ViewData["Title"] = "Attach teacher to subject";
}

<h1>Attach teacher to subject</h1>

<hr />

<div class="row">
    <div class="col-md-4">
        <form asp-action="AttachTeacherToSubject">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-group">
                <input asp-for="TeacherId" value="@ViewBag.TeacherId" type="hidden" class="form-control" />
            </div>

             <div class="form-group">
                <label class="control-label">Subject</label>
                <select asp-for="SubjectId" class="form-control" asp-items="@ViewBag.SubjectsSelectList"></select>
                <span asp-validation-for="SubjectId" class="text-danger"></span>
            </div>

            <div class="form-group">
                <input type="submit" value="Attach" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index" asp-controller="Teacher">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}






*/