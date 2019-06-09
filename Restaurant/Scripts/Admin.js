$(document).ready(function () {
    loadStaff();
    loadUsers();

    $('#btnAddAcc').on('click', function () {
        var pageFrom = $('#btnAddAcc').attr('from');
        if (pageFrom === "Staff") {
            window.location.href = "http://" + window.location.host + "/Account/AddStaff";
        } else {
            window.location.href = "http://" + window.location.host + "/Account/AddUser";
        }
        
    });
    $('#btnDeleteAcc').on('click', function () {
        var Id = $('.selected').attr('Id');
        $.post("/Account/DeleteStaff", { PersonId: Id });
    });
});

function loadUsers() {
    if ($('#UsersTable').length > 0) {
        $.ajax({
            url: "/data/GetUsers",
            type: "GET",
            success: function (data) {
                $('#userTmpl').tmpl(data).appendTo('#UsersTable');
                selectRow();
            }
        });
    }
}
function loadStaff() {
    if ($('#StaffTable').length > 0) {
        $.ajax({
            url: "/data/GetStaff",
            type: "GET",
            success: function (data) {
                $('#staffTmpl').tmpl(data).appendTo('#StaffTable');
                selectRow();
            }
        });
    }
}
function selectRow() {
    $('tbody tr').on('click', function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });
}
